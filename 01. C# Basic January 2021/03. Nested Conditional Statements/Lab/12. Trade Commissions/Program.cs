using System;

namespace _12.TradeCommissions
{
    class Program
    {
        static void Main(string[] args)
        {
            string town = Console.ReadLine().ToLower();
            double sales = double.Parse(Console.ReadLine());

            double commissionPercent = 0.0;
            double commission = 0.0;

            bool validTown = (town == "sofia") || (town == "varna") || (town == "plovdiv");
            bool inValidSales = sales < 0;

            if (!validTown || inValidSales)
            {
                Console.WriteLine("error");
            }
            else if (sales >= 0 && sales <= 500)
            {
                switch (town)
                {
                    case "sofia":
                        commissionPercent = 0.05;
                        break;
                    case "plovdiv":
                        commissionPercent = 0.055;
                        break;
                    case "varna":
                        commissionPercent = 0.045;
                        break;                    
                }
            }
            else if (sales <= 1000)
            {
                switch (town)
                {
                    case "sofia":
                        commissionPercent = 0.07;
                        break;
                    case "plovdiv":
                        commissionPercent = 0.08;
                        break;
                    case "varna":
                        commissionPercent = 0.075;
                        break;                  
                }
            }
            else if (sales <= 10000)
            {
                switch (town)
                {
                    case "sofia":
                        commissionPercent = 0.08;
                        break;
                    case "plovdiv":
                        commissionPercent = 0.12;
                        break;
                    case "varna":
                        commissionPercent = 0.10;
                        break;                   
                }
            }
            else if (sales > 10000)
            {
                switch (town)
                {
                    case "sofia":
                        commissionPercent = 0.12;
                        break;
                    case "plovdiv":
                        commissionPercent = 0.145;
                        break;
                    case "varna":
                        commissionPercent = 0.13;
                        break;                    
                }
            }
            
            commission = sales * commissionPercent;
            if (commission > 0)
            {
                Console.WriteLine($"{commission:f2}");
            }
        }
    }
}
