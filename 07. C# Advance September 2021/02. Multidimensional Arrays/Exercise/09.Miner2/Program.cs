using System;
using System.Linq;

namespace _09.Miner2
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldRows = int.Parse(Console.ReadLine());
            string[] directions = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            char[][] field = new char[fieldRows][];
            int[] playerPosition = new int[2];
            int coalsHave = 0;

            FillMatrix(field, playerPosition, ref coalsHave);

            int coalsCollected = 0;
            bool isGameOver = false;
            bool isAllCoalsCollected = false;

            foreach (var direction in directions)
            {
                ChangePosition(field, playerPosition, direction);

                if (field[playerPosition[0]][playerPosition[1]].Equals('e'))
                {
                    isGameOver = true;
                    break;
                }
                else if (field[playerPosition[0]][playerPosition[1]].Equals('c'))
                {
                    coalsCollected++;
                    field[playerPosition[0]][playerPosition[1]] = '*';

                    if (coalsCollected == coalsHave)
                    {
                        isAllCoalsCollected = true;
                        break;
                    }
                }
            }

            if (isGameOver)
            {
                Console.WriteLine($"Game over! ({playerPosition[0]}, {playerPosition[1]})");
            }
            else if (isAllCoalsCollected)
            {
                Console.WriteLine($"You collected all coals! ({playerPosition[0]}, {playerPosition[1]})");
            }
            else
            {
                int remainingCoals = coalsHave - coalsCollected;
                Console.WriteLine($"{remainingCoals} coals left. ({playerPosition[0]}, {playerPosition[1]})");
            }

        }

        private static void ChangePosition(char[][] field, int[] playerPosition, string direction)
        {
            if (direction.Equals("up"))
            {
                playerPosition[0] = playerPosition[0] - 1 >= 0
                    ? playerPosition[0] - 1
                    : playerPosition[0];
            }
            else if (direction.Equals("down"))
            {
                playerPosition[0] = playerPosition[0] + 1 < field.Length
                    ? playerPosition[0] + 1
                    : playerPosition[0];
            }
            else if (direction.Equals("left"))
            {
                playerPosition[1] = playerPosition[1] - 1 >= 0
                    ? playerPosition[1] - 1
                    : playerPosition[1];
            }
            else if (direction.Equals("right"))
            {
                playerPosition[1] = playerPosition[1] + 1 < field[playerPosition[0]].Length
                    ? playerPosition[1] + 1
                    : playerPosition[1];
            }
        }

        private static void FillMatrix(char[][] field, int[] playerPosition, ref int coalsHave)
        {
            for (int row = 0; row < field.Length; row++)
            {
                field[row] = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                coalsHave += field[row].Where(x => x.Equals('c')).Count();

                int playerCol = Array.IndexOf(field[row], 's');

                if (playerCol > -1)
                {
                    playerPosition[0] = row;
                    playerPosition[1] = playerCol;
                }

            }
        }
    }
}

