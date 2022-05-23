namespace Theatre.DataProcessor
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Globalization;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;

    using Newtonsoft.Json;
    using System.Xml.Serialization;

    using Data;
    using Common;
    using Data.Models;
    using Data.Models.Enums;
    using DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";

        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            XmlRootAttribute root = new XmlRootAttribute("Plays");
            XmlSerializer serializer = new XmlSerializer(typeof(ImportPlayDTO[]), root);

            StringBuilder sb = new StringBuilder();
            HashSet<Play> playsToImport = new HashSet<Play>();

            using StringReader reader = new StringReader(xmlString);

            ImportPlayDTO[] extractedData = (ImportPlayDTO[])serializer.Deserialize(reader);

            foreach (var playInfo in extractedData)
            {
                if (!IsValid(playInfo))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                TimeSpan timeSpan = TimeSpan.ParseExact(playInfo.Duration, "c", CultureInfo.InvariantCulture);

                if (timeSpan.Hours < EntityConstants.Play_Duration_Min_Hours_Lenght)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Genre genre = Enum.Parse<Genre>(playInfo.Genre);

                Play currentPlay = new Play
                {
                    Title = playInfo.Title,
                    Duration = timeSpan,
                    Rating = playInfo.Rating,
                    Genre = genre,
                    Description = playInfo.Description,
                    Screenwriter = playInfo.Screenwriter
                };

                playsToImport.Add(currentPlay);

                sb.AppendLine(string.Format(SuccessfulImportPlay, 
                    currentPlay.Title, currentPlay.Genre.ToString(), currentPlay.Rating));
            }

            context.Plays.AddRange(playsToImport);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            XmlRootAttribute root = new XmlRootAttribute("Casts");
            XmlSerializer serializer = new XmlSerializer(typeof(ImportCastDTO[]), root);

            StringBuilder sb = new StringBuilder();

            HashSet<Cast> castsToImport = new HashSet<Cast>();

            using StringReader reader = new StringReader(xmlString);
            ImportCastDTO[] extractedData = (ImportCastDTO[])serializer.Deserialize(reader);

            foreach (var castInfo in extractedData)
            {
                if (!IsValid(castInfo))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Cast currentCast = new Cast
                {
                    FullName = castInfo.FullName,
                    IsMainCharacter = castInfo.IsMainCharacter,
                    PhoneNumber = castInfo.PhoneNumber,
                    PlayId = castInfo.PlayId,
                };

                castsToImport.Add(currentCast);

                string characterType = currentCast.IsMainCharacter ? "main" : "lesser";

                sb.AppendLine(string.Format(SuccessfulImportActor,
                    currentCast.FullName, characterType));

            }

            context.Casts.AddRange(castsToImport);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            IEnumerable<ImportTheaterDTO> extractedData = 
                JsonConvert.DeserializeObject<IEnumerable<ImportTheaterDTO>>(jsonString);

            StringBuilder sb = new StringBuilder();

            HashSet<Theatre> theatersToImport = new HashSet<Theatre>();

            HashSet<int> existingPlays = context.Plays.Select(x => x.Id).ToHashSet();

            foreach (var theatreInfo in extractedData)
            {
                if (!IsValid(theatreInfo))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Theatre currentTheater = new Theatre
                {
                    Name = theatreInfo.Name,
                    NumberOfHalls = theatreInfo.NumberOfHalls,
                    Director = theatreInfo.Director,                  
                };

                HashSet<Ticket> tickets = new HashSet<Ticket>();

                foreach (var ticket in theatreInfo.Tickets)
                {
                    if (!IsValid(ticket) || !existingPlays.Contains(ticket.PlayId))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Ticket currentTicket = new Ticket
                    {
                        Price = ticket.Price,
                        RowNumber = ticket.RowNumber,
                        PlayId = ticket.PlayId,
                    };

                    tickets.Add(currentTicket);
                }                
                
                currentTheater.Tickets = tickets;  

                theatersToImport.Add(currentTheater);

                sb.AppendLine(string.Format(SuccessfulImportTheatre,
                    currentTheater.Name, currentTheater.Tickets.Count()));

            }

            context.Theatres.AddRange(theatersToImport);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }


        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
