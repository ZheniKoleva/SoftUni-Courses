using System;

namespace _01.RoomPainting
{
    class Program
    {
        static void Main(string[] args)
        {
            int paintBoxesCount = int.Parse(Console.ReadLine()); 
            int wallapperRollsCount = int.Parse(Console.ReadLine()); 
            double glovesPrice = double.Parse(Console.ReadLine()); 
            double brushPrice = double.Parse(Console.ReadLine());

            const double paintPricePerBox = 21.50;
            const double wallpaperPricePerRoll = 5.20;

            double glovesCount = Math.Ceiling(wallapperRollsCount * 0.35);
            double brushesCount = Math.Floor(paintBoxesCount * 0.48);

            double totalPrice = (paintBoxesCount * paintPricePerBox) +
                (wallapperRollsCount * wallpaperPricePerRoll) +
                (glovesCount * glovesPrice) + (brushesCount * brushPrice);

            double deliveryPrice = totalPrice / 15;

            Console.WriteLine($"This delivery will cost {deliveryPrice:f2} lv.");

        }
    }
}
