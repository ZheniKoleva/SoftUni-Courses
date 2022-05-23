using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Masterchef
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> dishesByFreshnessLevel = new Dictionary<int, string>
            {
                { 150, "Dipping sauce"},
                {250, "Green salad" },
                {300, "Chocolate cake"},
                { 400, "Lobster"}
            };

            Dictionary<string, int> dishesCount = dishesByFreshnessLevel.Values
                .ToDictionary(x => x, x => 0);

            Queue<int> ingredients = new Queue<int>(ReadData());
            Stack<int> freshness = new Stack<int>(ReadData());

            while (ingredients.Any() && freshness.Any())
            {
                int currentIngredients = ingredients.Dequeue();

                if (currentIngredients == 0)
                {
                    continue;
                }

                int currentFreshness = currentIngredients * freshness.Pop();

                if (dishesByFreshnessLevel.ContainsKey(currentFreshness))
                {
                    string dishName = dishesByFreshnessLevel[currentFreshness];
                    dishesCount[dishName]++;
                }
                else
                {
                    currentIngredients += 5;
                    ingredients.Enqueue(currentIngredients);
                }
            }

            if (dishesCount.All(x => x.Value > 0))
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");

                foreach (var (dish, count) in dishesCount.OrderBy(x => x.Key))
                {
                    Console.WriteLine($" # {dish} --> {count}");
                }
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");

                if (ingredients.Any())
                {
                    Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
                }

                foreach (var (dish, count) in dishesCount.Where(x => x.Value > 0).OrderBy(x => x.Key))
                {
                    Console.WriteLine($" # {dish} --> {count}");
                }

            }
        }

        private static IEnumerable<int> ReadData()
        {
            return Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);
        }
    }    
}
