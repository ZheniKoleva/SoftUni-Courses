using System;
using System.Linq;

namespace _6.JaggedArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] matrix = new int[rows][];
            FillMatrix(matrix);

            string line;

            while ((line = Console.ReadLine()) != "END")
            {
                string[] data = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string command = data[0];
                int row = int.Parse(data[1]);
                int col = int.Parse(data[2]);
                int value = int.Parse(data[3]);

                if (!IsValidIndexes(matrix, row, col))
                {
                    Console.WriteLine("Invalid coordinates");
                    continue;
                }

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

            PrintMatrix(matrix);

        }

        private static void PrintMatrix(int[][] matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(' ', row));
            }
        }

        private static bool IsValidIndexes(int[][] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.Length
                 && col >= 0 && col < matrix[row].Length;
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
