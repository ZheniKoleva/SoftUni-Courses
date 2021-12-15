using System;
using System.Linq;

namespace _02.Survivor
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            char[][] beach = new char[rows][];
            FillMatrix(beach);

            int collectedTokens = 0;
            int opponentTokens = 0;

            string line;

            while ((line = Console.ReadLine()) != "Gong")
            {
                string[] data = line
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string command = data[0];
                int row = int.Parse(data[1]);
                int col = int.Parse(data[2]);

                if (!IsValidIndexes(beach, row, col))
                {
                    continue;
                }

                switch (command)
                {
                    case "Find":
                        if (beach[row][col].Equals('T'))
                        {
                            collectedTokens++;
                            beach[row][col] = '-';
                        }
                        break;

                    case "Opponent":
                        string direction = data[3];

                        if (beach[row][col].Equals('T'))
                        {
                            opponentTokens++;
                            beach[row][col] = '-';
                        }

                        for (int i = 0; i < 3; i++)
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

                            if (IsValidIndexes(beach, row, col)
                                && beach[row][col].Equals('T'))
                            {
                                opponentTokens++;
                                beach[row][col] = '-';
                            }

                        }                       
                        break;
                }
            }

            PrintMatrix(beach);
            Console.WriteLine($"Collected tokens: {collectedTokens}");
            Console.WriteLine($"Opponent's tokens: {opponentTokens}");
        }       

        private static void PrintMatrix(char[][] matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(' ', row));
            }
        }

        private static bool IsValidIndexes(char[][] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.Length
                 && col >= 0 && col < matrix[row].Length;
        }

        private static void FillMatrix(char[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
            }
        }
    }
}
