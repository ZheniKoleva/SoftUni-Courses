using System;

namespace _03.Logistics
{
    class Program
    {
        static void Main(string[] args)
        {
            int cargoNum = int.Parse(Console.ReadLine());

            int totalTonage = 0;
            double pricePerTone = 0.00;
            double busPrice = 0.00;
            double truckPrice = 0.00;
            double trainPrice = 0.00;
            int busTonage = 0;
            int truckTonage = 0;
            int trainTonage = 0;


            for (int i = 0; i < cargoNum; i++)
            {
                int cargoTonage = int.Parse(Console.ReadLine());

                totalTonage += cargoTonage;
               
                if (cargoTonage <= 3)
                {
                    pricePerTone = 200.00;
                    busPrice += pricePerTone * cargoTonage;
                    busTonage += cargoTonage;
                }
                else if (cargoTonage <= 11)
                {
                    pricePerTone = 175.00;
                    truckPrice += pricePerTone * cargoTonage;
                    truckTonage += cargoTonage;
                }
                else if (cargoTonage >= 12)
                {
                    pricePerTone = 120.00;
                    trainPrice += pricePerTone * cargoTonage;
                    trainTonage += cargoTonage;
                }
            }           
            double averagePrice = (busPrice + truckPrice + trainPrice) / totalTonage;
            double busPercent = (busTonage * 100.00)/ totalTonage;
            double truckPercent = (truckTonage * 100.00)  / totalTonage;
            double trainPercent = (trainTonage * 100.00) / totalTonage;

            Console.WriteLine($"{averagePrice:f2}");
            Console.WriteLine($"{busPercent:f2}%");
            Console.WriteLine($"{truckPercent:f2}%");
            Console.WriteLine($"{trainPercent:f2}%");
        }
    }
}
