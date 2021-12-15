using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.FoodFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, HashSet<char>> words = new Dictionary<string, HashSet<char>>()
            {
                { "pear", new HashSet<char>()},
                { "flour", new HashSet<char>()},
                { "pork", new HashSet<char>()},
                { "olive", new HashSet<char>()}
            };
           
            Queue<char> vowels = new Queue<char>(ReadData());
            Stack<char> consonants = new Stack<char>(ReadData());

            while (consonants.Any())
            {
                char currentVowel = vowels.Dequeue();
                char currentConsonant = consonants.Pop();

                foreach (var word in words)
                {
                    string currentWord = word.Key;
                  
                    if (currentWord.Contains(currentVowel))
                    {
                        words[currentWord].Add(currentVowel);
                    }

                    if (currentWord.Contains(currentConsonant))
                    {
                        words[currentWord].Add(currentConsonant);
                    }
                }

                vowels.Enqueue(currentVowel);
            }

            int wordsFound = words.Where(x => x.Key.Length == x.Value.Count()).Count();

            IEnumerable<string> founded = words
                .Where(x => x.Key.Length == x.Value.Count())
                .Select(x => x.Key);

            Console.WriteLine($"Words found: {wordsFound}");
            Console.WriteLine(string.Join(Environment.NewLine, founded));
        }

        private static IEnumerable<char> ReadData()
        {
            return Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse);
        }
    }
}
