using System;

namespace _02.LunchBreak
{
    class Program
    {
        static void Main(string[] args)
        {
            string tvSeriesName = Console.ReadLine();
            int episodeDuration = int.Parse(Console.ReadLine());
            int breakDuration = int.Parse(Console.ReadLine());

            double lunchTime = 1.0 * breakDuration / 8;
            double restTime = 1.0 * breakDuration / 4;

            double timeBusy = lunchTime + restTime;
            double timeLeft = 1.0 * breakDuration - timeBusy;            

            if (timeLeft >= episodeDuration)
            {
                timeLeft -= episodeDuration;
                Console.WriteLine($"You have enough time to watch {tvSeriesName} and left with {Math.Ceiling(timeLeft)} minutes free time.");
            }
            else
            {
                double timeNeeded = 1.0 * episodeDuration - timeLeft;
                Console.WriteLine($"You don't have enough time to watch {tvSeriesName}, you need {Math.Ceiling(timeNeeded)} more minutes.");
            }
        }
    }
}
