using System;

namespace _02.Selling
{
    class Program
    {
        static void Main(string[] args)
        {
            int bakerySize = int.Parse(Console.ReadLine());

            char[,] bakery = new char[bakerySize, bakerySize];
            int playerRow = -1;
            int playerCol = -1;            
            FillMatrix(bakery, ref playerRow, ref playerCol);

            bool isInBakery = true;
            int money = 0;

            while (isInBakery && money < 50)
            {
                string direction = Console.ReadLine();

                bakery[playerRow, playerCol] = '-';
                GetNewPosition(direction, ref playerRow, ref playerCol);

                if (!IsValidPosition(bakery, playerRow, playerCol))
                {
                    isInBakery = false;
                    break;
                }

                if (char.IsDigit(bakery[playerRow, playerCol]))
                {
                    money += bakery[playerRow, playerCol] - '0';
                    bakery[playerRow, playerCol] = 'S';
                }
                else if (bakery[playerRow, playerCol].Equals('O'))
                {
                    bakery[playerRow, playerCol] = '-';
                    JumpToNextPillar(bakery, ref playerRow, ref playerCol);
                }
            }

           Console.WriteLine(!isInBakery 
               ? "Bad news, you are out of the bakery."
               : "Good news! You succeeded in collecting enough money!");

            Console.WriteLine($"Money: {money}");

            PrintMatrix(bakery);

        }

        private static void PrintMatrix(char[,] bakery)
        {
            for (int row = 0; row < bakery.GetLength(0); row++)
            {
                for (int col = 0; col < bakery.GetLength(1); col++)
                {
                    Console.Write(bakery[row, col]);
                }

                Console.WriteLine();
            }
        }

        private static void JumpToNextPillar(char[,] bakery, ref int playerRow, ref int playerCol)
        {
            for (int row = 0; row < bakery.GetLength(0); row++)
            {
                for (int col = 0; col < bakery.GetLength(1); col++)
                {
                    if (bakery[row, col].Equals('O'))
                    {
                        playerRow = row;
                        playerCol = col;
                        bakery[row, col] = 'S';
                        return;
                    }
                }
            }
        }

        private static bool IsValidPosition(char[,] bakery, int row, int col)
        {
            return row >= 0 && row < bakery.GetLength(0)
                && col >= 0 && col < bakery.GetLength(1);
        }

        private static void GetNewPosition(string direction, ref int row, ref int col)
        {
            switch (direction)
            {
                case "up":
                    row--;
                    break;
                case "down":
                    row++;
                    break;
                case "left":
                    col--;
                    break;
                case "right":
                    col++;
                    break;
            }
        }

        private static void FillMatrix(char[,] bakery, ref int playerRow, ref int playerCol)
        {
            for (int row = 0; row < bakery.GetLength(0); row++)
            {
                char[] chars = Console.ReadLine().ToCharArray();

                for (int col = 0; col < bakery.GetLength(1); col++)
                {
                    bakery[row, col] = chars[col];

                    if (bakery[row, col].Equals('S'))
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }
        }
    }
}
