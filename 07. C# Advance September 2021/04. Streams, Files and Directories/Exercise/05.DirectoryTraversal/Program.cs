using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.DirectoryTraversal
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string path = Console.ReadLine();
            string[] files = Directory.GetFiles(path);

            Dictionary<string, List<FileInfo>> filesByExtensions = FillData(files);

            filesByExtensions = filesByExtensions
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            string result = GenerateReport(filesByExtensions);
            string destinationPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            await File.WriteAllTextAsync(destinationPath + "/report.txt", result);
        }

        private static string GenerateReport(Dictionary<string, List<FileInfo>> filesByExtensions)
        {
            StringBuilder output = new StringBuilder();

            foreach (var (extension, files) in filesByExtensions)
            {
                output.AppendLine(extension);

                foreach (var file in files.OrderByDescending(x => x.Length))
                {
                    output.AppendLine($"--{file.Name} - {((double)file.Length / 1024):f3}kb");
                }
            }

            return output.ToString().Trim();
        }

        private static Dictionary<string, List<FileInfo>> FillData(string[] files)
        {
            Dictionary<string, List<FileInfo>> data = new Dictionary<string, List<FileInfo>>();

            foreach (var file in files)
            {
                FileInfo current = new FileInfo(file);

                if (!data.ContainsKey(current.Extension))
                {
                    data.Add(current.Extension, new List<FileInfo>());
                }

                data[current.Extension].Add(current);
            }

            return data;
        }
    }
}
