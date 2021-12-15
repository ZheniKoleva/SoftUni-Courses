using System;
using System.Linq;

namespace _5.SquareWithMaximumSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = ReadData();
            int rowsCount = matrixSize[0];
            int colsCount = matrixSize[1];

            int[,] matrix = new int[rowsCount, colsCount];
            FillMatrix(matrix);

            Tuple<int, int[]> subMatrixCoordinates = FindSubmatrixWithMaxSum(matrix);

            PrintSubMatrix(matrix, subMatrixCoordinates.Item2);
            Console.WriteLine(subMatrixCoordinates.Item1);
        }

        private static void PrintSubMatrix(int[,] matrix, int[] coordinates)
        {
            for (int row = coordinates[0]; row < coordinates[0] + 2; row++)
            {
                for (int col = coordinates[1]; col < coordinates[1] + 2; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }

                Console.WriteLine();
            }
        }

        private static Tuple<int, int[]> FindSubmatrixWithMaxSum(int[,] matrix)
        {
            int subMatrixSum = int.MinValue;
            int[] coordinates = new int[2];

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) -  1; col++)
                {
                    int currentSum = matrix[row, col] + matrix[row, col + 1] +
                                   matrix[row + 1, col] + matrix[row + 1, col + 1];

                    if (currentSum > subMatrixSum)
                    {
                        subMatrixSum = currentSum;
                        coordinates[0] = row;
                        coordinates[1] = col;
                    }
                }
            }

            return new Tuple<int, int[]>(subMatrixSum, coordinates);
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
               .Split(", ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();
        }
    }
}
