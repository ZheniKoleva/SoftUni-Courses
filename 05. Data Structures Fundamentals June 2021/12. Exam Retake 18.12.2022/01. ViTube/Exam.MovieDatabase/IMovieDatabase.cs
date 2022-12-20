using System;
using System.Collections.Generic;

namespace Exam.MovieDatabase
{
    public interface IMovieDatabase
    {
        void AddActor(Actor actor);

        void AddMovie(Actor actor, Movie movie);

        bool Contains(Actor actor);

        bool Contains(Movie movie);

        IEnumerable<Movie> GetAllMovies();

        IEnumerable<Actor> GetNewbieActors();

        IEnumerable<Movie> GetMoviesOrderedByBudgetThenByRating();

        IEnumerable<Actor> GetActorsOrderedByMaxMovieBudgetThenByMoviesCount();

        IEnumerable<Movie> GetMoviesInRangeOfBudget(double lower, double upper);
    }
}
