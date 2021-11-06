using System;

namespace _02.GodzillaVs.Kong
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int extrasCount = int.Parse(Console.ReadLine());
            double clothPricePerOne = double.Parse(Console.ReadLine());

            double decorPrice = budget * 0.10;
            double clothPrice = extrasCount * clothPricePerOne;
            double totalPrice = 0;

            if (extrasCount > 150)
            {
                clothPrice -= clothPrice * 0.10;
            }

            totalPrice = decorPrice + clothPrice;

            if (budget >= totalPrice)
            {
                double moneyLeft = budget - totalPrice;
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {moneyLeft:f2} leva left.");
            }
            else
            {
                double moneyNeed = totalPrice - budget;
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {moneyNeed:f2} leva more.");
            }

        }
    }
}
