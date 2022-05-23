using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace _03.WordCount
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string[] wordsToCheck = await File.ReadAllLinesAsync("words.txt");
            
            string[] textLines = await File.ReadAllLinesAsync("text.txt");
            
            Dictionary<string, int> wordsByOccurance = wordsToCheck
                .ToDictionary(x => x, x => 0);

            char[] delimiters = new char[] { '-', '.', ',', '!', '?', ' ' };

            foreach (var line in textLines)
            {
                string currentLine = line.ToLower();
                string[] lineWords = currentLine
                    .Split( delimiters, StringSplitOptions.RemoveEmptyEntries);

                foreach (var word in wordsToCheck)
                {
                    int occurance = lineWords.Where(x => x.Equals(word)).Count();

                    wordsByOccurance[word] += occurance;
                }
            }

            var result = wordsByOccurance
                .Select(x => $"{x.Key} - {x.Value}");

            await File.WriteAllLinesAsync("../../../actualResult.txt", result);
        }
    }
}
