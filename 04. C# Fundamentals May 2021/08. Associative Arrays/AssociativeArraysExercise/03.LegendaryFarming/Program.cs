using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> legendaryItems = new Dictionary<string, int>
            {
               { "shards", 0 },
               {"fragments", 0},
               { "motes",  0 }
            };  

            SortedDictionary<string, int> junk = new SortedDictionary<string, int>();

            const int GOAL = 250;
            bool isObtained = false;            

            while (!isObtained)
            {
                string[] itemsData = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < itemsData.Length; i += 2)
                {
                    int quantity = int.Parse(itemsData[i]);
                    string item = itemsData[i + 1].ToLower();                    

                    if (legendaryItems.ContainsKey(item))
                    {
                        legendaryItems[item] += quantity;

                        if (legendaryItems[item] >= GOAL)
                        {
                            isObtained = true;
                            Console.WriteLine(ItemObtained(item));

                            legendaryItems[item] -= GOAL;
                            break;
                        }

                    }
                    else if (!junk.ContainsKey(item))
                    {
                        junk.Add(item, quantity);
                    }
                    else
                    {
                        junk[item] += quantity;
                    }

                }

            }           

            legendaryItems = legendaryItems
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            PrintDictionary(legendaryItems);
            PrintDictionary(junk);
        }

        private static void PrintDictionary(SortedDictionary<string, int> dictionary)
        {
            foreach (var item in dictionary)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }

        private static void PrintDictionary(Dictionary<string, int> dictionary)
        {
            foreach (var item in dictionary)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }

        private static string ItemObtained(string materialCollect)
        {
            string itemObtained = string.Empty;
            
            switch (materialCollect)
            {
             case "shards":
                    itemObtained = "Shadowmourne";
                    break;

                case "fragments":
                    itemObtained = "Valanyr";
                    break;

                case "motes":
                    itemObtained = "Dragonwrath";
                    break;               
            }

            return $"{itemObtained} obtained!";
        }
    }
}
