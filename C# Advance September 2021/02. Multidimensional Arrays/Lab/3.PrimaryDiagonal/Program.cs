using System;
using System.Linq;

namespace _3.PrimaryDiagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowsColsSize = int.Parse(Console.ReadLine());

            int[,] matrix = new int[rowsColsSize, rowsColsSize];
            FillMatrix(matrix);

            int diagonalSum = SumElementsByDiagonal(matrix);
            Console.WriteLine(diagonalSum);
        }

        private static int SumElementsByDiagonal(int[,] matrix)
        {
            int sum = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {     
                   sum += matrix[i, i];
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
               .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();
        }
    }
}
