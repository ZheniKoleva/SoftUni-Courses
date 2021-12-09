namespace Robots.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class RobotsTests
    {
        private RobotManager manager;

        private Robot firstRobot;

        private Robot secondRobot;

        [SetUp]
        public void SetUp()
        {
            manager = new RobotManager(2);
            firstRobot = new Robot("Pesho", 5000);
            secondRobot = new Robot("Gosho", 10000);
        }

        [Test]
        public void ConstructorShouldInitialiseRobotManager()
        {
            Assert.IsNotNull(manager);
        }

        [Test]
        public void ConstructorShouldThrowsExceptionForIncorrectCapacity()
        {
            Assert.Throws<ArgumentException>(() => manager = new RobotManager(-15),
                "Invalid capacity!");
        }

        [Test]
        public void ConstructorShouldReturnCorrectCapacity()
        {
            Assert.AreEqual(2, manager.Capacity);
        }

        [Test]
        public void ConstructorShouldReturnZeroForRobotsCountUponInitializacion()
        {
            Assert.AreEqual(0, manager.Count);
        }

        [Test]
        public void AddMethodShouldThrowsExceptionForExcistingRobot()
        {
            manager.Add(firstRobot);            

            Assert.Throws<InvalidOperationException>(() => manager.Add(firstRobot),
                $"There is already a robot with name {firstRobot.Name}!");
        }


        [Test]
        public void AddMethodShouldThrowsExceptionForReachingCapacity()
        {
            manager.Add(firstRobot);
            manager.Add(secondRobot);

            Robot thirdRobot = new Robot("Milcho", 6500);

            Assert.Throws<InvalidOperationException>(() => manager.Add(thirdRobot),
                "Not enough capacity!");
        }

        [Test]
        public void AddMethodShouldIncreaseRobotsCount()
        {
            manager.Add(firstRobot);
            manager.Add(secondRobot);

            Assert.AreEqual(2, manager.Count);
        }

        [Test]
        public void RemoveMethodShouldThrowsExceptionForUnexistingRobot()
        {
            manager.Add(firstRobot);
            manager.Add(secondRobot);

            string robotToRemove = "Milcho";

            Assert.Throws<InvalidOperationException>(() => manager.Remove(robotToRemove),
                $"Robot with the name {robotToRemove} doesn't exist!");
        }

        [Test]
        public void RemoveMethodShouldWorksCorrectly()
        {
            manager.Add(firstRobot);
            manager.Add(secondRobot); 
            
            manager.Remove(firstRobot.Name);

            Assert.AreEqual(1, manager.Count);
        }

        [Test]
        public void WorkMethodShouldThrowsExceptionForUnexistingRobot()
        {
            manager.Add(firstRobot);
            manager.Add(secondRobot);
            
            Assert.Throws<InvalidOperationException>(() => manager.Work("Milcho", "cleaning", 2000),
                $"Robot with the name Milcho doesn't exist!");
        }

        [Test]
        public void WorkMethodShouldThrowsExceptionForinsufficientBattery()
        {
            manager.Add(firstRobot);
            manager.Add(secondRobot);

            Assert.Throws<InvalidOperationException>(() => manager.Work(firstRobot.Name, "cleaning", 70000),
                $"Pesho doesn't have enough battery!");
        }

        [Test]
        public void WorkMethodShouldDecreaseBattery()
        {
            manager.Add(firstRobot);
            manager.Add(secondRobot);

            manager.Work(secondRobot.Name, "cleaning", 2000);

            Assert.AreEqual(8000, secondRobot.Battery);
        }


        [Test]
        public void ChargeMethodShouldThrowsExceptionForUnexistingRobot()
        {
            manager.Add(firstRobot);
            manager.Add(secondRobot);

            Assert.Throws<InvalidOperationException>(() => manager.Charge("Milcho"),
                $"Robot with the name Milcho doesn't exist!");
        }

        [Test]
        public void ChargeMethodShouldWorksCorrectly()
        {
            manager.Add(firstRobot);

            int initialBattery = firstRobot.Battery;

            manager.Work(firstRobot.Name, "cleaning", 3500);
            int batteryAfterWork = firstRobot.Battery;

            manager.Charge(firstRobot.Name);
            int batteryAfterCharge = firstRobot.Battery;

            Assert.AreNotEqual(initialBattery, batteryAfterWork);
            Assert.AreEqual(initialBattery, batteryAfterCharge);
        }
    }
}
