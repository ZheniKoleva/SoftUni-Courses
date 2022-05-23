using System;

namespace _01.SuppliesForSchool
{
    class Program
    {
        static void Main(string[] args)
        {
            int pens = int.Parse(Console.ReadLine());
            int markers = int.Parse(Console.ReadLine());
            double detergent = double.Parse(Console.ReadLine());
            int discount = int.Parse(Console.ReadLine());

            const double pricePens = 5.80; 
            const double priceMarkers = 7.20; 
            const double priceDetergent = 1.20;

            double finalPrice = (pens * pricePens) + (markers * priceMarkers) + (detergent * priceDetergent);
            finalPrice -= (finalPrice * discount) / 100;

            Console.WriteLine($"{finalPrice:f3}");
        }
    }
}
