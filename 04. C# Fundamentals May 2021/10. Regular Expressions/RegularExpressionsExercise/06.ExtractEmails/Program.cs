using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _06.ExtractEmails
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(?<=\s)(?<user>[A-Za-z\d]+[\.\-_]*([A-Za-z\d]+)*)\@(?<host>([A-Za-z]+[\-]*[A-Za-z]){1,}(\.[A-Za-z]+){1,})";

            string input = Console.ReadLine();

            List<string> result = Regex.Matches(input, pattern)
                .Cast<Match>()
                .Select(x => x.Value.ToString())
                .ToList();

            //MatchCollection result = Regex.Matches(input, pattern);

            Console.WriteLine(string.Join(Environment.NewLine, result));
        }
    }
}
