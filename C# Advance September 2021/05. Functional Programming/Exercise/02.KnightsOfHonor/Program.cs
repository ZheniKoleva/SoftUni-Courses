using System;
using System.Linq;

namespace _02.KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> printNamesWithHonor = x => Console.WriteLine($"Sir {x}");

            Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(printNamesWithHonor);
        }
    }
}
