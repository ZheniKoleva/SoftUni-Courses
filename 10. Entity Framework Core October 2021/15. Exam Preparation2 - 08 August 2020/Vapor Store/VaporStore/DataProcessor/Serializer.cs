namespace VaporStore.DataProcessor
{
    using System;
    using System.IO;
    using System.Text;
    using System.Linq;
    using System.Globalization;
   
    using Newtonsoft.Json;
    using System.Xml.Serialization;
    using Microsoft.EntityFrameworkCore;

    using Data;
    using Data.Models.Enums;
    using Dto.Export;    

    public static class Serializer
    {
        public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
        {
            var filteredGames = context.Genres
                .Where(g => genreNames.Contains(g.Name))
                .ToArray()
                .Select(g => new ExportGameByGenreDTO
                {
                    Id = g.Id,
                    Genre = g.Name,
                    Games = g.Games
                             .Where(ga => ga.Purchases.Any())
                             .Select(ga => new ExportGameInfoDTO
                             {
                                 Id = ga.Id,
                                 Title = ga.Name,
                                 Developer = ga.Developer.Name,
                                 Tags = string.Join(", ", ga.GameTags.Select(gt => gt.Tag.Name)),
                                 Players = ga.Purchases.Count()
                             })
                             .OrderByDescending(eg => eg.Players)
                             .ThenBy(eg => eg.Id)
                             .ToArray(),
                    TotalPlayers = g.Games
                                    .Sum(ga => ga.Purchases.Count())
                                    
                })
                .OrderByDescending(x => x.TotalPlayers)
                .ThenBy(x => x.Id);

            string gamesToexport = JsonConvert.SerializeObject(filteredGames, Formatting.Indented);

            return gamesToexport;
        }

        public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
        {
            PurchaseType searchedType = Enum.Parse<PurchaseType>(storeType);

            XmlRootAttribute root = new XmlRootAttribute("Users");
            XmlSerializer serializer = new XmlSerializer(typeof(ExportUserPurchaseDTO[]), root);
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            StringBuilder infoToExport = new StringBuilder();

            using StringWriter writer = new StringWriter(infoToExport);
      
            ExportUserPurchaseDTO[] data = context.Users                           
                .Where(u => u.Cards.Any(c => c.Purchases.Any()))
                .ToArray()
                .Select(u => new ExportUserPurchaseDTO
                {
                    Username = u.Username,
                    Purchases = context.Purchases
                                .Where(p => p.Card.User.Username == u.Username && p.Type == searchedType)                                
                                .OrderBy(p => p.Date)
                                .Select(p => new ExportPurchaseDTO
                                {
                                    Card = p.Card.Number,
                                    Cvc = p.Card.Cvc,
                                    Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                                    Game = new ExportGameDTO
                                    {
                                        Title = p.Game.Name,
                                        Genre = p.Game.Genre.Name,
                                        Price = p.Game.Price,
                                    }
                                })
                                .ToArray(),
                    TotalSpent = context.Purchases
                                .Where(p => p.Card.User.Username == u.Username && p.Type == searchedType)
                                .Sum(p => p.Game.Price)
                })
                .Where(u => u.Purchases.Any())
                .OrderByDescending(u => u.TotalSpent)
                .ThenBy(u => u.Username)
                .ToArray();

            serializer.Serialize(writer, data, namespaces);

            return infoToExport.ToString().TrimEnd();
        }
    }
}