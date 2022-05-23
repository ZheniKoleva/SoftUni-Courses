using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Articles2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int articlesCount = int.Parse(Console.ReadLine());

            List<Article> articles = new List<Article>(articlesCount);

            for (int i = 0; i < articlesCount; i++)
            {
                Article current = ReadArticle();
                articles.Add(current);
            }

            string criteria = Console.ReadLine();

            PrintArticles(articles, criteria);

        }

        private static void PrintArticles(List<Article> articles, string criteria)
        {   
            switch (criteria)
            {
                case "title":
                   articles = articles.OrderBy(a => a.Title).ToList();
                    break;

                case "content":
                    articles = articles.OrderBy(a => a.Content).ToList();
                    break;

                case "author":
                    articles = articles.OrderBy(a => a.Author).ToList();
                    break;                
            }

            Console.WriteLine(string.Join(Environment.NewLine, articles));
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

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }

    }
}
