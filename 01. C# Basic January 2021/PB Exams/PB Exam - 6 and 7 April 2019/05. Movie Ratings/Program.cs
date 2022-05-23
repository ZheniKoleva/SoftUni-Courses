using System;

namespace _05.MovieRatings
{
    class Program
    {
        static void Main(string[] args)
        {
            int moviesCount = int.Parse(Console.ReadLine());

            double ratingMax = double.MinValue;
            double ratingMin = double.MaxValue;

            string movieRatingMax = string.Empty;
            string movieRatingMin = string.Empty;

            double sumRaitings = 0.00;

            for (int i = 1; i <= moviesCount; i++)
            {
                string movieName = Console.ReadLine();
                double movieRating = double.Parse(Console.ReadLine());
                sumRaitings += movieRating;

                if (movieRating < ratingMin)
                {
                    ratingMin = movieRating;
                    movieRatingMin = movieName;
                }

                if (movieRating > ratingMax)
                {
                    ratingMax = movieRating;
                    movieRatingMax = movieName;
                }

            }

            double averageRating = sumRaitings / moviesCount;

            Console.WriteLine($"{movieRatingMax} is with highest rating: {ratingMax:f1}");
            Console.WriteLine($"{movieRatingMin} is with lowest rating: {ratingMin:f1}");
            Console.WriteLine($"Average rating: {averageRating:f1}");
        }
    }
}
