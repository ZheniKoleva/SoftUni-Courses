using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.TheFightForGondor
{
    class Program
    {
        static void Main(string[] args)
        {
            int wavesCount = int.Parse(Console.ReadLine());
            Queue<int> plates = new Queue<int>(ReadData());
            Stack<int> orcs = null;

            for (int wave = 1; wave <= wavesCount; wave++)
            {
                if (!plates.Any())
                {
                    break;
                }

                orcs = new Stack<int>(ReadData());

                if (wave % 3 == 0)
                {
                    plates.Enqueue(int.Parse(Console.ReadLine()));
                }

                while (plates.Any() && orcs.Any())
                {
                    int currentPlate = plates.Dequeue();
                    int currentOrc = orcs.Pop();

                    if (currentPlate > currentOrc)
                    {
                        currentPlate -= currentOrc;

                        Queue<int> temp = new Queue<int>();
                        temp.Enqueue(currentPlate);

                        foreach (var plate in plates)
                        {
                            temp.Enqueue(plate);
                        }

                        plates = temp;

                    }
                    else if (currentOrc > currentPlate)
                    {
                        orcs.Push(currentOrc - currentPlate);
                    }
                }
            }

            Console.WriteLine(plates.Any()
                    ? "The people successfully repulsed the orc's attack."
                    : "The orcs successfully destroyed the Gondor's defense.");

            Console.WriteLine(plates.Any()
                ? $"Plates left: {string.Join(", ", plates)}"
                : $"Orcs left: {string.Join(", ", orcs)}");

        }

        private static IEnumerable<int> ReadData()
        {
            return Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);
        }
    }
}
