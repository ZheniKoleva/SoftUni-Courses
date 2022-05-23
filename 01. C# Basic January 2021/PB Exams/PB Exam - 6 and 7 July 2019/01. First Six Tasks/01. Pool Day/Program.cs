using System;

namespace _01.PoolDay
{
    class Program
    {
        static void Main(string[] args)
        {
            int peopleCount = int.Parse(Console.ReadLine());
            double enteranceTax = double.Parse(Console.ReadLine());
            double sunbedPrice = double.Parse(Console.ReadLine());
            double umbrellaPrice = double.Parse(Console.ReadLine());

            double umbrellasCount = Math.Ceiling(1.0* peopleCount / 2);
            double sunbedCount = Math.Ceiling(peopleCount * 0.75);

            double totalSum = enteranceTax * peopleCount + sunbedCount * sunbedPrice + 
                umbrellaPrice * umbrellasCount;
            Console.WriteLine($"{totalSum:f2} lv.");
        }
    }
}
