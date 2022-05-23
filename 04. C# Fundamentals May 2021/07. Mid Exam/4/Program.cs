using System;
using System.Collections.Generic;
using System.Linq;

namespace _3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int entryPoint = int.Parse(Console.ReadLine());
            string typeItems = Console.ReadLine();

            int leftSum = 0;
            int rightSum = 0;
            int entryElement = input[entryPoint];

            if (typeItems == "cheap")
            {                
                leftSum = CalculateCheapSum(input, 0, entryPoint, entryElement);
                rightSum = CalculateCheapSum(input, entryPoint + 1, input.Length, entryElement);
            }
            else if (typeItems == "expensive")
            {
                leftSum = CalculateExpensiveSum(input, 0, entryPoint, entryElement);
                rightSum = CalculateExpensiveSum(input, entryPoint + 1, input.Length, entryElement);
            }

            if (leftSum >= rightSum )
            {
                Console.WriteLine($"Left - {leftSum}");
            }
            else
            {
                Console.WriteLine($"Right - {rightSum}");
            }         


          
        }

        private static int CalculateExpensiveSum(int[] input, int startIndx, int endIndx, int element)
        {
            int sum = 0;

            for (int i = startIndx; i < endIndx; i++)
            {
                if (input[i] >= element)
                {
                    sum += input[i];
                }
            }

            return sum;
        }

        private static int CalculateCheapSum(int[] input, int startIndx, int endIndx, int element)
        {
            int sum = 0;            

            for (int i = startIndx; i < endIndx; i++)
            {
                if (input[i] < element)
                {
                    sum += input[i];
                }
            }

            return sum;
        }
    }
}