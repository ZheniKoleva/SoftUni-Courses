using System;

namespace _08.LettersChangeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine($"{GetSum(input):f2}");            
        }

        private static double GetSum(string[] input)
        {
            double sum = 0;

            foreach (var item in input)
            {
                char firstLetter = item[0];
                char secondLetter = item[item.Length - 1]; //item[^1];
                double digit = double.Parse(item.Substring(1, item.Length - 2));  //item[1..^1]

                sum += CalculateCurrentResult(firstLetter, secondLetter, digit);
            }

            return sum;
        }

        private static double CalculateCurrentResult(char firstLetter, char secondLetter, double digit)
        {
            double currentSum = 0;

            int positionFirst = GetPosition(firstLetter);
            int positionSecond = GetPosition(secondLetter);

            if (char.IsUpper(firstLetter))
            {
                currentSum += digit / positionFirst;
            }
            else
            {
                currentSum += digit * positionFirst;
            }

            if (char.IsUpper(secondLetter))
            {
                currentSum -= positionSecond;
            }
            else
            {
                currentSum += positionSecond;
            }

            return currentSum;
        }

        private static int GetPosition(char letter)
        {
            if (char.IsUpper(letter))
            {
                return letter - 64;
            }

            return letter - 96;
        }
    }
}
