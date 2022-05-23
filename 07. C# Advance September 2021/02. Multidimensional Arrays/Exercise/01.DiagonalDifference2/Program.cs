using System;
using System.Linq;

namespace _01.DiagonalDifference2
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowColSize = int.Parse(Console.ReadLine());

            int[][] matrix = new int[rowColSize][];
            FillMatrix(matrix);

            Console.WriteLine(GetDiagonalsDifference(matrix));
        }


        private static int GetDiagonalsDifference(int[][] matrix)
        {
            int leftDiagonal = 0;
            int rightDiagonal = 0;

            for (int row = 0; row < matrix.Length; row++)
            {
                leftDiagonal += matrix[row][row];
                rightDiagonal += matrix[matrix.Length - 1 - row][row];
            }

            return Math.Abs(leftDiagonal - rightDiagonal);
        }

        private static void FillMatrix(int[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = ReadData();               
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
