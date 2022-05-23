using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.MixedUpLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> first = ReadInput();
            List<int> second = ReadInput();

            List<int> combined = FillList(first, second);
            int[] interval = first.Count > 0 ? first.ToArray() : second.ToArray();
            Array.Sort(interval);

            List<int> result = combined
                .Where(x => x > interval[0] && x < interval[1])
                .OrderBy(x => x)
                .ToList();

            Console.WriteLine(string.Join(' ', result));
        }

        private static List<int> FillList(List<int> first, List<int> second)
        {
            List<int> result = new List<int>();

            int limit = Math.Min(first.Count, second.Count);

            for (int i = 0; i < limit; i++)
            {
                result.Add(first[0]);
                result.Add(second[second.Count - 1]);
                first.RemoveAt(0);
                second.RemoveAt(second.Count - 1);
            }

            return result;
        }

        private static List<int> ReadInput()
        {
            return Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
        }
    }
}
