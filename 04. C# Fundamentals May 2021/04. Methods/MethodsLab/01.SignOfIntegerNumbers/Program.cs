using System;

namespace _01.SignOfIntegerNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine(GetSign(number));
        }

        private static string GetSign(int number)
        {
            string result = string.Empty;

            if (number > 0)
            {
                result = "positive";
            }
            else if (number < 0)
            {
                result = "negative";
            }
            else
            {
                result = "zero";
            }

            return $"The number {number} is {result}.";
        }
    }
}
