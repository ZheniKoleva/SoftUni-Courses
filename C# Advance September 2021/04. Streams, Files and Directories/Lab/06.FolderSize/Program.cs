using System;
using System.IO;
using System.Threading.Tasks;

namespace _06.FolderSize
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string[] files = Directory.GetFiles("../../../TestFolder");
            double sizeFiles = 0;

            foreach (var file in files)
            {
                FileInfo current = new FileInfo(file);
                sizeFiles += current.Length;
            }

            double sizeInMB = sizeFiles / 1024 / 1024;
            await File.WriteAllTextAsync("../../../Output.txt", sizeInMB.ToString());
        }
    }
}
