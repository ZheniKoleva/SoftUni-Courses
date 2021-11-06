using System;

namespace _06.GodzillaVsKong
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int extrasNumber = int.Parse(Console.ReadLine());
            double priceClouthForOne = double.Parse(Console.ReadLine());

            double decor = budget * 0.10;
            double priceClouth = priceClouthForOne * extrasNumber;
            double totalExpenses = 0.00;

            if (extrasNumber >= 150)
            {
                priceClouth -= priceClouth * 0.10;
            }
            totalExpenses = priceClouth + decor;
            if (budget >= totalExpenses)
            {
                double moneyLeft = budget - totalExpenses;
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {moneyLeft:f2} leva left.");
            }
            else if (budget < totalExpenses)
            {
                double moneyNeeds = totalExpenses - budget;
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {moneyNeeds:f2} leva more.");
            }

        }
    }
}
