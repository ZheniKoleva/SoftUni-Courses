using System;
using System.Linq;

namespace _01.DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowColSize = int.Parse(Console.ReadLine());

            int[,] matrix = new int[rowColSize, rowColSize];
            FillMatrix(matrix);
            
            Console.WriteLine(GetDiagonalsDifference(matrix));
        }

        private static int GetDiagonalsDifference(int[,] matrix)
        {
            int leftDiagonal = 0;
            int rightDiagonal = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
               leftDiagonal += matrix[row, row];
               rightDiagonal += matrix[matrix.GetLength(0) - 1 - row, row];
            }

            return Math.Abs(leftDiagonal - rightDiagonal);
        }

        private static void FillMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowsNumbers = ReadData();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowsNumbers[col];
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
