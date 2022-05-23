using System;
using System.Linq;

namespace _10.LadyBugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());

            int[] initialIndexes = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            bool[] field = FillIndexes(initialIndexes, fieldSize);

            string line = Console.ReadLine();

            while (line != "end")
            {
                string[] parts = line
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                int startIndx = int.Parse(parts[0]);
                string direction = parts[1];
                int flyLength = int.Parse(parts[2]);                

                if (!IsIndxInTheField(startIndx, field)
                    || !HasLadyBug(field, startIndx)
                    || flyLength == 0)
                {
                    line = Console.ReadLine();
                    continue;
                }

                int endIndx = 0;

                if (direction == "right")
                {
                    endIndx = startIndx + flyLength;
                }
                else
                {
                    endIndx = startIndx - flyLength;
                }

                if (!IsIndxInTheField(endIndx, field))
                {
                    field[startIndx] = false; //калинката отлетя от полето
                    line = Console.ReadLine();
                    continue;
                }

                MoveLadybug(field, startIndx, endIndx, direction, flyLength);

                line = Console.ReadLine();
            }

            int[] result = GetResult(field);
            
            Console.WriteLine(string.Join(' ', result));

        }

        private static void MoveLadybug(bool[] field, int startIndx, int endIndx, string direction, int flyLength)
        {
            bool isFlyAway = false;

            while (HasLadyBug(field, endIndx))
            {
                if (direction == "right")
                {
                    endIndx += flyLength;
                }
                else
                {
                    endIndx -= flyLength;
                }                

                if (!IsIndxInTheField(endIndx, field))
                {
                    field[startIndx] = false; //калинката отлетя от полето
                    isFlyAway = true;
                    break;
                }
            }

            if (!isFlyAway)
            {
                field[startIndx] = false;
                field[endIndx] = true; // калинката кацна
            }
        }

        private static int[] GetResult(bool[] field)
        {
            int[] result = new int[field.Length];

            for (int i = 0; i < field.Length; i++)
            {
                result[i] = field[i] ? 1 : 0;
            }

            return result;
        }


        private static bool HasLadyBug(bool[] field, int startIndx)
        {
            return field[startIndx];
        }


        private static bool IsIndxInTheField(int startIndx, bool[] field)
        {
            return startIndx >= 0 && startIndx < field.Length;
        }


        private static bool[] FillIndexes(int[] initialIndexes, int fieldSize)
        {
            bool[] field = new bool[fieldSize];

            for (int i = 0; i < initialIndexes.Length; i++)
            {
                int indxNum = initialIndexes[i];

                if (indxNum < 0 || indxNum >= field.Length)
                {
                    continue;
                }

                field[indxNum] = true;
            }

            return field;
        }
    }
}
