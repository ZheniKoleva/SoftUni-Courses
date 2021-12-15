using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Warships
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            int[] coordinates = Console.ReadLine()
               .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

            char[,] field = new char[fieldSize, fieldSize];
            int shipsPlayerOne = 0;
            int shipsPlayerTwo = 0;
            FillMatrix(field, ref shipsPlayerOne, ref shipsPlayerTwo);

            int destroedShips = 0;
            
            bool isOneWon = false;
            bool isTwoWon = false;

            for (int i = 0; i < coordinates.Length; i += 2)
            {
                int attackRow = coordinates[i];
                int attackCol = coordinates[i + 1];

                if (!IsValidCoordinates(field, attackRow, attackCol)
                    || field[attackRow, attackCol].Equals('*'))
                {
                    continue;
                }

                char currentChar = field[attackRow, attackCol];
                field[attackRow, attackCol] = 'X';

                switch (currentChar)
                {
                    case '<':                        
                        shipsPlayerOne--;
                        destroedShips++;
                        break;

                    case '>':                        
                        shipsPlayerTwo--;
                        destroedShips++;
                        break;

                    case '#':                        
                        ExplodeMine(field, attackRow, attackCol, 
                            ref shipsPlayerOne, ref shipsPlayerTwo, ref destroedShips);
                        break;
                }


                if (shipsPlayerOne <= 0)
                {
                    isTwoWon = true;
                    break;
                }
                else if (shipsPlayerTwo <= 0)
                {
                    isOneWon = true;
                    break;
                }
               
            }

            if (isOneWon)
            {
                Console.WriteLine($"Player One has won the game! {destroedShips} ships have been sunk in the battle.");
            }
            else if (isTwoWon)
            {
                Console.WriteLine($"Player Two has won the game! {destroedShips} ships have been sunk in the battle.");
            }
            else
            {
                Console.WriteLine($"It's a draw! Player One has {shipsPlayerOne} ships left. Player Two has {shipsPlayerTwo} ships left.");
            }

        }

        private static void ExplodeMine(char[,] field, int attackRow, int attackCol, ref int shipsPlayerOne, ref int shipsPlayerTwo, ref int destroedShips)
        {
            List<int[]> shifts = GetShifts();

            foreach (var shift in shifts)
            {
                int newRow = attackRow + shift[0];
                int newCol = attackCol + shift[1];

                if (!IsValidCoordinates(field, newRow, newCol) 
                    || field[newRow, newCol].Equals('*')
                    || field[newRow, newCol].Equals('#')
                    || field[newRow, newCol] .Equals('X'))
                {
                    continue;
                }

                if (field[newRow, newCol].Equals('<'))
                {
                    shipsPlayerOne--;
                   
                }
                else if (field[newRow, newCol].Equals('>'))
                {
                    shipsPlayerTwo--;
                }

                field[newRow, newCol] = 'X';
                destroedShips++;
            }
        }

        private static List<int[]> GetShifts()
        {
            List<int[]> shifts = new List<int[]>()
            {
                new int[2] { -1, -1},
                new int[2] { -1, 0},
                new int[2] { -1, 1},
                new int[2] { 0, 1},
                new int[2] { 1, 1},
                new int[2] { 1, 0},
                new int[2] { 1, -1},
                new int[2] { 0, -1}
            };

            return shifts;
        }

        private static bool IsValidCoordinates(char[,] field, int row, int col)
        {
            return row >= 0 && row < field.GetLength(0)
                && col >= 0 && col < field.GetLength(1);
        }

        private static void FillMatrix(char[,] field, ref int shipsPlayerOne, ref int shipsPlayerTwo)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                char[] chars = Console.ReadLine()
                        .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(char.Parse)
                        .ToArray();

                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = chars[col];

                    if (field[row, col].Equals('<'))
                    {
                        shipsPlayerOne++;
                    }
                    else if (field[row, col].Equals('>'))
                    {
                        shipsPlayerTwo++;
                    }
                }

            }

        }
    }
}
