using Exam.DeliveriesManager;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public class Tests
{
    private IAirlinesManager airlinesManager;

    private Airline GetRandomAirline()
    {
        Random random = new Random();

        return new Airline(
                Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString(),
                random.Next(1, 1_000_000_000));
    }

    private Flight GetRandomFlight()
    {
        Random random = new Random();

        return new Flight(
                Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString(),
                (random.Next(1, 1_000) < 500));
    }

    [SetUp]
    public void Setup()
    {
        this.airlinesManager = new AirlinesManager();
    }

    private void PerformCorrectnessTesting(List<Action> correctnessTests)
    {
        correctnessTests.ForEach(Test =>
        {
            this.airlinesManager = new AirlinesManager();

            try { Test.Invoke(); } catch (ArgumentException) { }
        });

        this.airlinesManager = new AirlinesManager();
    }

    // Correctness Testing

    [Test]
    public void TestContains_WithExistentAirline_ShouldReturnTrue()
    {
        Airline airline = GetRandomAirline();
        this.airlinesManager.AddAirline(airline);

        Assert.IsTrue(this.airlinesManager.Contains(airline));
    }

    [Test]
    public void TestContains_WithNonExistentAirline_ShouldReturnFalse()
    {
        Airline airline = GetRandomAirline();
        this.airlinesManager.AddAirline(airline);

        Assert.IsFalse(this.airlinesManager.Contains(GetRandomAirline()));
    }

    [Test]
    public void TestContains_WithExistentFlight_ShouldReturnTrue()
    {
        Airline airline = GetRandomAirline();
        Flight flight = GetRandomFlight();
        this.airlinesManager.AddAirline(airline);
        this.airlinesManager.AddFlight(airline, flight);

        Assert.IsTrue(this.airlinesManager.Contains(flight));
    }

    [Test]
    public void TestContains_WithNonExistentFlight_ShouldReturnFalse()
    {
        Airline airline = GetRandomAirline();
        Flight flight = GetRandomFlight();
        this.airlinesManager.AddAirline(airline);
        this.airlinesManager.AddFlight(airline, flight);

        Assert.IsFalse(this.airlinesManager.Contains(GetRandomFlight()));
    }

    [Test]
    public void TestAirlinesOrdered_WithData_ShouldReturnCorrectResults()
    {
        Airline airline = new Airline("a1", "a2", 4);
        Airline airline2 = new Airline("a2", "a1", 4);
        Airline airline3 = new Airline("a3", "a3", 4);
        Airline airline4 = new Airline("a4", "a4", 10);
        Airline airline5 = new Airline("a5", "a5", 7);

        Flight flight1 = new Flight("a1", "d", "a", "b", false);
        Flight flight2 = new Flight("a2", "c", "a", "b", true);
        Flight flight3 = new Flight("a3", "b", "a", "b", true);
        Flight flight4 = new Flight("a4", "a", "a", "b", false);

        this.airlinesManager.AddAirline(airline);
        this.airlinesManager.AddAirline(airline2);
        this.airlinesManager.AddAirline(airline3);
        this.airlinesManager.AddAirline(airline4);
        this.airlinesManager.AddAirline(airline5);
        this.airlinesManager.AddFlight(airline, flight1);
        this.airlinesManager.AddFlight(airline, flight2);
        this.airlinesManager.AddFlight(airline2, flight3);
        this.airlinesManager.AddFlight(airline2, flight4);

        List<Airline> list = this.airlinesManager.GetAirlinesOrderedByRatingThenByCountOfFlightsThenByName().ToList();

        Assert.AreEqual(list.Count, 5);
        Assert.AreEqual(airline4, list[0]);
        Assert.AreEqual(airline5, list[1]);
        Assert.AreEqual(airline2, list[2]);
        Assert.AreEqual(airline, list[3]);
        Assert.AreEqual(airline3, list[4]);
    }

    // Performance Tests


    [Test]
    public void TestContainsAirline_With100000Results_ShouldPassQuickly()
    {
        this.PerformCorrectnessTesting(new List<Action>(new Action[]{
                this.TestContains_WithExistentAirline_ShouldReturnTrue,
                this.TestContains_WithNonExistentAirline_ShouldReturnFalse
        }));

        int count = 100000;

        Airline airline = null;

        for (int i = 0; i < count; i++)
        {
            Airline airlineToAdd = GetRandomAirline();

            this.airlinesManager.AddAirline(airlineToAdd);

            if (i == count / 2)
            {
                airline = airlineToAdd;
            }
        }

        Stopwatch stopwatch = new Stopwatch(); stopwatch.Start();

        this.airlinesManager.Contains(airline);

        stopwatch.Stop();

        long elapsedTime = stopwatch.ElapsedMilliseconds;

        Assert.IsTrue(elapsedTime <= 5);
    }

    [Test]
    public void TestContainsFlight_With100000Results_ShouldPassQuickly()
    {
        this.PerformCorrectnessTesting(new List<Action>(new Action[]{
                this.TestContains_WithExistentFlight_ShouldReturnTrue,
                this.TestContains_WithNonExistentFlight_ShouldReturnFalse
        }));

        int count = 100000;


        Airline airline = GetRandomAirline();
        Airline airline2 = GetRandomAirline();
        Airline airline3 = GetRandomAirline();
        this.airlinesManager.AddAirline(airline);
        this.airlinesManager.AddAirline(airline2);
        this.airlinesManager.AddAirline(airline3);

        Flight flight = null;

        for (int i = 0; i < count; i++)
        {
            Flight flightToAdd = GetRandomFlight();

            if (i < 10000)
            {
                this.airlinesManager.AddFlight(airline, flightToAdd);
            }
            else if (i < count / 2)
            {
                this.airlinesManager.AddFlight(airline2, flightToAdd);
            }
            else
            {
                this.airlinesManager.AddFlight(airline3, flightToAdd);
            }

            if (i == count / 2)
            {
                flight = flightToAdd;
            }
        }

        Stopwatch stopwatch = new Stopwatch(); stopwatch.Start();

        this.airlinesManager.Contains(flight);

        stopwatch.Stop();

        long elapsedTime = stopwatch.ElapsedMilliseconds;

        Assert.IsTrue(elapsedTime <= 5);
    }
}
