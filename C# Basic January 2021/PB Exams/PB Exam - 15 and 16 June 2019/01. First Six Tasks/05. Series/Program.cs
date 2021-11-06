using System;

namespace _05.Series
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int seriesCount = int.Parse(Console.ReadLine());

            double totalPrice = 0.00;

            for (int series = 0; series < seriesCount; series++)
            {
                string seriesName = Console.ReadLine();
                double seriesPrice = double.Parse(Console.ReadLine());

                switch (seriesName)
                {
                    case "Thrones":
                        seriesPrice -= seriesPrice * 0.50;
                        break;
                    case "Lucifer":
                        seriesPrice -= seriesPrice * 0.40;
                        break;
                    case "Protector":
                        seriesPrice -= seriesPrice * 0.30;
                        break;
                    case "TotalDrama":
                        seriesPrice -= seriesPrice * 0.20;
                        break;
                    case "Area":
                        seriesPrice -= seriesPrice * 0.10;
                        break;

                }

                totalPrice += seriesPrice;
            }

            if (budget >= totalPrice)
            {
                double moneyLeft = budget - totalPrice;
                Console.WriteLine($"You bought all the series and left with {moneyLeft:f2} lv.");
            }
            else
            {
                double moneyNeed = totalPrice - budget;
                Console.WriteLine($"You need {moneyNeed:f2} lv. more to buy the series!");
            }
        }
    }
}
