using System;
using System.Collections.Generic;
using System.Linq;

namespace _6.Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> customers = new Queue<string>();

            string line;

            while ((line = Console.ReadLine()) != "End")
            {
                if (line == "Paid")
                {
                    while (customers.Any())
                    {
                        Console.WriteLine(customers.Dequeue());
                    }

                    continue;
                }

                customers.Enqueue(line);
            }

            Console.WriteLine($"{customers.Count} people remaining.");
        }
    }
}
