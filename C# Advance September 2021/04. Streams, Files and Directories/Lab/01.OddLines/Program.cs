using System;
using System.IO;
using System.Threading.Tasks;

namespace _01.OddLines
{
    class Program
    {
        static async Task Main(string[] args)
        {
            bool isOddLine = false;

            using StreamReader reader = new StreamReader("Input.txt");
            using StreamWriter writer = new StreamWriter("../../../Output.txt");
            while (!reader.EndOfStream)
            {
                string currentLine = await reader.ReadLineAsync();

                if (!isOddLine)
                {
                    isOddLine = true;
                    continue;
                }

                await writer.WriteLineAsync(currentLine);
                isOddLine = false;
            }
        }
    }
}
