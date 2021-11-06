using System;

namespace _05._Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine().ToLower();

            string destination = "";
            string accomodation = "";
            double price = 0.00;

            switch (season)
            {
                case "summer":
                    destination = "Alaska";
                    break;
                case "winter":
                    destination = "Morocco";
                    break;
            }
            if (budget <= 1000)
            {
                accomodation = "Camp";
                if (season == "summer")
                {                    
                    price = budget * 0.65;
                }
                else if (season == "winter")
                {                    
                    price = budget * 0.45;
                }
            }
            else if (budget > 1000 && budget <= 3000)
            {
                accomodation = "Hut";
                if (season == "summer")
                {                    
                    price = budget * 0.80;
                }
                else if (season == "winter")
                {                    
                    price = budget * 0.60;
                }
            }
            else if (budget > 3000)
            {
                accomodation = "Hotel";
                price = budget * 0.90;                
            }

            Console.WriteLine($"{destination} - {accomodation} - {price:f2}");
        }
    }
}
