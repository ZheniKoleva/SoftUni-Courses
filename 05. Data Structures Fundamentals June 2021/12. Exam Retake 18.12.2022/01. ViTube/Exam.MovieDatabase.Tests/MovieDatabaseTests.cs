using NUnit.Framework;
using System.Collections.Generic;
using System;
using Exam.MovieDatabase;
using System.Linq;
using System.Diagnostics;

public class MovieDatabaseTests
{
    private IMovieDatabase movieDatabase;

    private Actor GetRandomActor()
    {
        Random random = new Random();

        return new Actor(
                Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString(),
                random.Next(1, 1_000_000_000));
    }

    private Movie GetRandomMovie()
    {
        Random random = new Random();

        return new Movie(
                Guid.NewGuid().ToString(),
                random.Next(1, 1_000_000_000),
                Guid.NewGuid().ToString(),
                random.Next(1, 1_000_000_000),
                random.Next(1, 1_000_000_000));
    }

    [SetUp]
    public void Setup()
    {
        this.movieDatabase = new MovieDatabase();
    }

    private void PerformCorrectnessTesting(List<Action> correctnessTests)
    {
        correctnessTests.ForEach(Test =>
        {
            this.movieDatabase = new MovieDatabase();

            try { Test.Invoke(); } catch (ArgumentException) { }
        });

        this.movieDatabase = new MovieDatabase();
    }

    // Correctness Tests
    

    [Test]
    public void TestContains_WithExistentActor_ShouldReturnTrue() {
        Actor actor = GetRandomActor();
        this.movieDatabase.AddActor(actor);

        Assert.IsTrue(this.movieDatabase.Contains(actor));
    }

    [Test]
    public void TestContains_WithNonExistentActor_ShouldReturnFalse() {
        Actor actor = GetRandomActor();
        this.movieDatabase.AddActor(actor);

        Assert.IsFalse(this.movieDatabase.Contains(GetRandomActor()));
    }

    [Test]
    public void TestContains_WithExistentMovie_ShouldReturnTrue() {
        Actor actor = GetRandomActor();
        this.movieDatabase.AddActor(actor);
        Movie movie = GetRandomMovie();
        this.movieDatabase.AddMovie(actor, movie);

        Assert.IsTrue(this.movieDatabase.Contains(movie));
    }

    [Test]
    public void TestContains_WithNonExistentMovie_ShouldReturnFalse() {
        Actor actor = GetRandomActor();
        this.movieDatabase.AddActor(actor);
        Movie movie = GetRandomMovie();
        this.movieDatabase.AddMovie(actor, movie);

        Assert.IsFalse(this.movieDatabase.Contains(GetRandomMovie()));
    }

    [Test]
    public void TestGetAllMovies_WithData_ShouldReturnCorrectResults() {
        Actor actor = GetRandomActor();
        this.movieDatabase.AddActor(actor);
        Actor actor2 = GetRandomActor();
        this.movieDatabase.AddActor(actor2);
        Movie movie1 = GetRandomMovie();
        Movie movie2 = GetRandomMovie();
        Movie movie3 = GetRandomMovie();

        this.movieDatabase.AddMovie(actor, movie1);
        this.movieDatabase.AddMovie(actor, movie2);
        this.movieDatabase.AddMovie(actor2, movie3);

        HashSet<Movie> set = this.movieDatabase.GetAllMovies().ToHashSet();

        Assert.AreEqual(set.Count, 3);
        Assert.IsTrue(set.Contains(movie1));
        Assert.IsTrue(set.Contains(movie2));
        Assert.IsTrue(set.Contains(movie3));
    }

    [Test]
    public void TestGetAllMovies_WithNoData_ShouldReturnCorrectResults() {
        HashSet<Movie> set = this.movieDatabase.GetAllMovies().ToHashSet();

        Assert.AreEqual(set.Count, 0);
    }

   
    // Performance Tests

    [Test]
    public void TestContainsUser_With100000Results_ShouldPassQuickly() {
        this.PerformCorrectnessTesting(new List<Action>(new Action[]{
                this.TestContains_WithExistentActor_ShouldReturnTrue,
                this.TestContains_WithNonExistentActor_ShouldReturnFalse
        }));

        int count = 100000;

        Actor actor = null;

        for (int i = 0; i < count; i++)
        {
            if(i == count / 2)  {
                actor = GetRandomActor();
                this.movieDatabase.AddActor(actor);
            } else {
                this.movieDatabase.AddActor(GetRandomActor());
            }

        }

        Stopwatch stopwatch = new Stopwatch(); stopwatch.Start();

        this.movieDatabase.Contains(actor);

        stopwatch.Stop();

        long elapsedTime = stopwatch.ElapsedMilliseconds;

        Assert.IsTrue(elapsedTime <= 5);
    }

    [Test]
    public void TestGetAllMovies_With100000Results_ShouldPassQuickly() {
        this.PerformCorrectnessTesting(new List<Action>(new Action[]{
                this.TestGetAllMovies_WithData_ShouldReturnCorrectResults,
                this.TestGetAllMovies_WithNoData_ShouldReturnCorrectResults
        }));

        int count = 100000;

        Actor actorToDo = GetRandomActor();
        this.movieDatabase.AddActor(actorToDo);


        for (int i = 0; i < count; i++)
        {
            this.movieDatabase.AddMovie(actorToDo, GetRandomMovie());
        }

        Stopwatch stopwatch = new Stopwatch(); stopwatch.Start();

        this.movieDatabase.GetAllMovies();

        stopwatch.Stop();

        long elapsedTime = stopwatch.ElapsedMilliseconds;

        Assert.IsTrue(elapsedTime <= 10);
    }
}
