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
            using StreamReader reader = new StreamReader("words.txt");
            string wordsAsString = await reader.ReadToEndAsync();

            string[] words = wordsAsString
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> wordsByOccurance = words
                .ToDictionary(x => x, x => 0);

            using StreamReader textReader = new StreamReader("text.txt");
            while (!textReader.EndOfStream)
            {
                string currentLine = await textReader.ReadLineAsync();

                foreach (var word in words)
                {
                    string[] splitText = currentLine
                        .ToLower()
                        .Split(new char[] { ' ', '.', '?', '!', '-', ',' }, StringSplitOptions.RemoveEmptyEntries);

                    int count = splitText.Where(x => x.Equals(word)).Count();
                    wordsByOccurance[word] += count;
                }
            }


            using StreamWriter writer = new StreamWriter("../../../Output.txt");
            foreach (var (word, occurance) in wordsByOccurance.OrderByDescending(x => x.Value))
            {
                await writer.WriteLineAsync($"{word} - {occurance}");
            }
        }
    }
}
