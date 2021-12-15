using System;
using System.Collections.Generic;

namespace _06.Wardrobe2
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            int lines = int.Parse(Console.ReadLine());

            FillClothes(wardrobe, lines);

            string[] searchedItem = Console.ReadLine()
                 .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string searchedColor = searchedItem[0];
            string searchedCloth = searchedItem[1];

            PrinClothes(wardrobe, searchedColor, searchedCloth);
        }

        private static void PrinClothes(Dictionary<string, Dictionary<string, int>> wardrobe, string searchedColor, string searchedCloth)
        {
            foreach (var (colour, items) in wardrobe)
            {
                Console.WriteLine($"{colour} clothes:");

                foreach (var (item, count) in items)
                {
                    string result = $"* {item} - {count}";

                    if (searchedColor == colour && searchedCloth == item)
                    {
                        result += " (found!)";
                    }

                    Console.WriteLine(result);
                }
            }
        }

        private static void FillClothes(Dictionary<string, Dictionary<string, int>> wardrobe, int lines)
        {
            for (int i = 0; i < lines; i++)
            {
                string[] clothData = Console.ReadLine()
                .Split(new string[] { " -> ", "," }, StringSplitOptions.RemoveEmptyEntries);

                string color = clothData[0];
                string[] clothes = clothData[1..];

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }

                foreach (var clothType in clothes)
                {
                    if (!wardrobe[color].ContainsKey(clothType))
                    {
                        wardrobe[color].Add(clothType, 0);
                    }

                    wardrobe[color][clothType]++;
                }
            }
        }
    }
}
