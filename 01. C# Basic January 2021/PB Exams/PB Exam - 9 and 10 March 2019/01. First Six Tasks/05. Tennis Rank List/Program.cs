using System;

namespace _05.TennisRanklist
{
    class Program
    {
        static void Main(string[] args)
        {
            int tournamentCount = int.Parse(Console.ReadLine());
            int startPoints = int.Parse(Console.ReadLine());

            int pointsSeasonTotal = 0;
            const int winerScore = 2000;
            const int finalScore = 1200;
            const int semiFinalScore = 720;

            int winsCounter = 0;

            for (int i = 0; i < tournamentCount; i++)
            {
                string stageAchieved = Console.ReadLine().ToLower();
                switch (stageAchieved)
                {
                    case "w":
                        pointsSeasonTotal += winerScore;
                        winsCounter++;
                        break;

                    case "f":
                        pointsSeasonTotal += finalScore;
                        break;

                    case "sf":
                        pointsSeasonTotal += semiFinalScore;
                        break;
                }

            }

            int totalPointsAll = startPoints + pointsSeasonTotal;
            int averagePointsSeason = pointsSeasonTotal / tournamentCount;
            double percentWins = 1.0 * winsCounter / tournamentCount * 100.00;

            Console.WriteLine($"Final points: {totalPointsAll}");
            Console.WriteLine($"Average points: {averagePointsSeason}");
            Console.WriteLine($"{percentWins:f2}% ");
        }
    }
}
