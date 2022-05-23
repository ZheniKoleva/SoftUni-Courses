using System;
using System.Linq;

namespace _02.SumDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            //int number = int.Parse(Console.ReadLine());

            //int sum = GetSumOfDigits(number);

            int sum = Console.ReadLine()
                .Select(x => int.Parse(x.ToString()))
                .Sum();

            Console.WriteLine(sum);
        }

        private static int GetSumOfDigits(int number)
        {
            int sum = 0;

            while (number > 0)
            {
                sum += number % 10;
                number /= 10;
            }

            return sum;
        }
    }
}
