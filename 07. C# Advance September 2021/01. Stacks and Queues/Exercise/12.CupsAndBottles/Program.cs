using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.CupsAndBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> cups = new Queue<int>(ReadData());
            Stack<int> bottles = new Stack<int>(ReadData());

            int wastedWater = 0;

            while (cups.Any() && bottles.Any())
            {
                int currentCup = cups.Peek();

                while (currentCup > 0)
                {
                    int currentBottle = bottles.Pop();

                    if (currentCup > currentBottle)
                    {
                        currentCup -= currentBottle;
                    }
                    else
                    {
                        cups.Dequeue();
                        wastedWater += currentBottle - currentCup;
                        break;
                    }
                }
               
            }

            Console.WriteLine(cups.Any() 
                ? $"Cups: {string.Join(' ', cups)}"
                : $"Bottles: {string.Join(' ', bottles)}");

            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }

        private static IEnumerable<int> ReadData()
        {
            return Console.ReadLine()
                          .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                          .Select(int.Parse);
        }
    }
}
