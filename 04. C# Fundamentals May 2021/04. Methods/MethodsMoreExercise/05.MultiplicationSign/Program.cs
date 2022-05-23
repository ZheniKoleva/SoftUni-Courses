using System;
using System.Linq;

namespace _05.MultiplicationSign
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int third = int.Parse(Console.ReadLine());

            Console.WriteLine(GetProductSign(first, second, third));
        }

        private static string GetProductSign(int first, int second, int third)
        {
            int[] numbers = { first, second, third };           

            if (numbers.Contains(0))
            {
                return "zero";
            }

            int negativeDigitsCount = numbers
                .Where(x => x < 0)
                .Count();

            //int negativeDigitsCount = 0;

            //for (int i = 0; i < numbers.Length; i++)
            //{
            //    if (numbers[i] < 0)
            //    {
            //        negativeDigitsCount++;
            //    }
            //}

            if (negativeDigitsCount % 2 == 1)
            {
                return "negative";
            }
            else
            {
                return "positive";
            }
            
        }
    }
}
