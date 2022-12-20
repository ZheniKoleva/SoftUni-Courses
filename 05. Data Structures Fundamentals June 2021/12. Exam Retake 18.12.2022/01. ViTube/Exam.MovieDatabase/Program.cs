using System;
using System.Linq;

namespace Exam.MovieDatabase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var database = new MovieDatabase();
            var actor1 = GetRandomActor();
            var actor2 = GetRandomActor();
            var actor3 = GetRandomActor();

            var movie1 = new Movie("afedegrg", 120, "t1", 10, 100);
            var movie2 = new Movie("dagesrghtr", 120, "t2", 10, 87.65);
            var movie3 = new Movie("dsgrde", 120, "t3", 10, 15.23);

            database.AddActor(actor1);
            database.AddActor(actor2);
            database.AddActor(actor3);

            database.AddMovie(actor1, movie3);
            database.AddMovie(actor1, movie2);
            database.AddMovie(actor2, movie1);
            database.AddMovie(actor2, movie3);

            var actors = database.GetActorsOrderedByMaxMovieBudgetThenByMoviesCount();
            var movies = database.GetAllMovies();

            Console.WriteLine();

        }

        private static Actor GetRandomActor()
        {
            Random random = new Random();

            return new Actor(
                    Guid.NewGuid().ToString(),
                    Guid.NewGuid().ToString(),
                    random.Next(1, 1_000_000_000));
        }
    }
}
