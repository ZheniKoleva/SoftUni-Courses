using System;
using System.Linq;

namespace _03.RoundingNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            for(int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == - 0)
                {
                    numbers[i] = 0;
                }
                
                int result = (int) Math.Round(numbers[i], MidpointRounding.AwayFromZero);

                Console.WriteLine($"{numbers[i]} => {result}");
            }
        }
    }
}
