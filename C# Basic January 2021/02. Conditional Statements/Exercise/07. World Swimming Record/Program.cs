using System;

namespace _07.WorldSwimmingRecord
{
    class Program
    {
        static void Main(string[] args)
        {
            double wordRecord = double.Parse(Console.ReadLine());
            double distance = double.Parse(Console.ReadLine());
            double timeOneMeter = double.Parse(Console.ReadLine());

            double resistanceDelay = Math.Floor(distance / 15) * 12.5;
            double totalTime = distance * timeOneMeter + resistanceDelay;

            if (wordRecord > totalTime)
            {                
                Console.WriteLine($"Yes, he succeeded! The new world record is {totalTime:f2} seconds.");
            }
            else 
            {
                double timeMore = totalTime - wordRecord;
                Console.WriteLine($"No, he failed! He was {timeMore:f2} seconds slower.");
            }
        }
    }
}
