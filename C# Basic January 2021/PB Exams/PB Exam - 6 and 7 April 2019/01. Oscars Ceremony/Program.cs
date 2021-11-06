using System;

namespace _01.OscarsCeremony
{
    class Program
    {
        static void Main(string[] args)
        {
            int hallRent = int.Parse(Console.ReadLine());

            double statuesPrice = hallRent * 0.70;
            double cateringPrice = statuesPrice * 0.85;
            double soundingPrice = cateringPrice / 2;

            double totalSum = hallRent + statuesPrice + cateringPrice + soundingPrice;

            Console.WriteLine($"{totalSum:f2}");
        }
    }
}
