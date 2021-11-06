using System;

namespace _01._USDtoBGN
{
    class Program
    {
        static void Main(string[] args)
        {
            const double USDrate = 1.79549;
            double USD = double.Parse(Console.ReadLine());

            double convertBGN = USD * USDrate;
            Console.WriteLine($"{convertBGN:f2}");
        }
    }
}
