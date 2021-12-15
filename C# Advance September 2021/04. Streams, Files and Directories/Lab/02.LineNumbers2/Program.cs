using System;
using System.IO;
using System.Threading.Tasks;

namespace _02.LineNumbers2
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string[] lines = await File.ReadAllLinesAsync("Input.txt");

            for (int i = 0; i < lines.Length; i++)
            {
                lines[i] = $"{i + 1}. {lines[i]}";
            }

            await File.WriteAllLinesAsync("../../../Output.txt", lines);
        }
    }
}
