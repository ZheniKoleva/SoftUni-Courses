using System;
using System.IO;
using System.Threading.Tasks;

namespace _01.OddLines3
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string[] readText = await File.ReadAllLinesAsync("Input.txt");
            //FileStream writer = new FileStream("../../../Output.txt", FileMode.OpenOrCreate);

            for (int i = 1; i < readText.Length; i += 2)
            {
                string currLine = $"{readText[i]}{Environment.NewLine}";
                await File.AppendAllTextAsync("../../../Output.txt", currLine);
            }
        }
    }
}
