using System;

namespace _02.AddBags
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceOverWeight = double.Parse(Console.ReadLine());
            double luggageWeight = double.Parse(Console.ReadLine());
            int daysToTrip = int.Parse(Console.ReadLine());
            int bagsCount = int.Parse(Console.ReadLine());

            double priceBags = 0.00;
            
            if (luggageWeight < 10)
            {
                priceBags = priceOverWeight * 0.20;
            }
            else if (luggageWeight <= 20)
            {
                priceBags = priceOverWeight * 0.50;
            }
            else if (luggageWeight > 20)
            {
                priceBags = priceOverWeight;
            }

            if (daysToTrip > 30)
            {
                priceBags += priceBags * 0.10;
            }
            else if (daysToTrip >= 7 && daysToTrip <= 30)
            {
                priceBags += priceBags * 0.15;
            }
            else if (daysToTrip < 7)
            {
                priceBags += priceBags * 0.40;
            }

            double totalPrice = priceBags * bagsCount;

            Console.WriteLine($"The total price of bags is: {totalPrice:f2} lv. ");

        }
    }
}
