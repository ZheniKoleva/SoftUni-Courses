using System;

namespace _02.Re_Volt
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowsCount = int.Parse(Console.ReadLine());
            int commandsCount = int.Parse(Console.ReadLine());

            char[][] field = new char[rowsCount][];
            int playerRow = -1;
            int playerCol = -1;
            FillMatrix(field, ref playerRow, ref playerCol);

            bool isWon = false;           
            string direction;
            int currentCommand = 0;

            while (!isWon && currentCommand < commandsCount)
            {
                field[playerRow][playerCol] = '-';

                currentCommand++;
                direction = Console.ReadLine();

                MovePlayerForward(field, ref playerRow, ref playerCol, direction);

                if (field[playerRow][playerCol].Equals('B'))
                {
                    MovePlayerForward(field, ref playerRow, ref playerCol, direction);
                }

                if (field[playerRow][playerCol].Equals('T'))
                {
                    MovePlayerBackward(field, ref playerRow, ref playerCol, direction);
                }

                if (field[playerRow][playerCol] == 'F')
                {
                    field[playerRow][playerCol] = 'f';
                    isWon = true;
                }

                field[playerRow][playerCol] = 'f';                
            }

            Console.WriteLine(isWon ? "Player won!" : "Player lost!");
            PrintField(field);
        }

        private static void PrintField(char[][] field)
        {
            foreach (var row in field)
            {
                Console.WriteLine(string.Join("", row));
            }
        }

        private static void MovePlayerBackward(char[][] field, ref int playerRow, ref int playerCol, string direction)
        {
            switch (direction)
            {
                case "up":
                    playerRow++;
                    if (playerRow >= field.Length)
                    {
                        playerRow = 0;
                    }
                    break;
                case "down":
                    playerRow--;
                    if (playerRow < 0)
                    {
                        playerRow = field.Length - 1;
                    }
                    break;
                case "left":
                    playerCol++;
                    if (playerCol >= field[playerRow].Length)
                    {
                        playerCol = 0;
                    }
                    break;
                case "right":
                    playerCol--;
                    if (playerCol < 0)
                    {
                        playerCol = field[playerRow].Length - 1;
                    }
                    break;
            }
        }

        private static void MovePlayerForward(char[][] field, ref int playerRow, ref int playerCol, string direction)
        {
            switch (direction)
            {
                case "up":
                    playerRow--;

                    if (playerRow < 0)
                    {
                        playerRow = field.Length - 1;
                    }
                    break;

                case "down":
                    playerRow++;

                    if (playerRow >= field.Length)
                    {
                        playerRow = 0;
                    }
                    break;

                case "left":
                    playerCol--;

                    if (playerCol < 0)
                    {
                        playerCol = field[playerRow].Length - 1;
                    }
                    break;

                case "right":
                    playerCol++;

                    if (playerCol >= field[playerRow].Length)
                    {
                        playerCol = 0;
                    }
                    break;

            }
        }

        private static void FillMatrix(char[][] field, ref int playerRow, ref int playerCol)
        {
            for (int row = 0; row < field.Length; row++)
            {
                field[row] = Console.ReadLine().ToCharArray();

                int playerPosition = Array.IndexOf(field[row], 'f');

                if (playerPosition > -1)
                {
                    playerRow = row;
                    playerCol = playerPosition;
                }
            }
        }
    }
}
