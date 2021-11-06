using System;

namespace _01.SeriesCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string tvSeriesName = Console.ReadLine();
            int seasonsCount = int.Parse(Console.ReadLine());
            int episodesCount = int.Parse(Console.ReadLine());
            double minPerEpisodes = double.Parse(Console.ReadLine());

            const double adMinutes = 0.20;
            const int minLastEpisodes = 10;

            minPerEpisodes += minPerEpisodes * adMinutes; 
            
            double totalTime = Math.Floor(seasonsCount * (episodesCount * minPerEpisodes + minLastEpisodes));

            Console.WriteLine($"Total time needed to watch the {tvSeriesName} series is {totalTime} minutes.");
        }
    }
}
