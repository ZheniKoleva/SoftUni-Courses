using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizeOfSets = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            HashSet<string> first = FillSet(sizeOfSets[0]);
            HashSet<string> second = FillSet(sizeOfSets[1]);
            Console.WriteLine(string.Join(' ', first.Intersect(second)));
        }

        private static HashSet<string> FillSet(int lines)
        {
            HashSet<string> digits = new HashSet<string>();

            for (int i = 0; i < lines; i++)
            {
                digits.Add(Console.ReadLine());
            }

            return digits;
        }
    }
}
