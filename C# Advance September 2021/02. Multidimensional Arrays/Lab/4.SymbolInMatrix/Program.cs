using System;

namespace _4.SymbolInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowsColsSize = int.Parse(Console.ReadLine());

            char[,] matrix = new char[rowsColsSize, rowsColsSize];
            FillMatrix(matrix);

            char symbolToSearch = char.Parse(Console.ReadLine());           
            Console.WriteLine(FindSymbolCoordinates(matrix, symbolToSearch));
        }

        private static string FindSymbolCoordinates(char[,] matrix, char symbolToSearch)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col].Equals(symbolToSearch))
                    {
                        return $"({row}, {col})";
                    }
                }
            }

            return $"{symbolToSearch} does not occur in the matrix";
        }

        private static void FillMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] rowsNumbers = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowsNumbers[col];
                }
            }
        }        
    }
}
