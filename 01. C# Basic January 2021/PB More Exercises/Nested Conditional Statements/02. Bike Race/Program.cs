using System;

namespace _02._BikeRace
{
    class Program
    {
        static void Main(string[] args)
        {
            int juniorCyclisistsNumber = int.Parse(Console.ReadLine());
            int seniorCyclisistsNumber = int.Parse(Console.ReadLine());
            string roadType = Console.ReadLine().ToLower();

            double juniorPriceTax = 0.0;
            double seniorPriceTax = 0.0;
            double totalSumFromTaxes = 0.0;
            double finalSum = 0.0;

            switch (roadType)
            {
                case "trail":
                    juniorPriceTax = 5.50;
                    seniorPriceTax = 7.00;
                    break;
                case "cross-country":
                    juniorPriceTax = 8.00;
                    seniorPriceTax = 9.50;
                    break;
                case "downhill":
                    juniorPriceTax = 12.25;
                    seniorPriceTax = 13.75;
                    break;
                case "road":
                    juniorPriceTax = 20.00;
                    seniorPriceTax = 21.50;
                    break;
            }

            totalSumFromTaxes = (juniorPriceTax * juniorCyclisistsNumber) + (seniorPriceTax * seniorCyclisistsNumber);

            if ((juniorCyclisistsNumber + seniorCyclisistsNumber) >= 50 && roadType == "cross-country")
            {
                totalSumFromTaxes -= totalSumFromTaxes * 0.25; 
            }

            finalSum = totalSumFromTaxes * 0.95;
            Console.WriteLine($"{finalSum:f2}");
        }
    }
}
