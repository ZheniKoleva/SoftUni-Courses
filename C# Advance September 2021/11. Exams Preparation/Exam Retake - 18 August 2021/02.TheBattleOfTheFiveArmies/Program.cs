using System;

namespace _02.TheBattleOfTheFiveArmies
{
    class Program
    {
        static void Main(string[] args)
        {
            int armyArmor = int.Parse(Console.ReadLine());
            int rowsCount = int.Parse(Console.ReadLine());

            char[][] field = new char[rowsCount][];
            int armyRow = -1;
            int armyCol = -1;
            FillMatrix(field, ref armyRow, ref armyCol);

            bool isWon = false;
            bool isArmyDead = false;

            while (!isWon)
            {
                string[] moveData = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string direction = moveData[0];
                int orcRow = int.Parse(moveData[1]);
                int orcCol = int.Parse(moveData[2]);

                field[orcRow][orcCol] = 'O';
                field[armyRow][armyCol] = '-';
                armyArmor--;  

                if (direction.Equals("up"))
                {
                    armyRow = armyRow - 1 >= 0
                        ? armyRow - 1
                        : armyRow;
                }
                else if (direction.Equals("down"))
                {
                    armyRow = armyRow + 1 < field.Length
                       ? armyRow + 1
                       : armyRow;
                }
                else if (direction.Equals("left"))
                {
                    armyCol = armyCol - 1 >= 0
                        ? armyCol - 1
                        : armyCol;
                }
                else if (direction.Equals("right"))
                {
                    armyCol = armyCol + 1 < field[armyRow].Length
                        ? armyCol + 1
                        : armyCol;
                }                

                if (field[armyRow][armyCol].Equals('O'))
                {
                    armyArmor -= 2;

                    if (armyArmor <= 0)
                    {
                        field[armyRow][armyCol] = 'X';
                        isArmyDead = true;
                        break;
                    }

                    field[armyRow][armyCol] = 'A';

                }
                else if (field[armyRow][armyCol].Equals('M'))
                {
                    field[armyRow][armyCol] = '-';
                    isWon = true;
                }
                else
                {
                    field[armyRow][armyCol] = 'A';
                }

                if (armyArmor == 0)
                {
                    field[armyRow][armyCol] = 'X';
                    isArmyDead = true;
                    break;
                }

            }

            if (isArmyDead)
            {
                Console.WriteLine($"The army was defeated at {armyRow};{armyCol}.");
            }
            else
            {
                Console.WriteLine($"The army managed to free the Middle World! Armor left: {armyArmor}");
            }

            PrintField(field);

        }

        private static void PrintField(char[][] field)
        {
            foreach (var row in field)
            {
                Console.WriteLine(string.Join("", row));
            }
        }

        private static void FillMatrix(char[][] field, ref int armyRow, ref int armyCol)
        {
            for (int row = 0; row < field.Length; row++)
            {
                field[row] = Console.ReadLine().ToCharArray();

                int armyColPosition = Array.IndexOf(field[row], 'A');

                if (armyColPosition > -1)
                {
                    armyRow = row;
                    armyCol = armyColPosition;
                }
            }
        }
    }
}
