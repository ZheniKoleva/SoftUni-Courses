namespace BookShop.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;

    using System.Xml;
    using System.Xml.Serialization;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    using Data;
    using Data.Models.Enums;
    using ExportDto;

    public class Serializer
    {
        public static string ExportMostCraziestAuthors(BookShopContext context)
        {
            ExportAuthorsDTO[] filteredAuthors = context.Authors                
                .Select(a => new ExportAuthorsDTO
                {
                    AuthorName = $"{a.FirstName} {a.LastName}",
                    Books = a.AuthorsBooks
                           .Select(ab => ab.Book)
                           .OrderByDescending(b => b.Price)
                           .Select(b => new ExportAuthorBooksDTO
                           {
                               BookName = b.Name,
                               BookPrice = $"{b.Price:f2}",
                           })
                           .ToArray()
                })
                .ToArray()
                .OrderByDescending(a => a.Books.Length)
                .ThenBy(a => a.AuthorName)
                .ToArray();            

            string authorsAsJson = JsonConvert.SerializeObject(filteredAuthors, Formatting.Indented);

            return authorsAsJson;
        }

        public static string ExportOldestBooks(BookShopContext context, DateTime date)
        {   
            ExportBookDTO[] booksToExport = context.Books
                .Where(b => b.PublishedOn < date && b.Genre == Genre.Science)
                .OrderByDescending(b => b.Pages)
                .ThenByDescending(b => b.PublishedOn)
                .Take(10)
                .Select(b => new ExportBookDTO
                { 
                    Name = b.Name,
                    Date = b.PublishedOn.ToString("d", CultureInfo.InvariantCulture),
                    Pages = b.Pages.ToString()
                })
                .ToArray();

            XmlRootAttribute root = new XmlRootAttribute("Books");
            XmlSerializer serializer = new XmlSerializer(typeof(ExportBookDTO[]), root);
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            StringBuilder booksAsXml = new StringBuilder();

            using StringWriter writer = new StringWriter(booksAsXml);
            serializer.Serialize(writer, booksToExport, namespaces);

            return booksAsXml.ToString();
        }
    }
}