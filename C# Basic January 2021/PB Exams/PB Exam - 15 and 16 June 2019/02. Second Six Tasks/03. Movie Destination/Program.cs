using System;

namespace _03.MovieDestination
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string destination = Console.ReadLine();
            string season = Console.ReadLine().ToLower();
            int daysCount = int.Parse(Console.ReadLine());

            const double discountDubai = 0.30;
            const double increaseSofia = 0.25;

            int pricePerDay = 0;           

            switch (destination)
            {
                case "Dubai":
                    switch (season)
                    {
                        case "winter":
                            pricePerDay = 45000;
                            break;

                        case "summer":
                            pricePerDay = 40000;
                            break;
                    }
                    break;

                case "Sofia":
                    switch (season)
                    {
                        case "winter":
                            pricePerDay = 17000;
                            break;

                        case "summer":
                            pricePerDay = 12500;
                            break;
                    }
                    break;

                case "London":
                    switch (season)
                    {
                        case "winter":
                            pricePerDay = 24000;
                            break;

                        case "summer":
                            pricePerDay = 20250;
                            break;
                    }
                    break;
               
            }

            double totalCosts = pricePerDay * daysCount;

            if (destination == "Dubai")
            {
                totalCosts -= totalCosts * discountDubai;
            }
            else if (destination == "Sofia")
            {
                totalCosts += totalCosts * increaseSofia;
            }

            double moneyDifference = budget - totalCosts;

            if (budget >= totalCosts)
            {                
                Console.WriteLine($"The budget for the movie is enough! We have {moneyDifference:f2} leva left!");
            }
            else
            {               
                Console.WriteLine($"The director needs {Math.Abs(moneyDifference):f2} leva more!");
            }

        }
    }
}
