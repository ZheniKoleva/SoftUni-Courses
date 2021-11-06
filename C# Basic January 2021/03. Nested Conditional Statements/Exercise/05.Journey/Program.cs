using System;

namespace _05.Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine().ToLower();

            string destination = string.Empty;
            string accomodation = string.Empty;
            double totalPrice = 0.00;

            if (budget <= 100)
            {
                destination = "Bulgaria";
                switch (season)
                {
                    case "summer":
                        accomodation = "Camp";
                        totalPrice = budget * 0.30;
                        break;
                    case "winter":
                        accomodation = "Hotel";
                        totalPrice = budget * 0.70;
                        break;
                }

            }
            else if (budget <= 1000)
            {
                destination = "Balkans";
                switch (season)
                {
                    case "summer":
                        accomodation = "Camp";
                        totalPrice = budget * 0.40;
                        break;
                    case "winter":
                        accomodation = "Hotel";
                        totalPrice = budget * 0.80;
                        break;
                }

            }
            else if (budget > 1000)
            {
                destination = "Europe";
                accomodation = "Hotel";
                totalPrice = budget * 0.90;
            }

            Console.WriteLine($"Somewhere in {destination}");
            Console.WriteLine($"{accomodation} - {totalPrice:f2}");           
        }
    }
}
