using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _2.RageQuit
{
    class Program
    {
        static void Main(string[] args)
        {
            string symbolsPattern = @"[\D]+";
            string digitsPattern = @"[\d]+";
            //string pattern = @"[\D]+\d+";

            string input = Console.ReadLine();

            string[] symbols = Regex.Matches(input, symbolsPattern)
                .Select(x => x.Value)
                .ToArray();

            int[] digits = Regex.Matches(input, digitsPattern)
                .Select(x => int.Parse(x.Value))
                .ToArray();

            StringBuilder result = new StringBuilder();
           
            for (int i = 0; i < symbols.Length; i++)
            {
                string currentString = symbols[i].ToUpper();
                int repeatTimes = digits[i];

                for (int j = 0; j < repeatTimes; j++)
                {
                    result.Append(currentString);
                }
            }

            int uniqueSymbols = result.ToString().Distinct().Count();

            Console.WriteLine($"Unique symbols used: {uniqueSymbols}");

            Console.WriteLine(result);

        }
    }
}
