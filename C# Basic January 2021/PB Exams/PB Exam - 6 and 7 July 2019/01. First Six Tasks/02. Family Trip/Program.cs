using System;

namespace _02.FamilyTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int nightsCount = int.Parse(Console.ReadLine());
            double pricePerNight = double.Parse(Console.ReadLine());
            int extraExpenses = int.Parse(Console.ReadLine());

            if (nightsCount > 7)
            {
                pricePerNight -= pricePerNight * 0.05;
            }

            double totalSum = nightsCount * pricePerNight + (budget * extraExpenses) / 100;
            double difference = budget - totalSum;

            if (budget >= totalSum)
            {
                Console.WriteLine($"Ivanovi will be left with {difference:f2} leva after vacation.");
            }
            else
            {
                Console.WriteLine($"{Math.Abs(difference):f2} leva needed.");
            }

        }
    }
}
