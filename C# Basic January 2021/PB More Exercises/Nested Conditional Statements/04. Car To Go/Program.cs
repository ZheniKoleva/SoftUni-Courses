using System;

namespace _04._CarToGo
{
    class Program
    {
        static void Main(string[] args)
        {
           double budget = double.Parse(Console.ReadLine());
           string season = Console.ReadLine().ToLower();

            string classType = "";
            string carType = "";
            double carPrice = 0.00;

            if (budget <= 100)
            {
                classType = "Economy class";
                if (season == "summer")
                {
                    carType = "Cabrio";
                    carPrice = budget * 0.35;
                }
                else if (season == "winter")
                {
                    carType = "Jeep";
                    carPrice = budget * 0.65;
                }
            }
            else if (budget > 100 && budget <= 500)
            {
                classType = "Compact class";
                if (season == "summer")
                {
                    carType = "Cabrio";
                    carPrice = budget * 0.45;
                }
                else if (season == "winter")
                {
                    carType = "Jeep";
                    carPrice = budget * 0.80;
                }
            }
            else if (budget > 500)
            {
                classType = "Luxury class";
                carType = "Jeep";
                carPrice = budget * 0.90;
            }

            Console.WriteLine(classType);
            Console.WriteLine($"{carType} - {carPrice:f2}");
        }
    }
}
