using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.PrintEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> numbers = new Queue<int>(ReadData());

            Console.WriteLine(string.Join(", ", numbers));
        }

        private static IEnumerable<int> ReadData()
        {
            return Console.ReadLine()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .Where(x => x % 2 == 0);
        }
    }
}
