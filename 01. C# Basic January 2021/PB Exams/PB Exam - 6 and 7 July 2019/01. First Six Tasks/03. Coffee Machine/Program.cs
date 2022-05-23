using System;

namespace _03.CoffeeMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            string drinkType = Console.ReadLine();
            string sugarPresence = Console.ReadLine().ToLower();
            int drinksCount = int.Parse(Console.ReadLine());

            double drinkPrice = 0.00;

            switch (drinkType)
            {
                case "Espresso":
                    switch (sugarPresence)
                    {
                        case "without":
                            drinkPrice = 0.90;
                            break;
                        case "normal":
                            drinkPrice = 1.00;
                            break;
                        case "extra":
                            drinkPrice = 1.20;
                            break;                        
                    }
                    break;

                case "Cappuccino":
                    switch (sugarPresence)
                    {
                        case "without":
                            drinkPrice = 1.00;
                            break;
                        case "normal":
                            drinkPrice = 1.20;
                            break;
                        case "extra":
                            drinkPrice = 1.60;
                            break;
                    }
                    break;                   

                case "Tea":
                    switch (sugarPresence)
                    {
                        case "without":
                            drinkPrice = 0.50;
                            break;
                        case "normal":
                            drinkPrice = 0.60;
                            break;
                        case "extra":
                            drinkPrice = 0.70;
                            break;
                    }
                    break;

            }

            double totalSum = drinkPrice * drinksCount;

            if (sugarPresence == "without")
            {
                totalSum -= totalSum * 0.35;
            }

            if (drinkType == "Espresso" && drinksCount >= 5)
            {
                totalSum -= totalSum * 0.25;
            }

            if (totalSum > 15.00)
            {
                totalSum -= totalSum * 0.20;
            }

            Console.WriteLine($"You bought {drinksCount} cups of {drinkType} for {totalSum:f2} lv.");
        }
    }
}
