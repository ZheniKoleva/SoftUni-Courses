using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace _01.EvenLines
{
    class Program
    {
        static async Task Main(string[] args)
        {
            char[] charsToReplace = new char[] { '-', ',','.','!', '?' };
            char replacement = '@';

            using StreamReader reader = new StreamReader("text.txt");
            using StreamWriter writer = new StreamWriter("../../../Output.txt");
            
            bool isEven = true;

            while (!reader.EndOfStream)
            {
                string currentLine = await reader.ReadLineAsync();

                if (!isEven)
                {
                    isEven = true;
                    continue;
                }

                foreach (var item in charsToReplace)
                {
                    currentLine = currentLine.Replace(item, replacement);
                }

                var words = currentLine
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Reverse();                    

                await writer.WriteLineAsync(string.Join(' ', words));
                isEven = false;
            }
        }
    }
}
