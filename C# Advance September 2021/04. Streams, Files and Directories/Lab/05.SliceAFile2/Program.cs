using System;
using System.IO;
using System.Threading.Tasks;

namespace _05.SliceAFile2
{
    class Program
    {
        static async Task Main(string[] args)
        {
            const int PARTS = 4;
            string text = await File.ReadAllTextAsync("sliceMe.txt");
            int partSize = (int)Math.Ceiling(text.Length / (double)PARTS);

            for (int i = 0; i < PARTS; i++)
            {
                int dataToRead = Math.Min(partSize, text.Length - (partSize * i));

                string part = text.Substring(partSize * i, dataToRead);
                await File.WriteAllTextAsync($"../../../Part-{i + 1}.txt", part);
            }

        }
    }
}
