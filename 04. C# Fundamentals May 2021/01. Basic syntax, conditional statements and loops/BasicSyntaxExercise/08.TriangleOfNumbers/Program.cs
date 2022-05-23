using System;

namespace _08.TriangleOfNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int row = 1; row <= number; row++)
            {
                for (int column = 1; column <= row; column++)
                {
                    Console.Write($"{row} ");
                }

                Console.WriteLine();
            }
        }
    }
}
