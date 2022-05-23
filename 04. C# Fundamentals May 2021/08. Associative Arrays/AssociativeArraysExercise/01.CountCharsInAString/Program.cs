using System;
using System.Collections.Generic;

namespace _01.CountCharsInAString
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<char, int> result = new Dictionary<char, int>();

            foreach (char symbol in input)
            {
                if (char.IsWhiteSpace(symbol))
                {
                    continue;
                }

                if (!result.ContainsKey(symbol))
                {
                    result.Add(symbol, 0);
                }

                result[symbol]++;
            }

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
