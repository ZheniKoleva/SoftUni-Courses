using System;

namespace _04.PrintingTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            PrintingTriangle(number);

        }

        private static void PrintingTriangle(int number)
        {
            for (int row = 1; row <= number; row++)
            {
                PrintLine(row);
            }

            for (int row = number - 1; row >= 0; row--)
            {
                PrintLine(row);
            }
            
        }

        private static void PrintLine(int end, int start = 1)
        {
            for (int column = start; column <= end; column++)
            {
                Console.Write($"{column} ");
            }
            Console.WriteLine();        
        }
    }
}
