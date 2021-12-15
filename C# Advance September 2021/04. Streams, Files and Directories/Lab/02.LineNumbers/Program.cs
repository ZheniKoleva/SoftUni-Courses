using System;
using System.IO;
using System.Threading.Tasks;

namespace _02.LineNumbers
{
    class Program
    {
        static async Task Main(string[] args)
        {
            int count = 1;

            using StreamReader reader = new StreamReader("Input.txt");
            using StreamWriter writer = new StreamWriter("../../../Output.txt");
            while (!reader.EndOfStream)
            {
                string currentLine = await reader.ReadLineAsync();
                await writer.WriteLineAsync($"{count}. {currentLine}");
                count++;
            }
        }
    }
}
