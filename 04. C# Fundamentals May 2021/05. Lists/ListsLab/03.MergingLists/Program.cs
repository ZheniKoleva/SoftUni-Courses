using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MergingLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> first = FillList();
            List<int> second = FillList();

            int rotation = Math.Max(first.Count, second.Count);
            List<int> result = CombineLists(first, second, rotation);

            Console.WriteLine(string.Join(' ', result));               
        }

        private static List<int> CombineLists(List<int> first, List<int> second, int rotation)
        {
            List<int> result = new List<int>(first.Count + second.Count);

            for (int i = 0; i < rotation; i++)
            {
                if (i < first.Count)
                {
                    result.Add(first[i]);
                }

                if (i < second.Count)
                {
                    result.Add(second[i]);
                }
            }

            return result;
        }

        private static List<int> FillList()
        {
            return Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
        }
    }
}
