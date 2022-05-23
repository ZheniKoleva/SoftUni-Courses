using System;

namespace _03._Flowers
{
    class Program
    {
        static void Main(string[] args)
        {
            int countChrysanthemum = int.Parse(Console.ReadLine());
            int countRoses = int.Parse(Console.ReadLine());
            int countTulips = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            char holidayOrNot = char.Parse(Console.ReadLine());

            double bouquetPrice = 0.00;
            double chrysanthemumPrice = 0.00;
            double rosesPrice = 0.00;
            double tulipsPrice = 0.00;

            switch (season)
            {
                case "Spring":
                case "Summer":
                    chrysanthemumPrice = 2.00;
                    rosesPrice = 4.10;
                    tulipsPrice = 2.50;
                    break;
                case "Autumn":
                case "Winter":
                    chrysanthemumPrice = 3.75;
                    rosesPrice = 4.50;
                    tulipsPrice = 4.15;
                    break;
            }

            bouquetPrice = (rosesPrice * countRoses) + (tulipsPrice * countTulips) +
                (chrysanthemumPrice * countChrysanthemum);

            if (holidayOrNot == 'Y')
            {
                bouquetPrice += bouquetPrice * 0.15;
            }          
            if (countTulips > 7 && season == "Spring")
            {
                bouquetPrice -= bouquetPrice * 0.05;
            }
            if (countRoses >= 10 && season == "Winter")
            {
                bouquetPrice -= bouquetPrice * 0.10;
            }
            if ((countTulips + countRoses + countChrysanthemum) > 20)
            {
                bouquetPrice -= bouquetPrice * 0.20;
            }
            bouquetPrice += 2.00;

            Console.WriteLine($"{bouquetPrice:f2}");
        }
    }
}
