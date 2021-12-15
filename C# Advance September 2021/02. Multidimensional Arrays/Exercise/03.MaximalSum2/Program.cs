using System;
using System.Linq;

namespace _03.MaximalSum2
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] matrixSize = ReadData();
            int rows = matrixSize[0];           

            int[][] matrix = new int[rows][];
            FillMatrix(matrix);

            int maxSum = int.MinValue;
            int[] coordinates = FindMatrixWithMaxSum(matrix, ref maxSum);

            Console.WriteLine($"Sum = {maxSum}");
            PrintSubmatrix(matrix, coordinates);

        }

        private static void PrintSubmatrix(int[][] matrix, int[] coordinates)
        {
            for (int i = coordinates[0]; i < coordinates[0] + 3; i++)
            {
                for (int j = coordinates[1]; j < coordinates[1] + 3; j++)
                {
                    Console.Write($"{matrix[i][j]} ");
                }

                Console.WriteLine();
            }
        }

        private static int[] FindMatrixWithMaxSum(int[][] matrix, ref int maxSum)
        {
            int[] coordinates = new int[2];

            for (int row = 0; row < matrix.Length - 2; row++)
            {
                for (int col = 0; col < matrix[row].Length - 2; col++)
                {
                    int currentSum = FindSubmatrixSum(matrix, row, col);

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        coordinates[0] = row;
                        coordinates[1] = col;
                    }

                }
            }

            return coordinates;
        }

        private static int FindSubmatrixSum(int[][] matrix, int row, int col)
        {
            int currentSum = 0;

            for (int i = row; i < row + 3; i++)
            {
                for (int j = col; j < col + 3; j++)
                {
                    currentSum += matrix[i][j];
                }
            }

            return currentSum;
        }

        private static void FillMatrix(int[][] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
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
