using System;
using System.Linq;

namespace _06.EvenAndOddSubtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

            int sumOfEvens = numbers
                .Where(x => x % 2 == 0)
                .Sum();

            int sumOfOdd = numbers
                .Where(x => x % 2 == 1)
                .Sum();

            int difference = sumOfEvens - sumOfOdd;

            Console.WriteLine(difference);

        }
    }
}
