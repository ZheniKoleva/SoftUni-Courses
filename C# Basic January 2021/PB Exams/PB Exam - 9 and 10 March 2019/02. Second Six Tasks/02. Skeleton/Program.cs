using System;

namespace _02.Skeleton
{
    class Program
    {
        static void Main(string[] args)
        {
            int minutesCheckpoint = int.Parse(Console.ReadLine());
            int secondsCheckpoint = int.Parse(Console.ReadLine());
            double gutterLenghtInMetres = double.Parse(Console.ReadLine());
            int secondsPer100Metres = int.Parse(Console.ReadLine());

            double timeCheckpointsInSeconds = minutesCheckpoint * 60 + secondsCheckpoint;

            double secondsGutterPass = (gutterLenghtInMetres / 100) * secondsPer100Metres;
            double timeDescending = (gutterLenghtInMetres / 120) * 2.5;

            double finalTime = secondsGutterPass - timeDescending;

            if (finalTime <= timeCheckpointsInSeconds)
            {
                Console.WriteLine("Marin Bangiev won an Olympic quota!");
                Console.WriteLine($"His time is {finalTime:f3}.");
            }
            else
            {
                double secondsNeeded = finalTime - timeCheckpointsInSeconds;
                Console.WriteLine($"No, Marin failed! He was {secondsNeeded:f3} second slower.");
            }
        }
    }
}
