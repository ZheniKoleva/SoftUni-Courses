using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Cooking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> foodByValue = new Dictionary<int, string>()
            {
                { 25, "Bread"},
                { 50, "Cake"},
                { 75, "Pastry"},
                { 100, "Fruit Pie"}
            };

            Dictionary<string, int> foodByCount = foodByValue.Values
                .ToDictionary(x => x, x => 0);

            Queue<int> liquids = new Queue<int>(ReadData());
            Stack<int> ingredients = new Stack<int>(ReadData());

            while (liquids.Any() && ingredients.Any())
            {
                int currentValue = liquids.Dequeue() + ingredients.Peek();

                if (foodByValue.ContainsKey(currentValue))
                {
                    foodByCount[foodByValue[currentValue]]++;                    
                    ingredients.Pop();
                }
                else
                {                    
                    ingredients.Push(ingredients.Pop() + 3);
                }

            }

            if (foodByCount.All(x => x.Value > 0))
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }

            Console.WriteLine(liquids.Any() 
                ? $"Liquids left: {string.Join(", ", liquids)}"
                : "Liquids left: none");

            Console.WriteLine(ingredients.Any()
                ? $"Ingredients left: {string.Join(", ", ingredients)}"
                : "Ingredients left: none");

            foreach (var (food, amount) in foodByCount.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{food}: {amount}");
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
