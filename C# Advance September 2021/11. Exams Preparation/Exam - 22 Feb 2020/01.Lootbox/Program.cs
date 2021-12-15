using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> firstLoot = new Queue<int>(ReadData());
            Stack<int> secondLoot = new Stack<int>(ReadData());
            int claimedItems = 0;

            while (firstLoot.Any() && secondLoot.Any())
            {
                int currentSum = firstLoot.Peek() + secondLoot.Peek();

                if (currentSum % 2 == 0)
                {
                    claimedItems += currentSum;
                    firstLoot.Dequeue();
                    secondLoot.Pop();
                }
                else
                {
                    firstLoot.Enqueue(secondLoot.Pop());
                }
            }

            Console.WriteLine(firstLoot.Any()
                ? "Second lootbox is empty"
                : "First lootbox is empty");

            Console.WriteLine(claimedItems >= 100 
                ? $"Your loot was epic! Value: {claimedItems}"
                : $"Your loot was poor... Value: {claimedItems}");

        }

        private static IEnumerable<int> ReadData()
        {
            return Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);
        }
    }
}
