using System;
using System.Text.RegularExpressions;

namespace _03.MatchDates
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\b(?<day>\d{2})(?<separator>(\.|\-|\/))(?<month>[A-Z][a-z]{2})\1(?<year>\d{4})\b";

            string input = Console.ReadLine();

            MatchCollection result = Regex.Matches(input, pattern);

            foreach (Match item in result)
            {
                Console.WriteLine($"Day: {item.Groups["day"].Value}, Month: {item.Groups["month"].Value}, Year: {item.Groups["year"].Value}");
            }

        }
    }
}
