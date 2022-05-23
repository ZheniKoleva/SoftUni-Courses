namespace BookShop
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using Models.Enums;
    using Z.EntityFramework.Plus;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);

            //Task 01 Age Restriction
            string command = Console.ReadLine();
            string booksByAgeRestriction = GetBooksByAgeRestriction(db, command);
            Console.WriteLine(booksByAgeRestriction);

            //Task 02. Golden Books
            string goldenBooks = GetGoldenBooks(db);
            Console.WriteLine(goldenBooks);

            //Task 03. Books by Price
            string booksByPrice = GetBooksByPrice(db);
            Console.WriteLine(booksByPrice);

            //Task 04. Not Released In
            int year = int.Parse(Console.ReadLine());
            string booksNoReleasedIn = GetBooksNotReleasedIn(db, year);
            Console.WriteLine(booksNoReleasedIn);

            //Task 05. Book Titles by Category
            string categories = Console.ReadLine();
            string booksByCategpries = GetBooksByCategory(db, categories);
            Console.WriteLine(booksByCategpries);

            //Task 06. Released Before Date
            string beforeDate = Console.ReadLine();
            string result = GetBooksReleasedBefore(db, beforeDate);
            Console.WriteLine(result);

            //Task 07. Author Search
            string searchedEnd = Console.ReadLine();
            string authorSearch = GetAuthorNamesEndingIn(db, searchedEnd);
            Console.WriteLine(authorSearch);

            //Task 08. Book Search
            string searchedString = Console.ReadLine();
            string bookSearch = GetBookTitlesContaining(db, searchedString);
            Console.WriteLine(bookSearch);

            //Task 09. Book Search by Author
            string startString = Console.ReadLine();
            string booksByAuthor = GetBooksByAuthor(db, startString);
            Console.WriteLine(booksByAuthor);

            //Task 10. Count Books
            int lenghtLimit = int.Parse(Console.ReadLine());
            int booksCount = CountBooks(db, lenghtLimit);
            Console.WriteLine(booksCount);

            //Task 11. Total Book Copies
            string bookCopies = CountCopiesByAuthor(db);
            Console.WriteLine(bookCopies);

            //Task 12. Profit by Category
            string profitByCategory = GetTotalProfitByCategory(db);
            Console.WriteLine(profitByCategory);

            //Task 13. Most Recent Books
            string books = GetMostRecentBooks(db);
            Console.WriteLine(books);

            //Task 14. Increase Prices
            IncreasePrices(db);

            //Task 15. Remove Books
            int deletedBooks = RemoveBooks(db);
            Console.WriteLine(deletedBooks);
        }

        //Task 15
        public static int RemoveBooks(BookShopContext context)
        {
            var toDelete = context.Books
                .Where(b => b.Copies < 4200);

            int toDeleteCount = toDelete.Count();
            context.BulkDelete(toDelete);

            return toDeleteCount;          
        }

        //Task 14
        public static void IncreasePrices(BookShopContext context)
        {
            var booksToIncrease = context.Books
                 .Where(b => b.ReleaseDate.HasValue && b.ReleaseDate.Value.Year < 2010);

            foreach (var book in booksToIncrease)
            {
                book.Price += 5;
            }                

            context.BulkUpdate(booksToIncrease); 
        }

        //Task 13
        public static string GetMostRecentBooks(BookShopContext context)
        {
            StringBuilder output = new StringBuilder();

            var recentBooks = context.Categories               
                .Select(c => new
                {
                    c.Name,
                    Books = c.CategoryBooks
                        .Select(b => b.Book)
                        .OrderByDescending(b => b.ReleaseDate)
                        .Take(3)
                        .Select(b => new
                        {
                            BookName = b.Title,
                            ReleaseYear = b.ReleaseDate.Value.Year
                        })
                })
                .OrderBy(c => c.Name)                
                .ToArray();

            foreach (var category in recentBooks)
            {
                output.AppendLine($"--{category.Name}");

                foreach (var book in category.Books)
                {
                    output.AppendLine($"{book.BookName} ({book.ReleaseYear})");
                }
            }

            return output.ToString().TrimEnd();
        }

        //Task 12
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            StringBuilder output = new StringBuilder();

            var profitBuCategories = context.Categories                
                .Select(c => new 
                {
                    c.Name,
                    Profit = c.CategoryBooks.Sum(b => b.Book.Copies * b.Book.Price)
                }) 
                .OrderByDescending(c => c.Profit)
                .ThenBy(c => c.Name)
                .ToArray();

            foreach (var category in profitBuCategories)
            {
                output.AppendLine($"{category.Name} ${category.Profit:f2}");
            }

            return output.ToString().TrimEnd();
        }

        //Task 11
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            StringBuilder output = new StringBuilder();

            var booksCopies = context.Authors
                .Select(a => new
                {
                    Name = $"{a.FirstName} {a.LastName}",
                    BooksCount = a.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(a => a.BooksCount)
                .ToArray();

            foreach (var author in booksCopies)
            {
                output.AppendLine($"{author.Name} - {author.BooksCount}");
            }

            return output.ToString().TrimEnd();
        }

        //Task 10
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            int booksCount = context.Books
                .Count(b => b.Title.Length > lengthCheck);

            return booksCount;
        
        }

        //Task 09
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            StringBuilder output = new StringBuilder();

            var books = context.Books                
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(x => new
                {
                    x.Title,
                    AuthorName = $"{x.Author.FirstName} {x.Author.LastName}"
                })
                .ToList();

            foreach (var book in books)
            {
                output.AppendLine($"{book.Title} ({book.AuthorName})");
            }               

            return output.ToString().TrimEnd();
        }

        //Task 08
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            StringBuilder output = new StringBuilder();

            context.Books   
                .ToList()
                .Where(b => b.Title.Contains(input, StringComparison.OrdinalIgnoreCase))
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToList()
                .ForEach(a => output.AppendLine(a));

            return output.ToString().TrimEnd();
        }

        //Task 07
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            StringBuilder output = new StringBuilder();

            context.Authors
                .ToList()
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => $"{a.FirstName} {a.LastName}")
                .OrderBy(a => a)
                .ToList()
                .ForEach(a => output.AppendLine(a));

            return output.ToString().TrimEnd();
        }

        //Task 06
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            StringBuilder output = new StringBuilder();

            DateTime dateBefore = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context.Books
                .Where(b => b.ReleaseDate.HasValue && b.ReleaseDate < dateBefore)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new
                 { 
                    b.Title,
                    b.EditionType,
                    b.Price                 
                 })
                .ToArray();

            foreach (var book in books)
            {
                output.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:f2}");
            }

            return output.ToString().TrimEnd();
        }

        //Task 05
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] categories = input
                .ToLower()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            StringBuilder output = new StringBuilder();

            var books = context.Books                
                .Where(b => b.BookCategories.Any(bc => categories.Contains(bc.Category.Name.ToLower())))
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToList();

            books
                .ForEach(b => output.AppendLine(b));

            return output.ToString().TrimEnd();
        }

        //Task 04
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            StringBuilder output = new StringBuilder();

            context.Books
                .Where(b => b.ReleaseDate.HasValue && b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList()
                .ForEach(t => output.AppendLine(t));

            return output.ToString().TrimEnd();
        }

        //Task 03 
        public static string GetBooksByPrice(BookShopContext context)
        {
            StringBuilder output = new StringBuilder();

            var books = context.Books
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .Select(b => new { b.Title, b.Price })
                .ToArray();

            foreach (var book in books)
            {
                output.AppendLine($"{book.Title} - ${book.Price:f2}");
            }

            return output.ToString().TrimEnd();
        }

        //Task 02
        public static string GetGoldenBooks(BookShopContext context)
        {
            StringBuilder output = new StringBuilder();

            context.Books
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList()
                .ForEach(t => output.AppendLine(t));
         
            return output.ToString().TrimEnd();
        }

        //Task 01
        public static string GetBooksByAgeRestriction(BookShopContext context, string ageRestriction)
        {
            StringBuilder output = new StringBuilder();

            AgeRestriction restriction = Enum.Parse<AgeRestriction>(ageRestriction, true);

            context.Books
                .Where(b => b.AgeRestriction == restriction)
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToList()
                .ForEach(t => output.AppendLine(t));          

            return output.ToString().TrimEnd();
        }
    }
}
