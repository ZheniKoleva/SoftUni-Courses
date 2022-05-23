using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.OddOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);                

            Dictionary<string, int> result = new Dictionary<string, int>();

            foreach (var item in input)
            {
                string lowerCase = item.ToLower();

                if (!result.ContainsKey(lowerCase))
                {
                    result.Add(lowerCase, 0);
                }

                result[lowerCase]++;
            }

            List<string> output = result
                .Where(x => x.Value % 2 == 1)
                .Select(x => x.Key)
                .ToList();

            Console.WriteLine(string.Join(' ', output));
           
        }
    }
}
