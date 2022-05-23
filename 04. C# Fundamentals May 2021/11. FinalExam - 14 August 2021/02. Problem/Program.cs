using System;
using System.Text.RegularExpressions;

namespace _02._Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(U\$)(?<username>[A-Z][a-z]{2,})\1(P\@\$)(?<password>[A-Za-z]{5,}\d+)\2";

            int linesCount = int.Parse(Console.ReadLine());

            int successfulRegs = 0;

            for (int i = 0; i < linesCount; i++)
            {
                string input = Console.ReadLine();

                Match result = Regex.Match(input, pattern);

                if (!result.Success)
                {
                    Console.WriteLine("Invalid username or password");
                    continue;
                }

                Console.WriteLine("Registration was successful");
                Console.WriteLine($"Username: {result.Groups["username"].Value}, Password: {result.Groups["password"].Value}");

                successfulRegs++;
            }

            Console.WriteLine($"Successful registrations: {successfulRegs}");

        }
    }
}
