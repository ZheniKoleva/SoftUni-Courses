using System;
using System.Linq;

namespace _06.EqualSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            bool hasEqualNum = false;
            int specialIndx = 0;

            for (int i = 0; i < array.Length; i++)
            {
                int leftSum = 0;
                int rightSum = 0; 
               
                for (int leftIndexes = i - 1; leftIndexes >= 0; leftIndexes--)
                {
                    leftSum += array[leftIndexes];
                }

                for (int rightIndexes = i + 1; rightIndexes < array.Length; rightIndexes++)
                {
                    rightSum += array[rightIndexes];
                }

                if (leftSum == rightSum)
                {                   
                    hasEqualNum = true;
                    specialIndx = i;
                    break;
                }
            }

            if (hasEqualNum)
            {
                Console.WriteLine(specialIndx);
            }
            else
            {
                Console.WriteLine("no");
            }

        }
    }
}
