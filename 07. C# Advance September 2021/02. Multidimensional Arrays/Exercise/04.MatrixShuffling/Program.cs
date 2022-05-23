using System;
using System.Linq;

namespace _04.MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = ReadData();
            int rows = matrixSize[0];
            int cols = matrixSize[1];

            string[,] matrix = new string[rows, cols];
            FillMatrix(matrix);

            string line;

            while ((line = Console.ReadLine()) != "END")
            {
                string[] data = line
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (IsValidInput(data))
                {
                    int firstRow = int.Parse(data[1]);
                    int firstCol = int.Parse(data[2]);
                    int secondRow = int.Parse(data[3]);
                    int secondCol = int.Parse(data[4]);

                    if (IsValidIndexes(matrix, firstRow, firstCol)
                        && IsValidIndexes(matrix, secondRow, secondCol))
                    {
                        SwapIndexes(matrix, firstRow, firstCol, secondRow, secondCol);
                        PrintMatrix(matrix);
                        continue;
                    }                                   
                }

                Console.WriteLine("Invalid input!");
            }
        }

        private static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }

        private static void SwapIndexes(string[,] matrix, int firstRow, int firstCol, int secondRow, int secondCol)
        {
            string temp = matrix[firstRow, firstCol];
            matrix[firstRow, firstCol] = matrix[secondRow, secondCol];
            matrix[secondRow, secondCol] = temp;
        }

        private static bool IsValidInput(string[] data)
        {
            return data.Length == 5 && data[0].Equals("swap");
        }

        private static bool IsValidIndexes(string[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0)
                 && col >= 0 && col < matrix.GetLength(1);
        }

        private static void FillMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] rowsChars = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

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
