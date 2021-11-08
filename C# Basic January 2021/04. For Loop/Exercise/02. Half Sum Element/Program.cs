using System;

namespace _02.HalfSumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int sum = 0;
            int numberMax = int.MinValue;
            for (int i = 0; i < n; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());
                sum += currentNumber;
                if (currentNumber > numberMax)
                {
                    numberMax = currentNumber;
                }
            }

            sum -= numberMax;
            if (numberMax == sum)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {numberMax}");
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {Math.Abs(numberMax -sum)}");
            }
        }
    }
}
