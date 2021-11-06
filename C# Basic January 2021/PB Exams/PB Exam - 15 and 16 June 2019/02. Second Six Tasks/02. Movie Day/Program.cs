using System;

namespace _02.MovieDay
{
    class Program
    {
        static void Main(string[] args)
        {
            int shotTime = int.Parse(Console.ReadLine());
            int scenesCount = int.Parse(Console.ReadLine());
            int scenesTime = int.Parse(Console.ReadLine());

            double preparationTime = shotTime * 0.15;

            double totalTimeForShooting = scenesCount * scenesTime + preparationTime;

            if (shotTime >= totalTimeForShooting)
            {
                double timeLeft = 1.0 * shotTime - totalTimeForShooting;
                Console.WriteLine($"You managed to finish the movie on time! You have {Math.Round(timeLeft)} minutes left!");
            }
            else
            {
                double timeNeeded = totalTimeForShooting - shotTime;
                Console.WriteLine($"Time is up! To complete the movie you need {timeNeeded} minutes.");
            }

        }
    }
}
