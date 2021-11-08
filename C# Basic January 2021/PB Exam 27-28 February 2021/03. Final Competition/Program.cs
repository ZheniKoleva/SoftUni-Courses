using System;

namespace _03.FinalCompetition
{
    class Program
    {
        static void Main(string[] args)
        {
            int dancersCount = int.Parse(Console.ReadLine());
            double points = double.Parse(Console.ReadLine());
            string season = Console.ReadLine().ToLower();
            string place = Console.ReadLine();

            double moneyPrice = points * dancersCount;
            double expenses = 0.00;

            switch (place)
            {
                case "Bulgaria":                    
                    switch (season)
                    {
                        case "summer":
                            expenses = 0.05;
                            break;

                        case "winter":
                            expenses = 0.08;
                            break;
                    }
                    break;

                case "Abroad":
                    moneyPrice += moneyPrice * 0.50;
                    switch (season)
                    {
                        case "summer":
                            expenses = 0.10;
                            break;

                        case "winter":
                            expenses = 0.15;
                            break;
                    }
                    break;
            }

            moneyPrice -= moneyPrice * expenses;
            double charityMoney = moneyPrice * 0.75;
            moneyPrice -= charityMoney;
            double moneyPerDancer = moneyPrice / dancersCount;

            Console.WriteLine($"Charity - {charityMoney:f2}");
            Console.WriteLine($"Money per dancer - {moneyPerDancer:f2}");
        }
    }
}
