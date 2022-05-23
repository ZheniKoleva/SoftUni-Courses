using System;
using System.Linq;

namespace _07.EqualArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

            int[] numbers2 = Console.ReadLine()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();
           
            int diffIndx = 0;
            bool areIdentical = true;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] != numbers2[i])
                {
                    areIdentical = false;
                    diffIndx = i;
                    break;
                }
            }

            if (areIdentical)
            {
                int sum = numbers.Sum();

                Console.WriteLine($"Arrays are identical. Sum: {sum}");
            }
            else
            {
                Console.WriteLine($"Arrays are not identical. Found difference at {diffIndx} index");
            }

        }        
    }
}
