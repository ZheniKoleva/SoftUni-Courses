using System;

namespace _02.PawnWars2
{
    class Program
    {
        static void Main(string[] args)
        {

            char[][] field = new char[8][];
            int blackRow = -1;
            int blackCol = -1;

            int whiteRow = -1;
            int whiteCol = -1;

            bool isWhiteWon = false;
            bool isBlackWon = false;

            FillMatrix(field, ref blackRow, ref blackCol, ref whiteCol, ref whiteRow);

            while (!isWhiteWon || !isBlackWon)
            {
                field[whiteRow][whiteCol] = '-';
                whiteRow--;

                isWhiteWon = CheckIfWin(field, whiteRow, whiteCol, blackRow, blackCol);

                if (isWhiteWon)
                {
                    field[whiteRow][blackCol] = 'w';
                    Console.WriteLine($"Game over! White capture on {(Column)blackCol}{(field.Length - blackRow)}.");
                    break;
                }
                else if (whiteRow == 0)
                {
                    Console.WriteLine($"Game over! White pawn is promoted to a queen at {(Column)whiteCol}{field.Length - whiteRow}.");
                    break;
                }

                field[whiteRow][whiteCol] = 'w';

                field[blackRow][blackCol] = '-';
                blackRow++;

                isBlackWon = CheckIfWin(field, blackRow, blackCol, whiteRow, whiteCol);

                if (isBlackWon)
                {
                    field[blackRow][whiteCol] = 'b';
                    Console.WriteLine($"Game over! Black capture on {(Column)whiteCol}{field.Length - whiteRow}.");
                    break;
                }
                else if (blackRow == field.Length - 1)
                {
                    Console.WriteLine($"Game over! Black pawn is promoted to a queen at {(Column)blackCol}{field.Length - blackRow}.");
                    break;
                }

                field[blackRow][blackCol] = 'b';
            }
        }

        private static bool CheckIfWin(char[][] field, int ownRow, int ownCol, int opponentRow, int opponentCol)
        {

            return (ownCol - 1 >= 0 && field[ownRow][ownCol - 1] == field[opponentRow][opponentCol])
                || (ownCol + 1 < field[ownRow].Length && field[ownRow][ownCol + 1] == field[opponentRow][opponentCol]);

        }

        private static bool IsValidIndex(char[][] field, int row, int col)
        {
            return row >= 0 && row < field.Length
                && col >= 0 && col < field[row].Length;
        }

        private static void FillMatrix(char[][] field, ref int blackRow, ref int blackCol, ref int whiteCol, ref int whiteRow)
        {
            for (int row = 0; row < field.Length; row++)
            {
                field[row] = Console.ReadLine().ToCharArray();

                int blackIndx = Array.IndexOf(field[row], 'b');
                int whiteIndx = Array.IndexOf(field[row], 'w');

                if (blackIndx > -1)
                {
                    blackRow = row;
                    blackCol = blackIndx;
                }

                if (whiteIndx > -1)
                {
                    whiteRow = row;
                    whiteCol = whiteIndx;
                }
            }
        }
    }

    public enum Column
    {
        a = 0,
        b = 1,
        c = 2,
        d = 3,
        e = 4,
        f = 5,
        g = 6,
        h = 7
    }
}

