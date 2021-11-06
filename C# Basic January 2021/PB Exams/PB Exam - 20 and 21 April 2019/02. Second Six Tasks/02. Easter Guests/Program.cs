using System;

namespace _02.EasterGuests
{
    class Program
    {
        static void Main(string[] args)
        {
            int guestsNumber = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());

            const double easternBreadPrice = 4.00;
            const double eggPrice = 0.45;

            double easternBreadNumber = Math.Ceiling(1.0 * guestsNumber / 3);
            int eggsCount = guestsNumber * 2;

            double easternBreadPriceTotal = easternBreadNumber * easternBreadPrice;
            double eggsPriceTotal = eggsCount * eggPrice;

            double priceFinal = easternBreadPriceTotal + eggsPriceTotal;

            if (priceFinal <= budget)
            {
                double moneyLeft = budget - priceFinal;
                Console.WriteLine($"Lyubo bought {easternBreadNumber} Easter bread and {eggsCount} eggs.");
                Console.WriteLine($"He has {moneyLeft:f2} lv. left.");
            }
            else
            {
                double moneyNeeded = priceFinal - budget;
                Console.WriteLine($"Lyubo doesn't have enough money.");
                Console.WriteLine($"He needs {moneyNeeded:f2} lv. more.");
            }
        }
    } 
}
