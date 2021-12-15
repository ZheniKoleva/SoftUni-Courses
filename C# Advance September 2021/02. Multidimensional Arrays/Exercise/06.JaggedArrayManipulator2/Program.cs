using System;
using System.Linq;

namespace _06.JaggedArrayManipulator2
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowsCount = int.Parse(Console.ReadLine());

            double[][] matrix = new double[rowsCount][];
            FillMatrix(matrix);
            ManipulateMatrixValues(matrix);

            string line;

            while ((line = Console.ReadLine()) != "End")
            {
                string[] data = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string command = data[0];
                int row = int.Parse(data[1]);
                int col = int.Parse(data[2]);
                int value = int.Parse(data[3]);

                if (IsIndexesValid(matrix, row, col))
                {
                    switch (command)
                    {
                        case "Add":
                            matrix[row][col] += value;
                            break;

                        case "Subtract":
                            matrix[row][col] -= value;
                            break;
                    }
                }
            }

            PrintMatrix(matrix);
        }

        private static void PrintMatrix(double[][] matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(' ', row));
            }
        }

        private static bool IsIndexesValid(double[][] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.Length
                   && col >= 0 && col < matrix[row].Length;
        }

        private static void ManipulateMatrixValues(double[][] matrix)
        {
            for (int row = 0; row < matrix.Length - 1; row++)
            {
                if (matrix[row].Length == matrix[row + 1].Length)
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        matrix[row][col] *= 2;
                        matrix[row + 1][col] *= 2;
                    }

                    continue;
                }

                for (int i = row; i <= row + 1; i++)
                {
                    for (int j = 0; j < matrix[i].Length; j++)
                    {
                        matrix[i][j] /= 2;
                    }
                }
            }
        }

        private static void FillMatrix(double[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = ReadData();
            }
        }

        private static double[] ReadData()
        {
            return Console.ReadLine()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .Select(double.Parse)
               .ToArray();
        }
    }
}

