using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int foodAmount = int.Parse(Console.ReadLine());

            Queue<int> orders = new Queue<int>(ReadData());

            Console.WriteLine(orders.Max());

            while (orders.Any() && foodAmount > 0)
            {
                int currentOrder = orders.Peek();

                foodAmount -= currentOrder;

                if (foodAmount >= 0)
                {
                    orders.Dequeue();
                }
            }

            Console.WriteLine(orders.Any()
                ? $"Orders left: {string.Join(' ', orders)}"
                : "Orders complete");
        }

        private static IEnumerable<int> ReadData()
        {
            return Console.ReadLine()
                          .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                          .Select(int.Parse);
        }
    }
}
