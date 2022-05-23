using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CountRealNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            SortedDictionary<double, int> result = new SortedDictionary<double, int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (!result.ContainsKey(numbers[i]))
                {
                    result.Add(numbers[i], 0);
                }

                result[numbers[i]]++;
            }

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
