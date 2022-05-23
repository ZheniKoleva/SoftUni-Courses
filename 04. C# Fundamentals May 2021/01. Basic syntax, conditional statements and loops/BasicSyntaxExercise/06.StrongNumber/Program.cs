using System;

namespace _06.StrongNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int sumOfFactorial = 0;
            int currentNum = number;

            while (currentNum > 0)
            {
                int lastDigit = currentNum % 10;

                sumOfFactorial += GetFactorial(lastDigit);

                currentNum /= 10;
            }

            if (sumOfFactorial == number)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }

        private static int GetFactorial(int lastDigit)
        {
            int factorial = 1;

            for (int i = 2; i <= lastDigit; i++)
            {
                factorial *= i;
            }

            return factorial;
        }
    }
}
