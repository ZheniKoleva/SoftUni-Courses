using System;

namespace _10.OddEvenSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int currentNumber = 0;
            int sumEven = 0;
            int sumOdd = 0;

            for (int i = 1; i <= n; i++)
            {
                currentNumber = int.Parse(Console.ReadLine());
                if (i % 2 == 0)
                {
                    sumEven += currentNumber;
                }
                else
                {
                    sumOdd += currentNumber;
                }

            }

            if (sumEven == sumOdd)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {sumEven}");
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {Math.Abs(sumEven - sumOdd)}");
            }
        }
    }
}
