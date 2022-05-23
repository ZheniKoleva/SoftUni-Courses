using System;
using System.IO;
using System.Threading.Tasks;

namespace _04.MergeFiles
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using StreamReader reader = new StreamReader("FileOne.txt");
            using StreamReader readerTwo = new StreamReader("FileTwo.txt");
            using StreamWriter writer = new StreamWriter("../../../Output.txt");
            
            while (!reader.EndOfStream && !readerTwo.EndOfStream)
            {
                string first = await reader.ReadLineAsync();
                string second = await readerTwo.ReadLineAsync();

                await writer.WriteLineAsync(first);
                await writer.WriteLineAsync(second);
            }

        }
    }
}
