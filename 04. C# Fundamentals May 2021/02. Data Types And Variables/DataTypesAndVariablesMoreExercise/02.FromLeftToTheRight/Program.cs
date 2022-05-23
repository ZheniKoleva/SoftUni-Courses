using System;

namespace _02.FromLeftToTheRight
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                int sumOfDigits = 0;

                string[] numbers = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                long leftNum = long.Parse(numbers[0]);
                long rightNum = long.Parse(numbers[1]);

                long bigger = Math.Max(leftNum, rightNum);

                sumOfDigits = GetSum(bigger);

                //if (leftNum > rightNum)
                //{
                //    sumOfDigits = GetSum(leftNum);
                //}
                //else
                //{
                //    sumOfDigits = GetSum(rightNum);
                //}

                Console.WriteLine(sumOfDigits);

            }
        }

        private static int GetSum(long number)
        {
            int sum = 0;
            number = Math.Abs(number);

            while (number > 0)
            {
                sum += (int)(number % 10);
                number /= 10;
            }

            return sum;
        }
    }
}
