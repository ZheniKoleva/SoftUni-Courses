using System;
using System.Linq;

namespace _1.SumMatrixElements
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

            int sum = SumMatrixElements(matrix);

            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));
            Console.WriteLine(sum);
        }

        private static int SumMatrixElements(int[,] matrix)
        {
            int sum = 0;

            foreach (var item in matrix)
            {
                sum += item;
            }

            return sum;
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
