using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace _02.LineNumbers
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string[] lines = await File.ReadAllLinesAsync("text.txt");

            for(int i = 0; i < lines.Length; i++)
            {
                int letterCount = lines[i].Where(x => char.IsLetter(x)).Count();
                int punctCount = lines[i].Where(x => char.IsPunctuation(x)).Count();

                lines[i] = $"Line {i + 1}: {lines[i]}({letterCount})({punctCount})";
            }

            await File.WriteAllLinesAsync("../../../Output.txt", lines);
        }
    }
}
