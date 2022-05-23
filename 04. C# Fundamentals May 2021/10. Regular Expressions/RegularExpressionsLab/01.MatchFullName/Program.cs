using System;
using System.Text.RegularExpressions;

namespace _01.MatchFullName
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\b([A-Z][a-z]{1,} [A-Z][a-z]{1,})\b";

            string input = Console.ReadLine();

            MatchCollection result = Regex.Matches(input, pattern);

            Console.WriteLine(string.Join(' ', result));

            //foreach (Match item in result)
            //{
            //    Console.Write($"{item.Value} ");
            //}
        }
    }
}
