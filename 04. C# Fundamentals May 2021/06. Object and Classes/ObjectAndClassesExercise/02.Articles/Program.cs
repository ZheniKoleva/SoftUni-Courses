using System;

namespace _02.Articles
{
    class Program
    {
        static void Main(string[] args)
        {   
            Article article = ReadArticle();

            int corectionsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < corectionsCount; i++)
            {
                CorrectArticle(article);
            }

            Console.WriteLine(article);  
        }

        private static void CorrectArticle(Article article)
        {
                string[] data = Console.ReadLine()
                 .Split(": ", StringSplitOptions.RemoveEmptyEntries);

                string command = data[0];
                string newData = data[1];

                switch (command)
                {
                    case "Edit":
                        article.Edit(newData);
                        break;

                    case "ChangeAuthor":
                        article.ChangeAuthor(newData);
                        break;

                    case "Rename":
                        article.Rename(newData);
                        break;
                }
            
        }

        private static Article ReadArticle()
        {
            string[] input = Console.ReadLine()
                 .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            string title = input[0];
            string content = input[1];
            string author = input[2];

            return new Article(title, content, author);
        }
    }

    public class Article
    {
        private string title;

        private string content;

        private string author;

        public Article(string articleName, string content, string authorName)
        {
            Title = articleName;
            Content = content;
            Author = authorName;
        }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public void Edit(string newContent)
        {
            Content = newContent;
        }

        public void ChangeAuthor(string newAuthor)
        {
            Author = newAuthor;
        }

        public void Rename(string newTitle)
        {
            Title = newTitle;
        }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }

    }
}
