using System;
using System.Collections.Generic;

namespace _07.KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            char[,] board = new char[matrixSize, matrixSize];
            List<int[]> knightsPositions = new List<int[]>();

            FillMatrix(board, knightsPositions);
            List<int[]> possibleMoves = GetPossibleMoves();

            bool isAttacked = true;
            int removedKnight = 0;

            while (isAttacked)
            {
                int maxAttackes = 0;
                int[] knightMaxAttackPosition = null;

                foreach (var knight in knightsPositions)
                {
                    int attackes = 0;

                    foreach (var move in possibleMoves)
                    {
                        int newRow = knight[0] + move[0];
                        int newCol = knight[1] + move[1];

                        if (IsValidPosition(board, newRow, newCol) 
                            && board[newRow, newCol].Equals('K'))
                        {
                            attackes++;
                        }
                    }

                    if (attackes > maxAttackes)
                    {
                        maxAttackes = attackes;
                        knightMaxAttackPosition = knight;
                    }

                }

                if (maxAttackes == 0)
                {
                    isAttacked = false;
                }
                else
                {
                    board[knightMaxAttackPosition[0], knightMaxAttackPosition[1]] = 'O';
                    knightsPositions.Remove(knightMaxAttackPosition);
                    removedKnight++;
                }

            }

            Console.WriteLine(removedKnight);
        }

        private static bool IsValidPosition(char[,] board, int row, int col)
        {
            return row >= 0 && row < board.GetLength(0)
                   && col >= 0 && col < board.GetLength(1);
        }      

        private static List<int[]> GetPossibleMoves()
        {
            List<int[]> shiftPositions = new List<int[]>()
            {   
                new int[] { -2, -1 },
                new int[] { -2, 1 },
                new int[] { -1, -2 },
                new int[] { -1, 2 },
                new int[] { 2, -1 },
                new int[] { 2, 1 },
                new int[] { 1, -2 },
                new int[] { 1, 2 },
            };

            return shiftPositions;
        }

        private static void FillMatrix(char[,] board, List<int[]> knightsPositions)
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                char[] rowsChars = Console.ReadLine().ToCharArray(); ;

                for (int col = 0; col < board.GetLength(1); col++)
                {
                    board[row, col] = rowsChars[col];

                    if (board[row, col].Equals('K'))
                    {
                        knightsPositions.Add(new int[] { row, col });
                    }
                }
            }
        }
    }
}
