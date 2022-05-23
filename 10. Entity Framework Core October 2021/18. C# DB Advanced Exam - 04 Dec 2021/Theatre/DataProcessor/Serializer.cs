namespace Theatre.DataProcessor
{  
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Globalization;

    using Newtonsoft.Json;
    using System.Xml.Serialization;

    using Data;
    using ExportDto;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var theatresToExport = context.Theatres
                .Where(t => t.NumberOfHalls >= numbersOfHalls && t.Tickets.Count >= 20)
                .ToArray()
                .Select(x => new
                {
                    Name = x.Name,
                    Halls = x.NumberOfHalls,
                    TotalIncome = x.Tickets
                                 .Where(ti => ti.RowNumber >= 1 && ti.RowNumber <= 5)
                                 .Sum(ti => ti.Price),
                    Tickets = x.Tickets
                               .ToArray()
                               .Where(ti => ti.RowNumber >= 1 && ti.RowNumber <= 5)
                               .Select(y => new
                               {
                                   Price = y.Price,
                                   RowNumber = y.RowNumber
                               })
                               .ToArray()
                               .OrderByDescending(x => x.Price)

                })
                .OrderByDescending(t => t.Halls)
                .ThenBy(t => t.Name)
                .ToArray();


            string json = JsonConvert.SerializeObject(theatresToExport, Formatting.Indented);

            return json;
        }

        public static string ExportPlays(TheatreContext context, double rating)
        {
            XmlRootAttribute root = new XmlRootAttribute("Plays");
            XmlSerializer serializer = new XmlSerializer(typeof(ExportPlayDTO[]), root);
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            StringBuilder xmlOutput = new StringBuilder();
            using StringWriter writer = new StringWriter(xmlOutput);

            var playsToExport = context.Plays
                .Where(p => p.Rating <= rating)
                .Select(p => new ExportPlayDTO
                {
                    Title = p.Title,
                    Duration = p.Duration.ToString("c", CultureInfo.InvariantCulture),
                    Rating = p.Rating == 0 ? "Premier" : p.Rating.ToString(),
                    Genre = p.Genre.ToString(),
                    Actors = p.Casts
                              .Where(a => a.IsMainCharacter)
                              .Select(a => new ExportActorDTO
                              {
                                  FullName = a.FullName,
                                  MainCharacter = $"Plays main character in '{p.Title}'."
                              })
                              .OrderByDescending(a => a.FullName)
                              .ToArray()
                })
                .ToArray()
                .OrderBy(p => p.Title)
                .ThenByDescending(p => p.Genre)
                .ToArray();

            serializer.Serialize(writer, playsToExport, namespaces);

            return xmlOutput.ToString();           
        }
    }
}
