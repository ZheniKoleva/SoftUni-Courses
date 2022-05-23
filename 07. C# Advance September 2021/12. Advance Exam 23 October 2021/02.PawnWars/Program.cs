using System;

namespace _02.PawnWars
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

                if ((IsValidIndex(field, whiteRow - 1, whiteCol - 1)
                    && field[whiteRow - 1][whiteCol - 1] == field[blackRow][blackCol])
                    || (IsValidIndex(field, whiteRow - 1, whiteCol + 1)
                    && field[whiteRow - 1][whiteCol + 1] == field[blackRow][blackCol]))
                {
                    isWhiteWon = true;
                    field[whiteRow - 1][blackCol] = 'w';
                    Console.WriteLine($"Game over! White capture on {(Column)blackCol}{(field.Length - blackRow)}.");
                    break;
                }               

                whiteRow--;

                if (whiteRow == 0)
                {
                    Console.WriteLine($"Game over! White pawn is promoted to a queen at {(Column)whiteCol}{field.Length - whiteRow}.");
                    break;
                }

                field[whiteRow][whiteCol] = 'w';

                field[blackRow][blackCol] = '-';

                if ((IsValidIndex(field, blackRow + 1, blackCol - 1) 
                    && field[blackRow + 1][blackCol - 1] == field[whiteRow][whiteCol])
                    || ( IsValidIndex(field, blackRow + 1, blackCol + 1)
                    && field[blackRow + 1][blackCol + 1] == field[whiteRow][whiteCol]))
                {
                    isBlackWon = true;
                    field[blackRow + 1][whiteCol] = 'b';
                    Console.WriteLine($"Game over! Black capture on {(Column)whiteCol}{field.Length - whiteRow}.");
                    break;
                }

                blackRow++;

                if (blackRow == field.Length - 1)
                {
                    Console.WriteLine($"Game over! Black pawn is promoted to a queen at {(Column)blackCol}{field.Length - blackRow}.");
                    break;
                }
                field[blackRow][blackCol] = 'b';
            }
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
