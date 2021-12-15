using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.WarmWinter
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> hats = new Stack<int>(ReadData());
            Queue<int> scarves = new Queue<int>(ReadData());
            List<int> setPrices = new List<int>();

            while (hats.Any() && scarves.Any())
            {                
                if (hats.Peek() > scarves.Peek())
                {
                    setPrices.Add(hats.Peek() + scarves.Peek());

                    hats.Pop();
                    scarves.Dequeue();
                }
                else if (scarves.Peek() > hats.Peek())
                {
                    hats.Pop();
                }
                else
                {
                    scarves.Dequeue();
                    hats.Push(hats.Pop() + 1);
                }

            }

            Console.WriteLine($"The most expensive set is: {setPrices.Max()}");
            Console.WriteLine(string.Join(' ', setPrices));

        }

        private static IEnumerable<int> ReadData()
        {
            return Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);
        }
    }
}
