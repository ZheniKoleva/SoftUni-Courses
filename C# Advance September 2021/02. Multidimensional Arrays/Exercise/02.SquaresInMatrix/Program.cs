using System;
using System.Linq;

namespace _02.SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = ReadData();
            int rows = matrixSize[0];
            int cols = matrixSize[1];

            char[,] matrix = new char[rows, cols];
            FillMatrix(matrix);

            int submatrixCount = FindMatrixWithEqualsChars(matrix);
            Console.WriteLine(submatrixCount);

        }

        private static int FindMatrixWithEqualsChars(char[,] matrix)
        {
            int count = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    char currentChar = matrix[row, col];

                    if (currentChar.Equals(matrix[row, col + 1]) 
                        && currentChar.Equals(matrix[row + 1, col])
                        && currentChar.Equals(matrix[row + 1, col + 1]))
                    {
                        count++;
                    }
                }
            }

            return count;

        }

        private static void FillMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] rowsChars = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowsChars[col];
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
