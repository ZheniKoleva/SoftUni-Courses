using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.MatchPhoneNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(\+359)(\s|-)[2]\2\d{3}\2\d{4}\b";

            string input = Console.ReadLine();

            //MatchCollection result = Regex.Matches(input, pattern);

            string[] result = Regex.Matches(input, pattern)
                .Select(x => x.Value)
                .ToArray();


            Console.WriteLine(string.Join(", ", result));
        }
    }
}
