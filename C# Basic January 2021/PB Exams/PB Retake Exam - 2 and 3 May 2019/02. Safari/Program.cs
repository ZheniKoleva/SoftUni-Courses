using System;

namespace _02.Safari
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double gasNeeded = double.Parse(Console.ReadLine());
            string dayOfWeek = Console.ReadLine().ToLower();

            const double gasPricePerLiter = 2.10;
            const int guideTax = 100;
            const double saturdayDiscount = 0.10;
            const double sundayDiscount = 0.20;

            double totalPrice = (gasNeeded * gasPricePerLiter) + guideTax;

            switch (dayOfWeek)
            {
                case "saturday":
                    totalPrice -= totalPrice * saturdayDiscount;
                    break;

                case "sunday":
                    totalPrice -= totalPrice * sundayDiscount;
                    break;
            }

            if (budget >= totalPrice)
            {
                double moneyLeft = budget - totalPrice;
                Console.WriteLine($"Safari time! Money left: {moneyLeft:f2} lv.");
            }
            else
            {
                double moneyNeed = totalPrice - budget;
                Console.WriteLine($"Not enough money! Money needed: {moneyNeed:f2} lv.");
            }
        }
    }
}
