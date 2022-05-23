using System;

namespace _07.NxNMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            PrintMatrix(number);
        }

        private static void PrintMatrix(int number)
        {
            int[] numbersArray = FillArray(number);

            for (int row = 0; row < number; row++)
            {                
                Console.WriteLine(string.Join(' ', numbersArray));
            }

        }

        private static int[] FillArray(int number)
        {
            int[] numbersArray = new int[number];

            for (int i = 0; i < number; i++)
            {
                numbersArray[i] = number;
            }

            return numbersArray;
        }
    }
}
