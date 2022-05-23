using System;

namespace _07._Toy_Shop
{
    class Program
    {
        static void Main(string[] args)
        {          
            double holidayPrice = double.Parse(Console.ReadLine());
            int numPuzzels = int.Parse(Console.ReadLine());
            int numDolls = int.Parse(Console.ReadLine());
            int numBears = int.Parse(Console.ReadLine());
            int numMinions = int.Parse(Console.ReadLine());
            int numTrucks = int.Parse(Console.ReadLine());

            double profit = (numPuzzels * 2.60) + (numDolls * 3.00) + (numBears * 4.10) + 
                (numMinions * 8.20) + (numTrucks * 2.00);
            int numToys = numPuzzels + numDolls + numBears + numMinions + numTrucks;
            double difference = 0.00;

            if (numToys >= 50)
            {
                profit -= profit * 0.25;
            }

            profit -= profit * 0.10;

            if (profit >= holidayPrice)
            {
                difference = profit - holidayPrice;
                Console.WriteLine($"Yes! {difference:f2} lv left.");
            }
            else
            {
                difference = holidayPrice - profit;
                Console.WriteLine($"Not enough money! {difference:f2} lv needed.");
            }
        }
    }
}
