using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CountSameValuesInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = ReadData();

            Dictionary<double, int> numbersByCount = new Dictionary<double, int>();
            FillDictionary(numbersByCount, numbers);

            PrintResults(numbersByCount);
        }

        private static double[] ReadData()
        {
            return Console.ReadLine()
                            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                            .Select(double.Parse)
                            .ToArray();
        }

        private static void PrintResults(Dictionary<double, int> numbersByCount)
        {
            foreach (var (number, occurance) in numbersByCount)
            {
                Console.WriteLine($"{number} - {occurance} times");
            }
        }

        private static void FillDictionary(Dictionary<double, int> numbersByCount, double[] numbers)
        {
            foreach (var number in numbers)
            {
                if (!numbersByCount.ContainsKey(number))
                {
                    numbersByCount.Add(number, 0);
                }

                numbersByCount[number]++;
            }
        }
    }
}
