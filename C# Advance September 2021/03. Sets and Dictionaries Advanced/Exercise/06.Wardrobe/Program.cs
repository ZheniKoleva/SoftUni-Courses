using System;
using System.Collections.Generic;

namespace _06.Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            // color -> cloth -> count
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            int lines = int.Parse(Console.ReadLine());
            
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

            string[] searchedItem = Console.ReadLine()
                 .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string searchedColor = searchedItem[0];
            string searchedCloth = searchedItem[1];

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
    }
}
