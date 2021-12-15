using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace _03.WordsCount2
{
    class Program
    {
        static async Task Main(string[] args)
        {
            List<string> wordsToCheck = new List<string>();

            using (StreamReader reader = new StreamReader("words.txt"))
            while (!reader.EndOfStream)
            {
                string currentLine = await reader.ReadLineAsync();
                wordsToCheck.Add(currentLine.ToLower());
            }


            Dictionary<string, int> wordsByOccurance = wordsToCheck
                .ToDictionary(x => x, x => 0);

            char[] delimiters = new char[] { '-', '.', ',', '!', '?', ' ' };

            using (StreamReader reader = new StreamReader("text.txt"))            
            while (!reader.EndOfStream)
            {
                string currentLine = await reader.ReadLineAsync();

                string[] lineWords = currentLine.ToLower()
                        .Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

                foreach (var word in wordsToCheck)
                {
                    int occurance = lineWords.Where(x => x.Equals(word)).Count();

                    wordsByOccurance[word] += occurance;
                }
            }            

            var result = wordsByOccurance
                .Select(x => $"{x.Key} - {x.Value}");

            using StreamWriter writer = new StreamWriter("../../../actualResult.txt");
            foreach (var line in result)
            {
                await writer.WriteLineAsync(line);
            }

        }
    }
}
