using System;

namespace _04.FishingBoat
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine().ToLower();
            int fishermen = int.Parse(Console.ReadLine());

            const double rentSpring = 3000.00;
            const double rentSummerAndAutumn = 4200.00;
            const double rentWinter = 2600.00;

            double totalPrice = 0.00;
           
            switch (season)
            {
                case "spring":
                    totalPrice = rentSpring;
                    break;
                case "summer":
                case "autumn":
                    totalPrice = rentSummerAndAutumn;
                    break;
                case "winter":
                    totalPrice = rentWinter;
                    break;
            }

            if (fishermen <= 6)
            {
                totalPrice -= totalPrice * 0.10;
            }
            else if (fishermen <= 11)
            {
                totalPrice -= totalPrice * 0.15;
            }
            else if (fishermen > 12)
            {
                totalPrice -= totalPrice * 0.25;
            }

            if (fishermen % 2 == 0 && season != "autumn")
            {
                totalPrice -= totalPrice * 0.05;
            }

            if (totalPrice <= budget)
            {
                double moneyLeft = budget - totalPrice;
                Console.WriteLine($"Yes! You have {moneyLeft:f2} leva left.");
            }
            else
            {
                double moneyNeeded = totalPrice - budget;
                Console.WriteLine($"Not enough money! You need {moneyNeeded:f2} leva.");
            }
        }
    }
}
