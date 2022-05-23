using System;
using System.Text.RegularExpressions;

namespace _01.ExtractPersonInformation
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string input = Console.ReadLine();

                Console.WriteLine(ExtractInformation(input));
            }
        }

        private static string ExtractInformation(string input)
        {
            string namePattern = @"\@(?<name>[A-za-z]+)\|";
            Match firstMatch = Regex.Match(input, namePattern);
            string name = firstMatch.Groups["name"].Value;

            string agePattern = @"\#(?<age>\d+)\*";
            Match secondMatch = Regex.Match(input, agePattern);
            string age = secondMatch.Groups["age"].Value;

            return $"{name} is {age} years old.";
        }
    }
}
