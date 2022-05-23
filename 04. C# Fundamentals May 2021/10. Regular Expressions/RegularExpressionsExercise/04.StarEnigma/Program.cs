using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _04.StarEnigma
{
    class Program
    {
        static void Main(string[] args)
        {
            string keyPattern = @"[STARstar]";
            string pattern = @"\@(?<planet>[A-Za-z]+)[^\@\-!\:\>]*?:(?<population>\d+)[^\@\-!\:\>]*?!(?<type>[AD])![^\@\-!\:\>]*?->(?<spldiers>\d+)";

            List<string> attacked = new List<string>();
            List<string> destroyed = new List<string>();

            int linesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < linesCount; i++)
            {
                string input = Console.ReadLine();

                int key = Regex.Matches(input, keyPattern).Count;

                string decrypted = DecryptInput(input, key);

                Match result = Regex.Match(decrypted, pattern);

                if (!result.Success)
                {
                    continue;
                }

                string planetName = result.Groups["planet"].Value;
                char battle = char.Parse(result.Groups["type"].Value);

                if (battle == 'A')
                {
                    attacked.Add(planetName);
                }
                else
                {
                    destroyed.Add(planetName);
                }
            }

            Console.WriteLine($"Attacked planets: {attacked.Count}");
            PrintPlanets(attacked);

            Console.WriteLine($"Destroyed planets: {destroyed.Count}");
            PrintPlanets(destroyed);

        }

        private static void PrintPlanets(List<string> list)
        {
            list = list.OrderBy(x => x).ToList();

            foreach (var item in list)
            {
                Console.WriteLine($"-> {item}");
            }
        }

        private static string DecryptInput(string input, int key)
        {
            StringBuilder result = new StringBuilder(input);

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = (char)(result[i] - key);
            }

            return result.ToString();
        }
    }
}
