using System;
using System.Collections.Generic;

namespace _03.PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            SortedSet<string> elements = FillElements(lines);

            Console.WriteLine(string.Join(' ', elements));
        }

        private static SortedSet<string> FillElements(int lines)
        {
            SortedSet<string> elements = new SortedSet<string>();

            for (int i = 0; i < lines; i++)
            {               
                elements.UnionWith(Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries));               
            }

            return elements;
        }
    }
}
