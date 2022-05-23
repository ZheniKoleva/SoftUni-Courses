using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> clothes = new Stack<int>(ReadData());
            int rackCapacity = int.Parse(Console.ReadLine());

            int currentRack = 0;
            int racksCount = 1;

            while (clothes.Any())
            {
                int currentCloth = clothes.Peek();
                bool hasSpace = currentRack + currentCloth <= rackCapacity;

                if (hasSpace)
                {
                    currentRack += currentCloth;
                    clothes.Pop();
                }
                else
                {
                    racksCount++;
                    currentRack = 0;
                }
            }

            Console.WriteLine(racksCount);

        }

        private static IEnumerable<int> ReadData()
        {
            return Console.ReadLine()
                          .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                          .Select(int.Parse);
        }
    }
}
