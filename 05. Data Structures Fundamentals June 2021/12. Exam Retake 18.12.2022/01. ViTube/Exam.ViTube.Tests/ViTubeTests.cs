using NUnit.Framework;
using System.Collections.Generic;
using System;
using Exam.ViTube;
using System.Linq;
using System.Diagnostics;

public class ViTubeTests
{
    private IViTubeRepository viTubeRepository;

    private User GetRandomUser()
    {
        return new User(
                Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString());
    }

    private Video GetRandomVideo()
    {
        Random random = new Random();

        return new Video(
                Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString(),
                random.Next(1, 1_000_000_000),
                random.Next(1, 1_000_000_000),
                random.Next(1, 1_000_000_000),
                random.Next(1, 1_000_000_000));
    }

    [SetUp]
    public void Setup()
    {
        this.viTubeRepository = new ViTubeRepository();
    }

    private void PerformCorrectnessTesting(List<Action> correctnessTests)
    {
        correctnessTests.ForEach(Test =>
        {
            this.viTubeRepository = new ViTubeRepository();

            try { Test.Invoke(); } catch (ArgumentException) { }
        });

        this.viTubeRepository = new ViTubeRepository();
    }

    // Correctness Tests

    [Test]
    public void TestContains_WithExistentUser_ShouldReturnTrue()
    {
        User user = GetRandomUser();
        this.viTubeRepository.RegisterUser(user);

        Assert.IsTrue(this.viTubeRepository.Contains(user));
    }

    [Test]
    public void TestContains_WithNonExistentUser_ShouldReturnFalse()
    {
        User user = GetRandomUser();
        this.viTubeRepository.RegisterUser(user);

        Assert.IsFalse(this.viTubeRepository.Contains(GetRandomUser()));
    }

    [Test]
    public void TestPassiveUsers_WithData_ShouldReturnCorrectResults()
    {
        Video video1 = GetRandomVideo();
        Video video2 = GetRandomVideo();
        Video video3 = GetRandomVideo();

        User user1 = GetRandomUser();
        User user2 = GetRandomUser();
        User user3 = GetRandomUser();

        this.viTubeRepository.RegisterUser(user1);
        this.viTubeRepository.RegisterUser(user2);
        this.viTubeRepository.RegisterUser(user3);
        this.viTubeRepository.PostVideo(video1);
        this.viTubeRepository.PostVideo(video2);
        this.viTubeRepository.PostVideo(video3);

        this.viTubeRepository.WatchVideo(user3, video1);

        HashSet<User> set = this.viTubeRepository.GetPassiveUsers().ToHashSet();

        Assert.AreEqual(set.Count, 2);
        Assert.IsTrue(set.Contains(user1));
        Assert.IsTrue(set.Contains(user2));
    }

    [Test]
    public void TestPassiveUsers_WithNoMatchingData_ShouldReturnCorrectResults()
    {
        Video video1 = GetRandomVideo();
        Video video2 = GetRandomVideo();
        Video video3 = GetRandomVideo();

        User user1 = GetRandomUser();
        User user2 = GetRandomUser();
        User user3 = GetRandomUser();

        this.viTubeRepository.RegisterUser(user1);
        this.viTubeRepository.RegisterUser(user2);
        this.viTubeRepository.RegisterUser(user3);
        this.viTubeRepository.PostVideo(video1);
        this.viTubeRepository.PostVideo(video2);
        this.viTubeRepository.PostVideo(video3);

        this.viTubeRepository.LikeVideo(user1, video1);
        this.viTubeRepository.DislikeVideo(user2, video1);
        this.viTubeRepository.WatchVideo(user3, video1);

        HashSet<User> set = this.viTubeRepository.GetPassiveUsers().ToHashSet();

        Assert.AreEqual(set.Count, 0);
    }

    // Performance Tests

    [Test]
    public void TestContainsUser_With100000Results_ShouldPassQuickly()
    {
        this.PerformCorrectnessTesting(new List<Action>(new Action[]{
                this.TestContains_WithExistentUser_ShouldReturnTrue,
                this.TestContains_WithNonExistentUser_ShouldReturnFalse
        }));

        int count = 100000;

        User userToContain = null;

        for (int i = 0; i < count; i++)
        {
            if (i == count / 2)
            {
                userToContain = GetRandomUser();
                this.viTubeRepository.RegisterUser(userToContain);
            }
            else
            {
                this.viTubeRepository.RegisterUser(GetRandomUser());
            }

        }

        Stopwatch stopwatch = new Stopwatch(); stopwatch.Start();

        this.viTubeRepository.Contains(userToContain);

        stopwatch.Stop();

        long elapsedTime = stopwatch.ElapsedMilliseconds;

        Assert.IsTrue(elapsedTime <= 5);
    }

    [Test]
    public void TestPassiveUsers_With100000Results_ShouldPassQuickly()
    {
        this.PerformCorrectnessTesting(new List<Action>(new Action[]{
            this.TestPassiveUsers_WithData_ShouldReturnCorrectResults,
            this.TestPassiveUsers_WithNoMatchingData_ShouldReturnCorrectResults
        }));

        int count = 100000;

        for (int i = 0; i < count / 2; i++)
        {
            User userToDo = GetRandomUser();
            Video videoToDo = GetRandomVideo();
            this.viTubeRepository.RegisterUser(userToDo);
            this.viTubeRepository.PostVideo(videoToDo);

            if (i < count / 7) this.viTubeRepository.DislikeVideo(userToDo, videoToDo);
            if (i > count / 7 && i < count / 5) this.viTubeRepository.LikeVideo(userToDo, videoToDo);
            if (i > count / 5 && i < count / 3) this.viTubeRepository.WatchVideo(userToDo, videoToDo);
        }

        Stopwatch stopwatch = new Stopwatch(); stopwatch.Start();

        this.viTubeRepository.GetPassiveUsers();

        stopwatch.Stop();

        long elapsedTime = stopwatch.ElapsedMilliseconds;

        Assert.IsTrue(elapsedTime <= 10);
    }
}
