using System;

namespace _02.SuperMario
{
    class Program
    {
        static void Main(string[] args)
        {
            int marioLives = int.Parse(Console.ReadLine());
            int mazeRows = int.Parse(Console.ReadLine());

            char[][] maze = new char[mazeRows][];

            int marioRow = -1;
            int marioCol = -1;
            FillMatrix(maze, ref marioRow, ref marioCol);

            bool isDead = false;

            while (!isDead)
            {
                string[] tokens = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                char direction = char.Parse(tokens[0]);
                int bowserRow = int.Parse(tokens[1]);
                int bowserCol = int.Parse(tokens[2]);

                maze[bowserRow][bowserCol] = 'B';
                maze[marioRow][marioCol] = '-';
                marioLives--;

                if (direction == 'W')
                {
                    marioRow = marioRow - 1 >= 0
                        ? marioRow - 1
                        : marioRow;
                }
                else if (direction == 'S')
                {
                    marioRow = marioRow + 1 < maze.Length
                        ? marioRow + 1
                        : marioRow;
                }
                else if (direction == 'A')
                {
                    marioCol = marioCol - 1 >= 0
                        ? marioCol - 1
                        : marioCol;
                }
                else if (direction == 'D')
                {
                    marioCol = marioCol + 1 < maze[marioRow].Length
                        ? marioCol + 1
                        : marioCol;
                }

                if (maze[marioRow][marioCol] == 'B')
                {
                    marioLives -= 2;

                    if (marioLives <= 0)
                    {
                        maze[marioRow][marioCol] = 'X';
                        isDead = true;
                        break;
                    }

                    maze[marioRow][marioCol] = 'M';
                }
                else if (maze[marioRow][marioCol] == 'P')
                {
                    maze[marioRow][marioCol] = '-';
                    break;
                }
                else
                {
                    maze[marioRow][marioCol] = 'M';
                }

                if (marioLives <= 0)
                {
                    maze[marioRow][marioCol] = 'X';
                    isDead = true;
                }
            }

            Console.WriteLine(isDead 
                ? $"Mario died at {marioRow};{marioCol}."
                : $"Mario has successfully saved the princess! Lives left: {marioLives}");

            PrintMatrix(maze);
        }

        private static void PrintMatrix(char[][] maze)
        {
            foreach (var row in maze)
            {
                Console.WriteLine(string.Join("", row));
            }
        }

        private static void FillMatrix(char[][] maze, ref int marioRow, ref int marioCol)
        {
            for (int row = 0; row < maze.Length; row++)
            {
                maze[row] = Console.ReadLine().ToCharArray();

                int positionCol = Array.IndexOf(maze[row], 'M');

                if (positionCol > -1)
                {
                    marioRow = row;
                    marioCol = positionCol;
                }
            }
        }
    }
}
