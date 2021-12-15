using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.RadioactiveMutantVampireBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = ReadData();
            int rows = matrixSize[0];
            int cols = matrixSize[1];

            char[,] lair = new char[rows, cols];
            int[] player = new int[2];
            FillMatrix(lair, player);

            bool isWon = false;
            bool isDead = false;

            char[] directions = Console.ReadLine().ToCharArray();

            foreach (var direction in directions)
            {
                lair[player[0], player[1]] = '.';

                int[] newPlayerPosition = GetNewPlayerPosition(player, direction);

                List<int[]> bunnies = FindBunnies(lair);
                SpreadBunnies(lair, bunnies);

                if (!IsValidCoordinates(lair, newPlayerPosition[0], newPlayerPosition[1]))
                {
                    isWon = true;
                    break;
                }
                else if (lair[newPlayerPosition[0], newPlayerPosition[1]] == 'B')
                {
                    isDead = true;
                    player = newPlayerPosition;
                    break;
                }
                else
                {
                    lair[newPlayerPosition[0], newPlayerPosition[1]] = 'P';
                    player = newPlayerPosition;
                }
            }

            PrintLair(lair);

            Console.WriteLine(isWon 
                ? $"won: {player[0]} {player[1]}"
                : $"dead: {player[0]} {player[1]}");
        }

        private static int[] GetNewPlayerPosition(int[] player, char direction)
        {
            int[] newPlayerPosition = new int[] { player[0], player[1] };

            if (direction.Equals('U'))
            {
                newPlayerPosition[0]--;
            }
            else if (direction.Equals('D'))
            {
                newPlayerPosition[0]++;
            }
            else if (direction.Equals('L'))
            {
                newPlayerPosition[1]--;
            }
            else if (direction.Equals('R'))
            {
                newPlayerPosition[1]++;
            }

            return newPlayerPosition;
        }

        private static void PrintLair(char[,] lair)
        {
            for (int row = 0; row < lair.GetLength(0); row++)
            {
                for (int col = 0; col < lair.GetLength(1); col++)
                {
                    Console.Write(lair[row, col]);
                }

                Console.WriteLine();
            }
        }

        private static void SpreadBunnies(char[,] lair, List<int[]> bunnies)
        {
            foreach (var bunny in bunnies)
            {
                int bunnyRow = bunny[0];
                int bunnyCol = bunny[1];

                if (IsValidCoordinates(lair, bunnyRow - 1, bunnyCol))
                {
                    lair[bunnyRow - 1, bunnyCol] = 'B';
                }

                if (IsValidCoordinates(lair, bunnyRow + 1, bunnyCol))
                {
                    lair[bunnyRow + 1, bunnyCol] = 'B';
                }

                if (IsValidCoordinates(lair, bunnyRow, bunnyCol + 1))
                {
                    lair[bunnyRow, bunnyCol + 1] = 'B';
                }

                if (IsValidCoordinates(lair, bunnyRow, bunnyCol - 1))
                {
                    lair[bunnyRow, bunnyCol - 1] = 'B';
                }
            }
        }

        private static bool IsValidCoordinates(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0)
                   && col >= 0 && col < matrix.GetLength(1);
        }

        private static List<int[]> FindBunnies(char[,] lair)
        {
            List<int[]> bunnies = new List<int[]>();

            for (int row = 0; row < lair.GetLength(0); row++)
            {
                for (int col = 0; col < lair.GetLength(1); col++)
                {
                    if (lair[row, col].Equals('B'))
                    {
                        bunnies.Add(new int[] { row, col });
                    }
                }
            }

            return bunnies;
        }

        private static void FillMatrix(char[,] matrix, int[] playerPosition)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] rowsChars = Console.ReadLine().ToCharArray();                    

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowsChars[col];

                    if (matrix[row, col].Equals('P'))
                    {
                        playerPosition[0] = row;
                        playerPosition[1] = col;
                    }
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
