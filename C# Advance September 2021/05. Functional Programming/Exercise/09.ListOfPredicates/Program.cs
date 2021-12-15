using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int upperBound = int.Parse(Console.ReadLine());
            HashSet<int> deviders = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToHashSet();           

            Func<int, HashSet<int>, bool> isDevisible = (number, deviders) =>
            {
                foreach (var devider in deviders)
                {
                    if (number % devider != 0)
                    {
                        return false;
                    }                    
                }

                return true;
            };

            var numbers = Enumerable.Range(1, upperBound)
                .Where(x => isDevisible(x, deviders));

            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}
