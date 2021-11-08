using System;

namespace _02.BraceletStand
{
    class Program
    {
        static void Main(string[] args)
        {
            double moneyPerDay = double.Parse(Console.ReadLine());
            double moneyFromSales = double.Parse(Console.ReadLine());
            double expences = double.Parse(Console.ReadLine());
            double presentPrice = double.Parse(Console.ReadLine());

            const int days = 5;

            double profit = (moneyPerDay + moneyFromSales) * days;
            profit -= expences;

            if (profit >= presentPrice)
            {
                Console.WriteLine($"Profit: {profit:f2} BGN, the gift has been purchased.");
            }
            else
            {
                double difference = presentPrice - profit;
                Console.WriteLine($"Insufficient money: {difference:f2} BGN.");
            }
        }
    }
}
