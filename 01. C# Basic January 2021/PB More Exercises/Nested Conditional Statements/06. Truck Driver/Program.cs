using System;

namespace _06._TruckDriver
{
    class Program
    {
        static void Main(string[] args)
        {
            string season = Console.ReadLine().ToLower();
            double kmPerMonth = double.Parse(Console.ReadLine());

            double kmRate = 0.00;
            double totalSum = 0.00;
            double finalSum = 0.00;

            if (kmPerMonth > 10000 && kmPerMonth <= 20000)
            {
                kmRate = 1.45;
            }
            switch (season)
            {
                case "spring":
                case "autumn":
                    if (kmPerMonth <= 5000)
                    {
                        kmRate = 0.75;
                    }
                    else if (kmPerMonth > 5000 && kmPerMonth <= 10000)
                    {
                        kmRate = 0.95;
                    }
                    break;
                case "summer":
                    if (kmPerMonth <= 5000)
                    {
                        kmRate = 0.90;
                    }
                    else if (kmPerMonth > 5000 && kmPerMonth <= 10000)
                    {
                        kmRate = 1.10;
                    }
                    break;
                case "winter":
                    if (kmPerMonth <= 5000)
                    {
                        kmRate = 1.05;
                    }
                    else if (kmPerMonth > 5000 && kmPerMonth <= 10000)
                    {
                        kmRate = 1.25;
                    }
                    break; 
            }

            totalSum = kmRate * kmPerMonth * 4;
            finalSum = totalSum * 0.90;

            Console.WriteLine($"{finalSum:f2}");
        }
    }
}
