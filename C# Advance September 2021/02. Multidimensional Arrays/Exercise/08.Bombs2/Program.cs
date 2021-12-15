using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Bombs2
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            int[][] matrix = new int[matrixSize][];
            FillMatrix(matrix);

            List<int[]> possibleMoves = GetPossibleMoves();

            string bombInput = Console.ReadLine();
            List<int[]> bombs = GetBombsCoordinates(bombInput);

            foreach (var bomb in bombs)
            {
                if (IsValidCoordinates(matrix, bomb[0], bomb[1]))
                {
                    int bombPower = matrix[bomb[0]][bomb[1]];

                    if (bombPower > 0)
                    {
                        ExplodeBombs(matrix, possibleMoves, bomb[0], bomb[1]);
                        matrix[bomb[0]][ bomb[1]] = 0;
                    }
                }
            }

            int aliveCellsCount = 0;
            int aliveCellsSum = 0;

            foreach (var row in matrix)
            {
                aliveCellsSum += row.Where(x => x > 0).Sum();
                aliveCellsCount += row.Where(x => x > 0).Count();
            }

            Console.WriteLine($"Alive cells: {aliveCellsCount}");
            Console.WriteLine($"Sum: {aliveCellsSum}");

            PrintMatrix(matrix);
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

        private static void PrintMatrix(int[][] matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(' ', row));
            }            
        }

        private static void ExplodeBombs(int[][] matrix, List<int[]> possibleMoves, int row, int col)
        {
            int bombValue = matrix[row][col];

            foreach (var move in possibleMoves)
            {
                int newRow = row + move[0];
                int newCol = col + move[1];

                if (IsValidCoordinates(matrix, newRow, newCol)
                    && matrix[newRow][newCol] > 0)
                {
                    matrix[newRow][newCol] -= bombValue;
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

        private static bool IsValidCoordinates(int[][] matrix, int row, int col)
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
