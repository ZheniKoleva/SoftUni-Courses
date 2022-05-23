using System;
using System.Collections.Generic;

namespace _01.UniqueUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            HashSet<string> userNames = FillUserNames(lines); 
           
            Console.WriteLine(string.Join(Environment.NewLine, userNames));
        }

        private static HashSet<string> FillUserNames(int lines)
        {
           HashSet<string> userNames = new HashSet<string>();

            for (int i = 0; i < lines; i++)
            {
                userNames.Add(Console.ReadLine());
            }

            return userNames;
        }
    }
}
