using System;

using NUnit.Framework;

namespace Gyms.Tests
{
    [TestFixture]
    public class GymsTests
    {
        private Gym gym;

        private Athlete firstAthlete;

        private Athlete secondAthlete;

        [SetUp]
        public void SetUp()
        {
            gym = new Gym("My gym", 2);
            firstAthlete = new Athlete("Pesho");
            secondAthlete = new Athlete("Gosho");        
        }

        [Test]
        public void ConstructorShouldInitialiseGym()
        { 
            Assert.IsNotNull(gym);
            Assert.AreEqual(2, gym.Capacity);
            Assert.AreEqual(0, gym.Count);
        }

        [TestCase(null)]
        [TestCase("")]        
        public void ConstructorShouldThrowExceptionForInvalidGymName(string name)
        {
            Assert.Throws<ArgumentNullException>(() => new Gym(name, 2),
                "Invalid gym name.");
        }

        [Test]
        public void ConstructorShouldSetCorrectGymName()
        {
            Assert.AreEqual("My gym", gym.Name);
        }

        
        [Test]
        public void ConstructorShouldThrowExceptionForInvalidCapacity()
        {
            Assert.Throws<ArgumentException>(() => new Gym("My gym", -50),
                "Invalid gym capacity.");
        }

        [Test]
        public void ConstructorShouldSetCorrectGymCapacity()
        {
            Assert.AreEqual(2, gym.Capacity);
        }

        [Test]
        public void AddShouldThrowExceptionForInvalidAthlete()
        {
            gym.AddAthlete(firstAthlete);
            gym.AddAthlete(secondAthlete);

            Assert.Throws<InvalidOperationException>(() => gym.AddAthlete(new Athlete("Ivan")),
                "The gym is full.");
        }

        [Test]
        public void AddShouldAddAthleteSuccessfully()
        {
            gym.AddAthlete(firstAthlete);

            Assert.AreEqual(1, gym.Count);
        }

        [Test]
        public void RemoveAthleteShouldThrowExceptionForInvalidAthlete()
        {
            gym.AddAthlete(firstAthlete);
            gym.AddAthlete(secondAthlete);

            Assert.Throws<InvalidOperationException>(() => gym.RemoveAthlete("Ivan"),
                $"The athlete Ivan doesn't exist.");
        }

        [Test]
        public void RemoveAthleteShouldRemoveAthleteSuccessfully()
        {
            gym.AddAthlete(firstAthlete);
            gym.AddAthlete(secondAthlete);
                        
            int athletesCount = gym.Count;

            gym.RemoveAthlete(secondAthlete.FullName);

            int athletesCountAfterRemove = gym.Count;
            int expectedCountAfterRemove = 1;

            Assert.AreNotEqual(athletesCount, athletesCountAfterRemove);
            Assert.AreEqual(expectedCountAfterRemove, athletesCountAfterRemove);
        }

        [Test]
        public void InjureAthleteShouldThrowExceptionForInvalidAthlete()
        {
            gym.AddAthlete(firstAthlete);
            gym.AddAthlete(secondAthlete);

            Assert.Throws<InvalidOperationException>(() => gym.RemoveAthlete("Ivan"),
                $"The athlete Ivan doesn't exist.");
        }

        [Test]
        public void InjureAthleteShouldSetIsInjuredToTrue()
        {
            gym.AddAthlete(firstAthlete);
            gym.AddAthlete(secondAthlete);

            gym.InjureAthlete(secondAthlete.FullName);

            Assert.IsTrue(secondAthlete.IsInjured);
        }

        [Test]
        public void InjureAthleteShouldReturnCorrectAthlete()
        {
            gym.AddAthlete(firstAthlete);
            gym.AddAthlete(secondAthlete);

            Athlete actual = gym.InjureAthlete(secondAthlete.FullName);

            Assert.AreSame(secondAthlete, actual);
        }

        [Test]
        public void ReportShouldReturnCorectAthletes()
        {
            gym.AddAthlete(firstAthlete);
            gym.AddAthlete(secondAthlete);

            string expected = "Active athletes at My gym: Pesho, Gosho";

            string actual = gym.Report();

            Assert.AreEqual(expected, actual);
        }

    }

}
