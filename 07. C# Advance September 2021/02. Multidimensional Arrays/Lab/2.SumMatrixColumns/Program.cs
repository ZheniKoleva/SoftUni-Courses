using System;
using System.Linq;

namespace _2.SumMatrixColumns
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

            int[] columnsSum = SumElementsByColumn(matrix);
            Console.WriteLine(string.Join(Environment.NewLine, columnsSum));
        }

        private static int[] SumElementsByColumn(int[,] matrix)
        {
            int[] colsSum = new int[matrix.GetLength(1)];
            
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    colsSum[col] += matrix[row, col];
                }
            }

            return colsSum;
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
               .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();
        }
    }
}
