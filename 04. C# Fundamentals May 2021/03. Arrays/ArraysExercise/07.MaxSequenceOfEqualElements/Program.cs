using System;
using System.Linq;

namespace _07.MaxSequenceOfEqualElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int maxSequence = 0;
            int element = 0;

            for (int i = 0; i < array.Length; i++)
            {
                int currentNum = array[i];
                int longestSequence = 1;

                for (int j = i + 1; j < array.Length; j++)
                {
                    if (currentNum != array[j])
                    {
                        break;
                    }
                    
                    longestSequence++;
                }

                if (longestSequence > maxSequence)
                {
                    maxSequence = longestSequence;
                    element = currentNum;
                }
            }

            int[] result = new int[maxSequence];

            for (int i = 0; i < maxSequence; i++)
            {
                result[i] = element;
            }

            Console.WriteLine(string.Join(' ', result));

        }
    }
}
