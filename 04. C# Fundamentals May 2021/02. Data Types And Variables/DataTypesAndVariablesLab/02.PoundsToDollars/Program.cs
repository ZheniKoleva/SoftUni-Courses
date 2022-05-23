using System;

namespace _02.PoundsToDollars
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal pounds = decimal.Parse(Console.ReadLine());
            decimal rate = 1.31m;

            decimal dollars = pounds * rate;

            Console.WriteLine($"{dollars:f3}");
        }
    }
}
