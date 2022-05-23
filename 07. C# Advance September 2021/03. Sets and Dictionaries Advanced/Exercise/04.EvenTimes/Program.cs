using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            Dictionary<int, int> digitsOccurances = FillDigits(lines);

            Console.WriteLine(digitsOccurances.First(x => x.Value % 2 == 0).Key);
        }

        private static Dictionary<int, int> FillDigits(int lines)
        {
            Dictionary<int, int> digits = new Dictionary<int, int>();

            for (int i = 0; i < lines; i++)
            {
                int current = int.Parse(Console.ReadLine());

                if (!digits.ContainsKey(current))
                {
                    digits.Add(current, 0);
                }

                digits[current]++;
            }

            return digits;
        }
    }
}
