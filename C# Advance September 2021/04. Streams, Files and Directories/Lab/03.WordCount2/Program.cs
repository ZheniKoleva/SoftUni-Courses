using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace _03.WordCount2
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string wordText = await File.ReadAllTextAsync("words.txt");
            string[] words = wordText
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> wordByOccurances = words
                .ToDictionary(x => x, x => 0);

            string[] lines = await File.ReadAllLinesAsync("text.txt");

            foreach (var line in lines)
            {
                string[] lineWords = line.ToLower()
                    .Split(new char[] { ' ', '.', '?', '!', '-', ',' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var word in words)
                {
                    int count = lineWords.Where(x => x.Equals(word)).Count();
                    wordByOccurances[word] += count;
                }               
            }

            var ordered = wordByOccurances
                .OrderByDescending(x => x.Value)
                .Select(x => $"{x.Key} - {x.Value}");

            await File.AppendAllLinesAsync("../../../Output.txt", ordered);
        }
    }
}
