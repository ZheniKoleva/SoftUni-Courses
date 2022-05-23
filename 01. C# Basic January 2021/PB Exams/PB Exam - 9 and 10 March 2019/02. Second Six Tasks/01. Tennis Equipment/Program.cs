using System;

namespace _01.TennisEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double tennisRacketPrice = double.Parse(Console.ReadLine());
            int tennisRacketCount = int.Parse(Console.ReadLine());
            int sneakersCount = int.Parse(Console.ReadLine());

            double sneakersPrice = tennisRacketPrice / 6;

            double tennisRacketTotalPrice = tennisRacketCount * tennisRacketPrice;
            double sneakersTotalPrice = sneakersCount * sneakersPrice;

            double otherEquipment = (tennisRacketTotalPrice + sneakersTotalPrice) * 0.20;

            double totalPriceAll = tennisRacketTotalPrice + sneakersTotalPrice + otherEquipment;

            Console.WriteLine($"Price to be paid by Djokovic {Math.Floor(totalPriceAll / 8)}");
            Console.WriteLine($"Price to be paid by sponsors {Math.Ceiling(totalPriceAll * 7 / 8)}");
        }
    }
}
