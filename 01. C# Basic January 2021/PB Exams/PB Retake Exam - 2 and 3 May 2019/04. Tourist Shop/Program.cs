using System;

namespace _04.TouristShop
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());

            double equipmentPriceTotal = 0.00;
            int itemCount = 0;
            double moneyNeeded = 0.00;

            string item = Console.ReadLine();

            while (item != "Stop")
            {
                double itemPrice = double.Parse(Console.ReadLine());
                itemCount++;

                if (itemCount % 3 == 0)
                {
                    itemPrice /= 2;
                }

                if (itemPrice > budget)
                {
                    moneyNeeded = itemPrice - budget;
                    break;
                }              

                equipmentPriceTotal += itemPrice;
                budget -= itemPrice;
                item = Console.ReadLine();
            }

            if (item == "Stop")
            {
                Console.WriteLine($"You bought {itemCount} products for {equipmentPriceTotal:f2} leva.");
            }
            else
            {
                Console.WriteLine("You don't have enough money!");
                Console.WriteLine($"You need {moneyNeeded:f2} leva!");
            }
        }
    }
}
