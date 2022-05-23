namespace BookShop.DataProcessor
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Globalization;
    using System.Collections.Generic;

    using System.Xml.Serialization;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    using Data;
    using ImportDto;
    using Data.Models;
    using Data.Models.Enums;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedBook
            = "Successfully imported book {0} for {1:F2}.";

        private const string SuccessfullyImportedAuthor
            = "Successfully imported author - {0} with {1} books.";

        public static string ImportBooks(BookShopContext context, string xmlString)
        {
            XmlRootAttribute root = new XmlRootAttribute("Books");
            XmlSerializer serializer = new XmlSerializer(typeof(ImportBookDTO[]), root);
            StringBuilder sb = new StringBuilder();

            using StringReader reader = new StringReader(xmlString);

            ImportBookDTO[] extractedBooksData = (ImportBookDTO[])serializer.Deserialize(reader);

            HashSet<Book> booksToImport = new HashSet<Book>();

            foreach (var book in extractedBooksData)
            {
                if (!IsValid(book))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isValidDate = DateTime.TryParseExact(book.PublishedOn, "MM/dd/yyyy", CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out DateTime bookPublishedDate);

                if (!isValidDate)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }                

                Book currentBook = new Book
                {
                    Name = book.Name,
                    Genre = (Genre)book.Genre,
                    Price = book.Price,
                    Pages = book.Pages,
                    PublishedOn = bookPublishedDate
                };

                booksToImport.Add(currentBook);
                sb.AppendLine(String.Format(SuccessfullyImportedBook, currentBook.Name, currentBook.Price));

            }

            context.Books.AddRange(booksToImport);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            ImportAuthorDTO[] extractedData = JsonConvert.DeserializeObject<ImportAuthorDTO[]>(jsonString);

            StringBuilder sb = new StringBuilder();
            HashSet<int> existingBooksId = context.Books
                                                   .Select(x => x.Id)
                                                   .ToHashSet();

            HashSet<string> existingEmails = context.Authors
                                                   .Select(x => x.Email)
                                                   .ToHashSet();

            HashSet<Author> authorsToImport = new HashSet<Author>();

            foreach (var author in extractedData)
            {
                if (!IsValid(author))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }               

                if (existingEmails.Contains(author.Email))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                existingEmails.Add(author.Email);

                Author currentAuthor = new Author
                {
                    FirstName = author.FirstName,
                    LastName = author.LastName,
                    Phone = author.Phone,
                    Email = author.Email
                };

                foreach (ImportBookId bookId in author.Books)
                {                    
                    if (bookId.Id != null && existingBooksId.Contains((int)bookId.Id))
                    {
                        AuthorBook authorBook = new AuthorBook
                        {
                            Author = currentAuthor,
                            BookId = (int)bookId.Id
                        };

                        currentAuthor.AuthorsBooks.Add(authorBook);
                    }
                   
                }

                if (!currentAuthor.AuthorsBooks.Any())
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                authorsToImport.Add(currentAuthor);

                string authorFullName = $"{currentAuthor.FirstName} {currentAuthor.LastName}";

                sb.AppendLine(string.Format(SuccessfullyImportedAuthor, authorFullName, currentAuthor.AuthorsBooks.Count));
            }

            context.Authors.AddRange(authorsToImport);
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