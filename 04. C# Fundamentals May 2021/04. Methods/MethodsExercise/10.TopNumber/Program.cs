using System;

namespace _10.TopNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 0; i < number; i++)
            {
                if(IsTopNumber(i))
                {
                    Console.WriteLine(i);
                }
            }

        }

        private static bool IsTopNumber(int number)
        {
            return IsDivisibleByNumber(number) && HasOddDigit(number);
        }

        private static bool HasOddDigit(int number)
        {
            bool hasOddDigit = false;

            while (number > 0)
            {
                if ((number % 10) % 2 == 1)
                {
                    hasOddDigit = true;
                    break;
                }                
                number /= 10;
            }

            return hasOddDigit;

        }

        private static bool IsDivisibleByNumber(int number, int divider = 8)
        {
            int sumOfDigits = 0;

            while (number > 0)
            {
                sumOfDigits += number % 10;
                number /= 10;
            }

            return sumOfDigits % divider == 0;
        }
    }
}
