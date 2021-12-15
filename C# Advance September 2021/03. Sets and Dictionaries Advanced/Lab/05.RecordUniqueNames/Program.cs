using System;
using System.Collections.Generic;

namespace _05.RecordUniqueNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            HashSet<string> names = FillSet(lines);            

            Console.WriteLine(string.Join(Environment.NewLine, names));
        }

        private static HashSet<string> FillSet(int lines)
        {
            HashSet<string> names = new HashSet<string>();

            for (int i = 0; i < lines; i++)
            {
                names.Add(Console.ReadLine());
            }

            return names;
        }
    }
}
