using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _03.TreasureFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] keys = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string line = Console.ReadLine();

            while (line != "find")
            {
                string decrypted = DecryptMessage(keys, line);

                Console.WriteLine(FindTreasure(decrypted));

                line = Console.ReadLine();
            }
        }

        private static string FindTreasure(string decrypted)
        {
            string patternType = @"&(?<type>[A-za-z]+)&";
            Match type = Regex.Match(decrypted, patternType);
            string founded = type.Groups["type"].Value;

            string coordinatesPattren = @"<(?<coordinates>\w+)>";
            Match coordinates = Regex.Match(decrypted, coordinatesPattren);
            string place = coordinates.Groups["coordinates"].Value;

            return $"Found {founded} at {place}";
        }

        private static string DecryptMessage(int[] keys, string line)
        {
            StringBuilder result = new StringBuilder();
            int keyIndx = 0;

            for (int i = 0; i < line.Length; i++)
            {
                result.Append((char)(line[i] - keys[keyIndx]));
                keyIndx++;

                if (keyIndx >= keys.Length)
                {
                    keyIndx = 0;
                }
            }

            return result.ToString();
        }
    }
}
