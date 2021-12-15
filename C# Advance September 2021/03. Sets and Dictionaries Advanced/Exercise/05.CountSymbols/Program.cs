using System;
using System.Collections.Generic;

namespace _05.CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            SortedDictionary<char, int> charsOccurances = FillDigits(input);

            PrintChars(charsOccurances);            
        }

        private static void PrintChars(SortedDictionary<char, int> charsOccurances)
        {
            foreach (var (chars, occuarances) in charsOccurances)
            {
                Console.WriteLine($"{chars}: {occuarances} time/s");
            }
        }

        private static SortedDictionary<char, int> FillDigits(string input)
        {
            SortedDictionary<char, int> chars = new SortedDictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {  
                if (!chars.ContainsKey(input[i]))
                {
                    chars.Add(input[i], 0);
                }

                chars[input[i]]++;
            }

            return chars;
        }
    }
}
