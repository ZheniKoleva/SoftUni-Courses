using System;
using System.Collections.Generic;
using System.Text;

namespace _05.HTML
{
    class Program
    {
        static void Main(string[] args)
        {
            string titleOfArticle = Console.ReadLine();
            string contentOfArticle = Console.ReadLine();

            StringBuilder article = new StringBuilder();

            article.AppendLine($"<h1>\n\t{titleOfArticle}\n</h1>");
            article.AppendLine($"<article>\n\t{contentOfArticle}\n</article>");

            string comment = Console.ReadLine();

            while (comment != "end of comments")
            {
                article.AppendLine($"<div>\n\t{comment}\n</div>");

                comment = Console.ReadLine();
            }

            Console.WriteLine(article.ToString().TrimEnd());
        }

    }
}
