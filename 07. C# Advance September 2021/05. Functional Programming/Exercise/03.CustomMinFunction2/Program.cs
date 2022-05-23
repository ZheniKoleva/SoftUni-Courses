using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.CustomMinFunction2
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<IEnumerable<int>, int> findMinNumber = numbers => numbers.Min();

            var numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);                

            Console.WriteLine(findMinNumber(numbers));
        }
    }
}
