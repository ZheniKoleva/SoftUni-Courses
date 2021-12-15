using System;

namespace _02.Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            char[,] matrix = new char[matrixSize, matrixSize];
            int snakeRow = -1;
            int snakeCol = -1;
            FillMatrix(matrix, ref snakeRow, ref snakeCol);

            int foodNeeded = 10;
            int foodEaten = 0;
            bool isOutOfTheMatrix = false;            

            while (foodEaten < foodNeeded)
            {
                string direction = Console.ReadLine();

                matrix[snakeRow, snakeCol] = '.';
                MoveSnake(direction, ref snakeRow, ref snakeCol);

                if (!IsValidPosition(matrix, snakeRow, snakeCol))
                {
                    isOutOfTheMatrix = true;
                    break;
                }

                if (matrix[snakeRow, snakeCol].Equals('B'))
                {
                    matrix[snakeRow, snakeCol] = '.';
                    JumpToOtherBurrow(matrix, ref snakeRow, ref snakeCol);
                }
                else if (matrix[snakeRow, snakeCol].Equals('*'))
                {
                    foodEaten++;
                }

                matrix[snakeRow, snakeCol] = 'S';
            }

            if (isOutOfTheMatrix)
            {
                Console.WriteLine("Game over!");
            }
            else if (foodEaten >= foodNeeded)
            {
                Console.WriteLine("You won! You fed the snake.");
            }

            Console.WriteLine($"Food eaten: {foodEaten}");
            PrintMatrix(matrix);
        }

        private static void JumpToOtherBurrow(char[,] matrix, ref int snakeRow, ref int snakeCol)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col].Equals('B'))
                    {
                        snakeRow = row;
                        snakeCol = col;
                    }
                }
            }
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        private static bool IsValidPosition(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0)
                && col >= 0 && col < matrix.GetLength(1);
        }

        private static void MoveSnake(string direction, ref int snakeRow, ref int snakeCol)
        {
            switch (direction)
            {
                case "up":
                    snakeRow--;
                    break;
                case "down":
                    snakeRow++;
                    break;
                case "left":
                    snakeCol--;
                    break;
                case "right":
                    snakeCol++;
                    break;
            }
        }

        private static void FillMatrix(char[,] matrix, ref int snakeRow, ref int snakeCol)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] chars = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = chars[col];

                    if (matrix[row, col].Equals('S'))
                    {
                        snakeRow = row;
                        snakeCol = col;
                    }
                }
            }
        }
    }
}

