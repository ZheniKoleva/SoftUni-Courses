using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _4.Santa_sSecretHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());

            List<string> children = new List<string>();

            string input = Console.ReadLine();

            while (input != "end")
            {
                char[] decodedChars = input
                    .Select(x => (char)(x - key))
                    .ToArray();

                string decoded = string.Join("", decodedChars);

                string pattern = @"@(?<name>[A-Za-z]+)[^\-\@!\:\>]*!(?<behavior>[G])!";

                Match result = Regex.Match(decoded, pattern);

                if (result.Success)
                {
                    children.Add(result.Groups["name"].Value);
                }                    

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(Environment.NewLine, children));
        }

        
    }
}
