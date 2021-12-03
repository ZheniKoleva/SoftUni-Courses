namespace VaporStore.DataProcessor
{
	using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Import;

    public static class Deserializer
	{
		private const string Error_Message = "Invalid Data";

		private const string Successful_Game_Import_Message = "Added {0} ({1}) with {2} tags"!;
		
		private const string Successful_User_Import_Message = "Imported {0} with {1} cards"!;

		private const string Successful_Purchase_Import_Message = "Imported {0} for {1}"!;

		public static string ImportGames(VaporStoreDbContext context, string jsonString)
		{
			ImportGameDTO[] extractedData = JsonConvert.DeserializeObject<ImportGameDTO[]>(jsonString);

			StringBuilder sb = new StringBuilder();
			HashSet<Game> gamesToImport = new HashSet<Game>();

			HashSet<Developer> existingDevelopers = context.Developers.ToHashSet();
			HashSet<Genre> existingGenres = context.Genres.ToHashSet();
			HashSet<Tag> existingTags = context.Tags.ToHashSet();

			foreach (ImportGameDTO gameInfo in extractedData)
			{
				if (!IsValid(gameInfo)
					|| string.IsNullOrWhiteSpace(gameInfo.Developer)
					|| string.IsNullOrWhiteSpace(gameInfo.Genre))
                {
					sb.AppendLine(Error_Message);
					continue;
                }

				Developer gameDeveloper = existingDevelopers.FirstOrDefault(d => d.Name == gameInfo.Developer)
					?? new Developer() { Name = gameInfo.Developer };				

				Genre gameGenre = existingGenres.FirstOrDefault(g => g.Name == gameInfo.Genre)
					?? new Genre() { Name = gameInfo.Genre };

				HashSet<Tag> gameTags = new HashSet<Tag>();

				bool hasInValidTag = false;

                foreach (var gameTag in gameInfo.Tags)
                {
                    if (string.IsNullOrWhiteSpace(gameTag))
                    {
						hasInValidTag = true;
						break;
                    }

					Tag currentGameTag = existingTags.FirstOrDefault(t => t.Name == gameTag)
						?? new Tag() { Name = gameTag };
					
					gameTags.Add(currentGameTag);					
				}

                if (hasInValidTag)
                {
					sb.AppendLine(Error_Message);
					continue;
				}

				DateTime date;
				bool isValidDate = DateTime.TryParseExact(gameInfo.ReleaseDate, "yyyy-MM-dd", 
					CultureInfo.InvariantCulture, DateTimeStyles.None, out date);

				if (!isValidDate)
				{
					sb.AppendLine(Error_Message);
					continue;
				}

				existingDevelopers.Add(gameDeveloper);
				existingGenres.Add(gameGenre);

                foreach (var tag in gameTags)
                {
					existingTags.Add(tag);
				}				

				Game currentGame = new Game
				{
					Name = gameInfo.Name,
					Price = gameInfo.Price,
					Developer = gameDeveloper,
					Genre = gameGenre
				};

				ICollection<GameTag> currentGameTags = gameTags
					.Select(t => new GameTag
					{
						Tag = t,
						Game = currentGame
					})
					.ToArray();

				currentGame.GameTags = currentGameTags;

				gamesToImport.Add(currentGame);
				sb.AppendLine(string.Format(Successful_Game_Import_Message,
					currentGame.Name, currentGame.Genre.Name, currentGame.GameTags.Count));
			}

			context.Games.AddRange(gamesToImport);
			context.SaveChanges();

			return sb.ToString().TrimEnd();			
		}

		public static string ImportUsers(VaporStoreDbContext context, string jsonString)
		{
			ImportUserDTO[] extractedData = JsonConvert.DeserializeObject<ImportUserDTO[]>(jsonString);

			StringBuilder sb = new StringBuilder();

			HashSet<User> usersToImport = new HashSet<User>();

            foreach (var userInfo in extractedData)
            {
                if (!IsValid(userInfo))
                {
					sb.AppendLine(Error_Message);
					continue;
                }

				HashSet<Card> userCards = new HashSet<Card>();

				bool hasInvalidCard = false;

                foreach (var card in userInfo.Cards)
                {
                    if (!IsValid(card) 
						|| !Enum.TryParse(typeof(CardType), card.Type, out object type))
                    {
						hasInvalidCard = true;
						break;
					}

					Card currentCard = new Card
					{
						Number = card.Number,
						Cvc = card.CVC,
						Type = (CardType)type,
					};

					userCards.Add(currentCard);
                }

                if (hasInvalidCard)
                {
					sb.AppendLine(Error_Message);
					continue;
				}

				User currentUser = new User
				{
					FullName = userInfo.FullName,
					Username = userInfo.Username,
					Email = userInfo.Email,
					Age = userInfo.Age,
					Cards = userCards
				};

				usersToImport.Add(currentUser);
				sb.AppendLine(string.Format(Successful_User_Import_Message,
					currentUser.Username, currentUser.Cards.Count));
            }

			context.Users.AddRange(usersToImport);
			context.SaveChanges();

			return sb.ToString().TrimEnd();
		}

		public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
		{
			XmlRootAttribute root = new XmlRootAttribute("Purchases");
			XmlSerializer serializer = new XmlSerializer(typeof(ImportPurchaseDTO[]), root);

			StringBuilder sb = new StringBuilder();

			using StringReader reader = new StringReader(xmlString);

			ImportPurchaseDTO[] extractedData = (ImportPurchaseDTO[])serializer.Deserialize(reader);

			HashSet<Card> existingCards = context.Cards.ToHashSet();
			HashSet<Game> existingGames = context.Games.ToHashSet();

			HashSet<Purchase> purchasesToImport = new HashSet<Purchase>();

			foreach (var purchaseInfo in extractedData)
			{
				if (!IsValid(purchaseInfo))
				{
					sb.AppendLine(Error_Message);
					continue;
				}

				Card cardHolder = existingCards
						.FirstOrDefault(c => c.Number == purchaseInfo.CardNumber);

				Game purchaseGame = existingGames
					.FirstOrDefault(g => g.Name == purchaseInfo.GameName);

				object type;
				bool isValidCardType = Enum.TryParse(typeof(PurchaseType), purchaseInfo.Type, out type);

				bool isValidDate = DateTime.TryParseExact(purchaseInfo.Date, "dd/MM/yyyy HH:mm",
					CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date);

				if (cardHolder == null 
					|| purchaseGame == null
					|| !isValidCardType 
					|| !isValidDate)
				{
					sb.AppendLine(Error_Message);
					continue;
				}				

				Purchase currentPurchase = new Purchase
				{
					Type = (PurchaseType)type,
					ProductKey = purchaseInfo.ProductKey,
					Date = date,
					Card = cardHolder,
					Game = purchaseGame
				};

				purchasesToImport.Add(currentPurchase);

				sb.AppendLine(string.Format(Successful_Purchase_Import_Message,
					currentPurchase.Game.Name, currentPurchase.Card.User.Username));
            }

			context.AddRange(purchasesToImport);
			context.SaveChanges();

			return sb.ToString().TrimEnd();

		}

		private static bool IsValid(object dto)
		{
			var validationContext = new ValidationContext(dto);
			var validationResult = new List<ValidationResult>();

			return Validator.TryValidateObject(dto, validationContext, validationResult, true);
		}
	}
}