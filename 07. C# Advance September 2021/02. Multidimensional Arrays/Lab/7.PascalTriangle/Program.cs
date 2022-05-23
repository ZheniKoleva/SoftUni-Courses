using System;

namespace _7.PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            long[][] pascal = new long[rows][];
            FillMatrix(pascal);
            PrintMatrix(pascal);
        }

        private static void PrintMatrix(long[][] matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(' ', row));
            }
        }

        private static void FillMatrix(long[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = new long[row + 1];
                matrix[row][0] = 1;
                matrix[row][^1] = 1;

                for (int col = 1; col < matrix[row].Length - 1; col++)
                {
                    matrix[row][col] = matrix[row - 1][col - 1] + matrix[row - 1][col];
                }
            }
        }
    }
}
