using System;

namespace _01.FoodDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int chickenMenusCount = int.Parse(Console.ReadLine());
            int fishMenusCount = int.Parse(Console.ReadLine());
            int vegeMenusCount = int.Parse(Console.ReadLine());

            const double chickenMenuPrice = 10.35;
            const double fishMenuPrice = 12.40;
            const double vegeMenuPrice = 8.15;
            const double deliveryTax = 2.50;

            double totalPriceMenus = (chickenMenusCount * chickenMenuPrice) +
                (fishMenusCount * fishMenuPrice) + (vegeMenusCount * vegeMenuPrice);

            double desertPrice = totalPriceMenus * 0.20;

            double finalPrice = totalPriceMenus + desertPrice + deliveryTax;

            Console.WriteLine($"Total: {finalPrice:f2}");
        }
    }
}
