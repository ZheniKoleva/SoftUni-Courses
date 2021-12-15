using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _06.Wardrobe3
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<Cloth>> wardrobe = new Dictionary<string, List<Cloth>>();

            int lines = int.Parse(Console.ReadLine());

            FillClothes(wardrobe, lines);

            string[] searchedItem = Console.ReadLine()
                 .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string searchedColor = searchedItem[0];
            string searchedCloth = searchedItem[1];

            PrinClothes(wardrobe, searchedColor, searchedCloth);
        }

        private static void PrinClothes(Dictionary<string, List<Cloth>> wardrobe, string searchedColor, string searchedCloth)
        {
            foreach (var (colour, clothes) in wardrobe)
            {
                Console.WriteLine($"{colour} clothes:");

                foreach (var cloth in clothes)
                {
                    string result = cloth.ToString();

                    if (searchedColor == cloth.Color && searchedCloth == cloth.Type)
                    {
                        result += " (found!)";
                    }

                    Console.WriteLine(result);
                }
            }
        }

        private static void FillClothes(Dictionary<string, List<Cloth>> wardrobe, int lines)
        {
            for (int i = 0; i < lines; i++)
            {
                string[] clothData = Console.ReadLine()
                .Split(new string[] { " -> ", "," }, StringSplitOptions.RemoveEmptyEntries);

                string color = clothData[0];
                string[] clothes = clothData[1..];

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new List<Cloth>());
                }

                foreach (var clothType in clothes)
                {
                    if (!wardrobe[color].Any(x => x.Type == clothType))
                    {
                        wardrobe[color].Add(new Cloth(color, clothType));
                    }

                    Cloth current = wardrobe[color].First(x => x.Type == clothType);
                    current.Count++;
                }
            }
        }
    }

    public class Cloth 
    {
        public Cloth(string color, string type)
        {
            Color = color;
            Type = type;            
        }

        public string Color { get; set; }

        public string Type { get; set; }

        public int Count { get; set; } = 0;
       
        public override string ToString()
        {
            return $"* {Type} - {Count}";
        }
     
    }
}
