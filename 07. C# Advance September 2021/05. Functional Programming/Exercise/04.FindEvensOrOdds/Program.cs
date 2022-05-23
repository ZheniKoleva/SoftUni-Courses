using System;
using System.Collections;
using System.Linq;

namespace _04.FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] limits = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int lower = limits[0];
            int upper = limits[1];
            int count = (upper - lower) + 1;

            var digits = Enumerable.Range(lower, count);
            Predicate<int> isEven = x => x % 2 == 0;

            string type = Console.ReadLine();

            var filtered = type.Equals("even")
                ? digits.Where(x => isEven(x))
                : digits.Where(x => !isEven(x));

            Console.WriteLine(string.Join(' ', filtered));
        }
    }
}
