using System;

namespace _06._Fishland
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceMackerel = double.Parse(Console.ReadLine());
            double priceSprat = double.Parse(Console.ReadLine());
            double kgBonito = double.Parse(Console.ReadLine());
            double kgHorseMackerel = double.Parse(Console.ReadLine());
            double kgMussels = double.Parse(Console.ReadLine());

            double priceBonito = priceMackerel * 1.60;
            double priceHorseMackerel = priceSprat * 1.80;
            double priceMussels = 7.50;

            double totalPrice = (kgBonito * priceBonito) + (kgHorseMackerel * priceHorseMackerel) +
                (kgMussels * priceMussels);

            Console.WriteLine($"{totalPrice:f2}"); 
        }
    }
}
