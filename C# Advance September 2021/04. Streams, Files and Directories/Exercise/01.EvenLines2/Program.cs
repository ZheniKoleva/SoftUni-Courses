using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace _01.EvenLines2
{
    class Program
    {
        static async Task Main(string[] args)
        {
            char[] charsToReplace = new char[] { '-', ',', '.', '!', '?' };
            char replacement = '@';

            string[] lines = await File.ReadAllLinesAsync("text.txt");
            List<string> evenLines = new List<string>();

            for (int i = 0; i < lines.Length; i += 2)
            {
                foreach (var item in charsToReplace)
                {
                    lines[i] = lines[i].Replace(item, replacement);
                }

                var reversed = lines[i]
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Reverse();                    

                evenLines.Add(string.Join(' ', reversed)); 

            }
            await File.WriteAllLinesAsync("../../../Output.txt", evenLines);
        }
    }
}
