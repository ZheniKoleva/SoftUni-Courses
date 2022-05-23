using System;
using System.Collections.Generic;

namespace _02.AMinerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, long> resourses = new Dictionary<string, long>();

            string line = Console.ReadLine();

            while (line.ToLower() !="stop" )
            {
                long quantity = long.Parse(Console.ReadLine());

                if (!resourses.ContainsKey(line))
                {
                    resourses.Add(line, 0);
                }

                resourses[line] += quantity;

                line = Console.ReadLine();
            }

            foreach (var item in resourses)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }

        }
    }
}
