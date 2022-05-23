using System;
using System.Linq;

namespace _05.SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = ReadData();
            int rows = matrixSize[0];
            int cols = matrixSize[1];

            char[,] matrix = new char[rows, cols];
            string snake = Console.ReadLine();
            FillMatrix(matrix, snake);

            PrintMatrix(matrix);
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        private static void FillMatrix(char[,] matrix, string input)
        {
            int startIndx = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {    
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (row % 2 == 0)
                    {
                        matrix[row, col] = input[startIndx++];
                    }
                    else
                    {
                        matrix[row, matrix.GetLength(1) - 1 - col] = input[startIndx++];
                    }

                    if (startIndx >= input.Length)
                    {
                        startIndx = 0;
                    }                    
                }
            }
        }

        private static int[] ReadData()
        {
            return Console.ReadLine()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();
        }
    }
}
