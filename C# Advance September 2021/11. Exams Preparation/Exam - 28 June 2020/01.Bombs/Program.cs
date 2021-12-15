using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> bombsByValue = new Dictionary<int, string>()
            {
                { 40, "Datura Bombs"},
                { 60, "Cherry Bombs"},
                { 120, "Smoke Decoy Bombs"}
            };

            Dictionary<string, int> bombsByCount = bombsByValue.Values
                .ToDictionary(x => x, x => 0);

            Queue<int> bombEffect = new Queue<int>(ReadData());
            Stack<int> bombCasing = new Stack<int>(ReadData());

            bool isAccomplished = false;

            while (bombEffect.Any() && bombCasing.Any())
            {
                int currentCasing = bombCasing.Peek();
                int currentEffect = bombEffect.Peek();

                int currentSum = currentCasing + currentEffect;

                if (bombsByValue.ContainsKey(currentSum))
                {
                    bombsByCount[bombsByValue[currentSum]]++;
                    bombEffect.Dequeue();
                    bombCasing.Pop();
                }
                else
                {
                    bombCasing.Push(bombCasing.Pop() - 5);
                }

                if (bombsByCount.All(x => x.Value >= 3))
                {
                    isAccomplished = true;
                    break;
                }
            }

            Console.WriteLine(isAccomplished
                ? "Bene! You have successfully filled the bomb pouch!"
                : "You don't have enough materials to fill the bomb pouch.");

            Console.WriteLine(bombEffect.Any()
                ? $"Bomb Effects: {string.Join(", ", bombEffect)}"
                : "Bomb Effects: empty");

            Console.WriteLine(bombCasing.Any()
                ? $"Bomb Casings: {string.Join(", ", bombCasing)}"
                : "Bomb Casings: empty");

            foreach (var (bomb, count) in bombsByCount.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{bomb}: {count}");
            }

        }

        private static IEnumerable<int> ReadData()
        {
            return Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);
        }
    }
}
