using System;

namespace _06.GoldMine
{
    class Program
    {
        static void Main(string[] args)
        {
            int locationsCount = int.Parse(Console.ReadLine());

            for (int location = 1; location <= locationsCount; location++)
            {
                double espectedYieldPerDay = double.Parse(Console.ReadLine());
                int daysCount = int.Parse(Console.ReadLine());

                double actualYield = 0.00;

                for (int day = 1; day <= daysCount; day++)
                {
                    actualYield += double.Parse(Console.ReadLine());

                }

                double actualYieldAverage = actualYield / daysCount;

                if (actualYieldAverage >= espectedYieldPerDay)
                {
                    Console.WriteLine($"Good job! Average gold per day: {actualYieldAverage:f2}.");

                }
                else
                {
                    double yieldNeeded = espectedYieldPerDay - actualYieldAverage;
                    Console.WriteLine($"You need { yieldNeeded:f2} gold.");

                }

            }

        }
    }
}
