using System;
using System.Linq;

namespace _04.Largest3Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .OrderByDescending(x => x)
                .Take(3)
                .ToArray();

            Console.WriteLine(string.Join(' ', input));

            //Console.WriteLine(string.Join(" ", Console.ReadLine()
            //    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            //    .Select(int.Parse)
            //    .OrderByDescending(x => x)
            //    .Take(3)
            //    .ToArray()));

        }
    }
}
