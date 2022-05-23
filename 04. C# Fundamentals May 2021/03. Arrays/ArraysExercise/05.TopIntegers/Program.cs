using System;
using System.Linq;

namespace _05.TopIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < array.Length; i++)
            {
                bool isTopNumber = true;
                int currentNum = array[i];

                for (int j = i + 1; j < array.Length; j++)
                {
                    if (currentNum <= array[j])
                    {
                        isTopNumber = false;
                        break;
                    }

                }

                if (isTopNumber)
                {
                    Console.Write($"{currentNum} ");
                }

            }

        }
    }
}
