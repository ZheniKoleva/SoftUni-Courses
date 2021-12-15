using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace _01.OddLInes2
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string[] readText = await File.ReadAllLinesAsync("Input.txt");
            List<string> oddLines = new List<string>();

            for (int i = 1; i < readText.Length; i += 2)
            {
                oddLines.Add(readText[i]);
            }
            await File.WriteAllLinesAsync("../../../Output.txt", oddLines);           
        }
    }
}
