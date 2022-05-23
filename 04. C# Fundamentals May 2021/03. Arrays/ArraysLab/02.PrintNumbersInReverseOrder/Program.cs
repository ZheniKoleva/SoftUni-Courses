using System;

namespace _02.PrintNumbersInReverseOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberCount = int.Parse(Console.ReadLine());

            int[] numbers = new int[numberCount];

            for (int i = 0; i < numberCount; i++)
            {
                numbers[numbers.Length - 1 - i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}
