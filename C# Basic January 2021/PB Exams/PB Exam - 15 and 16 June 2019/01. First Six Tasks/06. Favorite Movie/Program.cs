using System;

namespace _06.FavoriteMovie
{
    class Program
    {
        static void Main(string[] args)
        {
            string movieName = string.Empty;

            int pointsMax = int.MinValue;
            string moviePointsMax = string.Empty;

            bool flag = false;

            while (movieName != "STOP")
            {
                for (int movieCount = 1; movieCount <= 7; movieCount++)
                {
                    movieName = Console.ReadLine();

                    if (movieName == "STOP")
                    {
                        flag = true;
                        break;
                    }

                    int moviePoints = 0;

                    for (int index = 0; index < movieName.Length; index++)
                    {
                        moviePoints += movieName[index];

                        if (movieName[index] >= 97 && movieName[index] <= 122)
                        {
                            moviePoints -= movieName.Length * 2;
                        }
                        else if (movieName[index] >= 65 && movieName[index] <= 90)
                        {
                            moviePoints -= movieName.Length;
                        }

                    }

                    if (moviePoints > pointsMax)
                    {
                        pointsMax = moviePoints;
                        moviePointsMax = movieName;
                    }

                }

                if (flag)
                {
                    break;
                }

                Console.WriteLine("The limit is reached.");
                break;

            }

            Console.WriteLine($"The best movie for you is {moviePointsMax} with {pointsMax} ASCII sum.");

        }
    }
}
