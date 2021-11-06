using System;

namespace _01.EasterBakery
{
    class Program
    {
        static void Main(string[] args)
        {
            double flourPrice = double.Parse(Console.ReadLine());
            double amountFlour = double.Parse(Console.ReadLine());
            double amountSugar = double.Parse(Console.ReadLine());
            int eggsShells = int.Parse(Console.ReadLine());
            int yeastPackage = int.Parse(Console.ReadLine());

            double sugarPrice = flourPrice * 0.75;
            double eggsShellsPrice = flourPrice * 1.10;
            double yeastPrice = sugarPrice * 0.20;

            double flourTotalPrice = flourPrice * amountFlour;
            double sugarTotalPrice = sugarPrice * amountSugar;
            double eggsTotalPrice = eggsShellsPrice * eggsShells;
            double yeastTotalPrice = yeastPrice * yeastPackage;

            double finalPrice = flourTotalPrice + sugarTotalPrice + eggsTotalPrice + yeastTotalPrice;
            Console.WriteLine($"{finalPrice:f2}");
        }
    }
}
