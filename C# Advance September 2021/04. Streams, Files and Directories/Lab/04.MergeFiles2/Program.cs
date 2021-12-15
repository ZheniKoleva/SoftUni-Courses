using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace _04.MergeFiles2
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string[] firstTextLines = await File.ReadAllLinesAsync("FileOne.txt");
            string[] secondTextLines = await File.ReadAllLinesAsync("FileTwo.txt");
            List<string> combined = new List<string>();

            for (int i = 0; i < firstTextLines.Length; i++)
            {
                combined.Add(firstTextLines[i]);
                combined.Add(secondTextLines[i]);
            }

            await File.AppendAllLinesAsync("../../../Output.txt", combined);          
        }
    }
}
