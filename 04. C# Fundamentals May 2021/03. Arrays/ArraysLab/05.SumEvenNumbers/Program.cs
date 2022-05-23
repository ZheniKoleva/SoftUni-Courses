using System;
using System.Linq;

namespace _05.SumEvenNumbers
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

            //int sumOfEvens = 0;
            //for (int i = 0; i < numbers.Length; i++)
            //{
            //    if (numbers[i] % 2 == 0)
            //    {
            //        sumOfEvens += numbers[i];
            //    }
            //}

            Console.WriteLine(sumOfEvens);

        }
    }
}
