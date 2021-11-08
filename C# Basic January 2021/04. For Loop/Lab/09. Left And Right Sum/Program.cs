using System;

namespace _09.LeftAndRightSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int numbers = 0;
            int firstSum = 0;
            int secondSum = 0;

            for (int i = 0; i < n * 2; i++)
            {
                numbers = int.Parse(Console.ReadLine());

                if (i < n)
                {
                    firstSum += numbers;
                }
                else
                {
                    secondSum += numbers;
                }

            }

            if (firstSum == secondSum)
            {
                Console.WriteLine($"Yes, sum = {firstSum}");
            }
            else
            {
                Console.WriteLine($"No, diff = {Math.Abs(firstSum - secondSum)}");
            }
        }
    }
}
