using System;

namespace _01.EasterLunch
{
    class Program
    {
        static void Main(string[] args)
        {
            int easterBreadCount = int.Parse(Console.ReadLine());
            int eggsShellCount = int.Parse(Console.ReadLine());
            int cookiesAmount = int.Parse(Console.ReadLine());

            const double easterBreadPrice = 3.20;
            const double eggsShellPrice = 4.35;
            const double cookiesPrice = 5.40;
            const double colourPricePerEgg = 0.15;

            int eggsCountTotal = eggsShellCount * 12;

            double easterBreadPriceTotal = easterBreadCount * easterBreadPrice;
            double eggsPriceTotal = eggsShellCount * eggsShellPrice;
            double eggsColouringPrice = eggsCountTotal * colourPricePerEgg;
            double cookiesPriceTotal = cookiesAmount * cookiesPrice;

            double finalPrice = easterBreadPriceTotal + eggsPriceTotal + eggsColouringPrice + cookiesPriceTotal;

            Console.WriteLine($"{finalPrice:f2}");
        }
    }
}
