using System;

namespace _04._VegetableMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            double pricePerKgVegetables = double.Parse(Console.ReadLine());
            double pricePerKgFriuts = double.Parse(Console.ReadLine());
            double kgVegetables = double.Parse(Console.ReadLine());
            double kgFriuts = double.Parse(Console.ReadLine());

            double priceVegetables = pricePerKgVegetables * kgVegetables;
            double priceFriuts = pricePerKgFriuts * kgFriuts;
            double totalPriceEuro = (priceFriuts + priceVegetables) / 1.94;
           
            Console.WriteLine($"{totalPriceEuro:f2}");
        }
    }
}
