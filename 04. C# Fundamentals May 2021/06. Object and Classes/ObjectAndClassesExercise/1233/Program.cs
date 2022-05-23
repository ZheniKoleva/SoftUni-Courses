using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _4.Santa_sSecretHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"@(?<name>[A-Za-z]+)[^-@!\:]*!(?<behavior>[G])!");

            int key = int.Parse(Console.ReadLine());
            List<string> childrenNames = new List<string>();

            string encrypted = Console.ReadLine();

            while (encrypted != "end")
            {
                string decrypted = DecryptMessage(encrypted, key);
                Match matched = regex.Match(decrypted);

                if (matched.Success)
                {
                    string name = matched.Groups["name"].Value;
                    char behavior = char.Parse(matched.Groups["behavior"].Value);
                    childrenNames.Add(name);
                }

                encrypted = Console.ReadLine();
            }

            foreach (var name in childrenNames)
            {
                Console.WriteLine(name);
            }
        }

        private static string DecryptMessage(string encrypted, int key)
        {
            StringBuilder decrypted = new StringBuilder();

            foreach (var symbol in encrypted)
            {
                decrypted.Append((char)(symbol - key));
            }

            return decrypted.ToString();
        }
    }
}