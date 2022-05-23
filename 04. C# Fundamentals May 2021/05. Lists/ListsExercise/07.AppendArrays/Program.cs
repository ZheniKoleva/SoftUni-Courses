using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.AppendArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] initialArrays = Console.ReadLine()
                .Split('|', StringSplitOptions.RemoveEmptyEntries);                

            List<string> appendArrays = new List<string>();

            for (int i = initialArrays.Length - 1; i >= 0; i--)
            {
                string[] currentArray = initialArrays[i]
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);                    

                appendArrays.AddRange(currentArray);
            }

            Console.WriteLine(string.Join(' ', appendArrays));

        }
    }
}
