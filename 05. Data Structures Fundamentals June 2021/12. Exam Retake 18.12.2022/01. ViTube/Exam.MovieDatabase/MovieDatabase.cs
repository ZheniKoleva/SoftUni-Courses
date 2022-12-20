using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.MovieDatabase
{
    public class MovieDatabase : IMovieDatabase
    {
        private readonly Dictionary<string, Actor> actors;
        private readonly Dictionary<string, Movie> movies;

        public MovieDatabase()
        {
            actors = new Dictionary<string, Actor>();
            movies = new Dictionary<string, Movie>();
        }

        public void AddActor(Actor actor)
        {
            if (!Contains(actor))
            {
                actors.Add(actor.Id, actor);
            }
        }

        public void AddMovie(Actor actor, Movie movie)
        {  
            if (!Contains(actor))
            {
                throw new ArgumentException();
            }

            if (!Contains(movie))
            {
                movies.Add(movie.Id, movie);
            }

            actor.Movies.Add(movies[movie.Id]);           
        }

        public bool Contains(Actor actor)
        {
            return actors.ContainsKey(actor.Id);
        }

        public bool Contains(Movie movie)
        {
            return movies.ContainsKey(movie.Id);
        }

        public IEnumerable<Actor> GetActorsOrderedByMaxMovieBudgetThenByMoviesCount()
        {
            return actors.Values
                .OrderByDescending(a => a.Movies.Count > 0 ? a.Movies.Max(m => m.Budget) : 0)
                .ThenByDescending(a => a.Movies.Count);
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            return movies.Values;
        }

        public IEnumerable<Movie> GetMoviesInRangeOfBudget(double lower, double upper)
        {
            return movies.Values
                .Where(m => m.Budget >= lower && m.Budget <= upper)
                .OrderByDescending(m => m.Rating);
        }

        public IEnumerable<Movie> GetMoviesOrderedByBudgetThenByRating()
        {
            return movies.Values
                .OrderByDescending(m => m.Budget)
                .ThenByDescending(m => m.Rating);                
        }

        public IEnumerable<Actor> GetNewbieActors()
        {
            return actors.Values
                .Where(a => a.Movies.Count == 0);
        }
    }
}
