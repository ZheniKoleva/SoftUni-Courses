using NUnit.Framework;
using System.Collections.Generic;
using System;
using Exam.DeliveriesManager;
using System.Diagnostics;
using System.Linq;

public class Tests
{
    private IDeliveriesManager deliveriesManager;

    private Deliverer GetRandomDeliverer()
    {
        return new Deliverer(
                Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString());
    }

    private Package GetRandomPackage()
    {
        Random random = new Random();

        return new Package(
                Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString(),
                random.Next(1, 1_000_000_000));
    }

    [SetUp]
    public void Setup()
    {
        this.deliveriesManager = new DeliveriesManager();
    }

    private void PerformCorrectnessTesting(List<Action> correctnessTests)
    {
        correctnessTests.ForEach(Test =>
        {
            this.deliveriesManager = new DeliveriesManager();

            try { Test.Invoke(); } catch (ArgumentException) { }
        });

        this.deliveriesManager = new DeliveriesManager();
    }

    // Correctness Tests

    [Test]
    public void TestContains_WithExistentDeliverer_ShouldReturnTrue()
    {
        Deliverer deliverer = GetRandomDeliverer();
        this.deliveriesManager.AddDeliverer(deliverer);

        Assert.IsTrue(this.deliveriesManager.Contains(deliverer));
    }

    [Test]
    public void TestContains_WithNonExistentDeliverer_ShouldReturnFalse()
    {
        this.deliveriesManager.AddDeliverer(GetRandomDeliverer());

        Assert.IsFalse(this.deliveriesManager.Contains(GetRandomDeliverer()));
    }

    [Test]
    public void TestContains_WithExistentPackage_ShouldReturnTrue()
    {
        Package _package = GetRandomPackage();
        this.deliveriesManager.AddPackage(_package);

        Assert.IsTrue(this.deliveriesManager.Contains(_package));
    }

    [Test]
    public void TestContains_WithNonExistentPackage_ShouldReturnFalse()
    {
        this.deliveriesManager.AddPackage(GetRandomPackage());

        Assert.IsFalse(this.deliveriesManager.Contains(GetRandomPackage()));
    }

    [Test]
    public void TestGetDeliverers_WithSeveralDeliverers_ShouldReturnCorrectResults()
    {
        Deliverer deliverer1 = GetRandomDeliverer();
        Deliverer deliverer2 = GetRandomDeliverer();
        Deliverer deliverer3 = GetRandomDeliverer();

        this.deliveriesManager.AddDeliverer(deliverer1);
        this.deliveriesManager.AddDeliverer(deliverer2);
        this.deliveriesManager.AddDeliverer(deliverer3);

        HashSet<Deliverer> set = this.deliveriesManager.GetDeliverers().ToHashSet();

        Assert.AreEqual(set.Count, 3);
        Assert.IsTrue(set.Contains(deliverer1));
        Assert.IsTrue(set.Contains(deliverer2));
        Assert.IsTrue(set.Contains(deliverer3));
    }

    // Performance Tests

    [Test]
    public void TestContainsDeliverer_With100000Results_ShouldPassQuickly()
    {
        this.PerformCorrectnessTesting(new List<Action>(new Action[]{
                this.TestContains_WithExistentDeliverer_ShouldReturnTrue,
                this.TestContains_WithNonExistentDeliverer_ShouldReturnFalse
        }));

        int count = 100000;

        Deliverer deliverer = null;

        for (int i = 0; i < count; i++)
        {
            if (i == count / 2)
            {
                deliverer = GetRandomDeliverer();
                this.deliveriesManager.AddDeliverer(deliverer);
            }
            else
            {
                this.deliveriesManager.AddDeliverer(GetRandomDeliverer());
            }

        }

        Stopwatch stopwatch = new Stopwatch(); stopwatch.Start();

        bool _Contains = this.deliveriesManager.Contains(deliverer);

         stopwatch.Stop();

        long elapsedTime = stopwatch.ElapsedMilliseconds;

        Assert.IsTrue(_Contains);
        Assert.IsTrue(elapsedTime <= 5);
    }

    [Test]
    public void TestContainsPackage_With100000Results_ShouldPassQuickly()
    {
        this.PerformCorrectnessTesting(new List<Action>(new Action[]{
                this.TestContains_WithExistentPackage_ShouldReturnTrue,
                this.TestContains_WithNonExistentPackage_ShouldReturnFalse
        }));

        int count = 100000;

        Package _package = null;

        for (int i = 0; i < count; i++)
        {
            if (i == count / 2)
            {
                _package = GetRandomPackage();
                this.deliveriesManager.AddPackage(_package);
            }
            else
            {
                this.deliveriesManager.AddPackage(GetRandomPackage());
            }

        }

        Stopwatch stopwatch = new Stopwatch(); stopwatch.Start();

        bool _Contains = this.deliveriesManager.Contains(_package);

         stopwatch.Stop();

        long elapsedTime = stopwatch.ElapsedMilliseconds;

        Assert.IsTrue(_Contains);
        Assert.IsTrue(elapsedTime <= 5);
    }
}
