using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tokens = ReadData().ToArray();

            int numbersToPop = tokens[1];
            int numberToCheck = tokens[2];

            Queue<int> numbers = new Queue<int>(ReadData());

            for (int i = 0; i < numbersToPop; i++)
            {
                if (!numbers.Any())
                {
                    break;
                }

                numbers.Dequeue();
            }

            if (numbers.Contains(numberToCheck))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(numbers.Count != 0 ? numbers.Min() : 0);
            }

        }

        private static IEnumerable<int> ReadData()
        {
            return Console.ReadLine()
                          .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                          .Select(int.Parse);
        }

    }
}

