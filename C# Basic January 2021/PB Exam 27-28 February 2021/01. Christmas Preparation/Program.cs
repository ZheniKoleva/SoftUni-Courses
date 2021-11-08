using System;

namespace _01.ChristmasPreparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int paperRollsCount = int.Parse(Console.ReadLine());
            int clothRollsCount = int.Parse(Console.ReadLine());
            double glueAmount = double.Parse(Console.ReadLine());
            int discount = int.Parse(Console.ReadLine());

            const double pricePerpaperRoll = 5.80;
            const double pricePerClothRoll = 7.20;
            const double priceOfGlue = 1.20;

            double paperPrice = paperRollsCount * pricePerpaperRoll;
            double clothPrice = clothRollsCount * pricePerClothRoll;
            double gluePrice = glueAmount * priceOfGlue;

            double totalPrice = paperPrice + clothPrice + gluePrice;
            totalPrice -= (totalPrice * discount) / 100;

            Console.WriteLine($"{totalPrice:f3}");
        }
    }
}
