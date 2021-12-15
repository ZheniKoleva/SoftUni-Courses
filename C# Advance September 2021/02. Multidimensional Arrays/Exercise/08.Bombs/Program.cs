using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            int[,] matrix = new int[matrixSize, matrixSize];
            FillMatrix(matrix);

            List<int[]> possibleMoves = GetPossibleMoves();

            string bombInput = Console.ReadLine();
            List<int[]> bombs = GetBombsCoordinates(bombInput);
            
            foreach (var bomb in bombs)
            {                
                if (IsValidCoordinates(matrix, bomb[0], bomb[1]))
                {
                    int bombPower = matrix[bomb[0], bomb[1]];

                    if (bombPower > 0)
                    {
                        ExplodeBombs(matrix, possibleMoves, bomb[0], bomb[1]);
                        matrix[bomb[0], bomb[1]] = 0;
                    }
                }
            }

            int aliveCellsCount = 0;
            int aliveCellsSum = CalculateAliveCellsSum(matrix, ref aliveCellsCount);

            Console.WriteLine($"Alive cells: {aliveCellsCount}");
            Console.WriteLine($"Sum: {aliveCellsSum}");

            PrintMatrix(matrix);
        }

        private static int CalculateAliveCellsSum(int[,] matrix, ref int aliveCellsCount)
        {
            int sum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        sum += matrix[row, col];
                        aliveCellsCount++;
                    }
                }
            }

            return sum;
        }

        private static List<int[]> GetBombsCoordinates(string bombInput)
        {
            List<int[]> bombs = new List<int[]>();

            string[] data = bombInput
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in data)
            {
                int[] coordinates = item
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                bombs.Add(coordinates);
            }

            return bombs;
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }

                Console.WriteLine();
            }
        }

        private static void ExplodeBombs(int[,] matrix, List<int[]> possibleMoves, int row, int col)
        {
            int bombValue = matrix[row, col];

            foreach (var move in possibleMoves)
            {
                int newRow = row + move[0];
                int newCol = col + move[1];

                if (IsValidCoordinates(matrix, newRow, newCol)
                    && matrix[newRow, newCol] > 0)
                {
                    matrix[newRow, newCol] -= bombValue;
                }
            }
            
        }

        private static List<int[]> GetPossibleMoves()
        {
            List<int[]> shiftPositions = new List<int[]>()
            {
                new int[] {-1, -1},
                new int[] { -1, 0 },
                new int[] { -1, 1 },
                new int[] { 0, -1 },
                new int[] { 0, 1 },
                new int[] { 1, -1 },
                new int[] { 1, 0 },
                new int[] { 1, 1 },
            };

            return shiftPositions;
        }

        private static bool IsValidCoordinates(int[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0)
                   && col >= 0 && col < matrix.GetLength(1);
        }

        private static void FillMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowNumbers = ReadData();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowNumbers[col];
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
