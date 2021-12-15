using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace _02.LineNumbers2
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using StreamReader reader = new StreamReader("text.txt");
            int lineNumber = 1;
            using StreamWriter writer = new StreamWriter("../../../Output.txt");

            while (!reader.EndOfStream)
            {
                string currentLine = await reader.ReadLineAsync();

                int letterCount = currentLine.Where(x => char.IsLetter(x)).Count();
                int punctCount = currentLine.Where(x => char.IsPunctuation(x)).Count();

                await writer.WriteLineAsync($"Line {lineNumber}: {currentLine}({letterCount})({punctCount})");
                lineNumber++;
            }
        }
    }
}
