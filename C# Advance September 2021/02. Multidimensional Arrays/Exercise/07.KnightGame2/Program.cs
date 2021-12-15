using System;
using System.Collections.Generic;

namespace _07.KnightGame2
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            char[,] board = new char[matrixSize, matrixSize];
            List<Knight> knightsPositions = new List<Knight>();

            FillMatrix(board, knightsPositions);
            List<int[]> possibleMoves = GetPossibleMoves();

            bool isAttacked = true;
            int removedKnight = 0;

            while (isAttacked)
            {
                int maxAttackes = 0;
                Knight knightMaxAttackes = null;

                foreach (var knight in knightsPositions)
                {
                    knight.Attackes = 0;

                    foreach (var move in possibleMoves)
                    {
                        int newRow = knight.Row + move[0];
                        int newCol = knight.Col + move[1];

                        if (IsValidPosition(board, newRow, newCol)
                            && board[newRow, newCol].Equals('K'))
                        {
                            knight.Attackes++;
                        }
                    }

                    if (knight.Attackes > maxAttackes)
                    {
                        maxAttackes = knight.Attackes;
                        knightMaxAttackes = knight;
                    }

                }

                if (maxAttackes == 0)
                {
                    isAttacked = false;
                }
                else
                {
                    board[knightMaxAttackes.Row, knightMaxAttackes.Col] = 'O';
                    knightsPositions.Remove(knightMaxAttackes);
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

        private static void FillMatrix(char[,] board, List<Knight> knightsPositions)
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                char[] rowsChars = Console.ReadLine().ToCharArray(); ;

                for (int col = 0; col < board.GetLength(1); col++)
                {
                    board[row, col] = rowsChars[col];

                    if (board[row, col].Equals('K'))
                    {
                        knightsPositions.Add(new Knight(row, col));
                    }
                }
            }
        }
    }

    public class Knight
    {
        public Knight(int row, int col)
        {
            Row = row;
            Col = col;
            Attackes = 0;
        }

        public int Row { get; set; }

        public int Col { get; set; }

        public int Attackes { get; set; }
    }
}
