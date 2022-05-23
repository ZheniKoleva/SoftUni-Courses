using System;

namespace _10.MultiplyEvensByOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            number = Math.Abs(number);

            Console.WriteLine(GetMultipleOfEvenAnaOdds(number));

        }

        private static int GetMultipleOfEvenAnaOdds(int number)
        {
            return GetSumOfEvenDigits(number) * GetSumOfOddDigits(number);
        }

        private static int GetSumOfEvenDigits(int number)
        {
            int sumEvens = 0;

            while (number > 0)
            {
                int currentDigit = number % 10;

                if (currentDigit % 2 == 0)
                {
                    sumEvens += currentDigit;
                }

                number /= 10;
            }

            return sumEvens;
        }

        private static int GetSumOfOddDigits(int number)
        {
            int sumOdds = 0;

            while (number > 0)
            {
                int currentDigit = number % 10;

                if (currentDigit % 2 == 1)
                {
                    sumOdds += currentDigit;
                }

                number /= 10;
            }

            return sumOdds;
        }
    }
}
