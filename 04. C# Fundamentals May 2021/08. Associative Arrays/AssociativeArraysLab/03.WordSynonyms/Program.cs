using System;
using System.Collections.Generic;

namespace _03.WordSynonyms
{
    class Program
    {
        static void Main(string[] args)
        {
            int wordsCount = int.Parse(Console.ReadLine());

            Dictionary<string, List<string>> result = new Dictionary<string, List<string>>();

            for (int i = 0; i < wordsCount; i++)
            {
                string key = Console.ReadLine();
                string synonym = Console.ReadLine();

                if (!result.ContainsKey(key))
                {
                    result.Add(key, new List<string>());
                }

                result[key].Add(synonym);
            }

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Key} - {string.Join(", ", item.Value)}");
            }
        }
    }
}
