using System;

namespace _02.MountainRun
{
    class Program
    {
        static void Main(string[] args)
        {
            double recordInSeconds = double.Parse(Console.ReadLine());
            double distanceInMetres = double.Parse(Console.ReadLine());
            double secondsPerMeter = double.Parse(Console.ReadLine());

            double secondsDelay = Math.Floor(distanceInMetres / 50) * 30;

            double totalTime = (distanceInMetres * secondsPerMeter) + secondsDelay;

            if (recordInSeconds > totalTime)
            {
                Console.WriteLine($"Yes! The new record is {totalTime:f2} seconds.");
            }
            else
            {
                Console.WriteLine($"No! He was {(totalTime - recordInSeconds):f2} seconds slower.");
            }

        }
    }
}
