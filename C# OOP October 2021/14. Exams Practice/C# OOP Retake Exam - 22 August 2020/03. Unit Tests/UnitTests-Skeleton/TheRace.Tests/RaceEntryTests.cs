using NUnit.Framework;
using System;


namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private RaceEntry raceEntry;       

        [SetUp]
        public void Setup()
        {
            raceEntry = new RaceEntry();
        }

        [Test]
        public void ConstructorShouldInitializeCollection()
        {
            Assert.IsNotNull(raceEntry);
        }

        [Test]
        public void AddMethodShouldThrowsExceptionForInvalidDriver()
        {
            Assert.Throws<InvalidOperationException>(() => raceEntry.AddDriver(null),
                "Driver cannot be null.");
        }

        [Test]
        public void AddMethodShouldThrowsExceptionForExistingDriver()
        {
            UnitCar car = new UnitCar("Toyota Avensis", 150, 2000);
            UnitDriver driver = new UnitDriver("Pesho", car);

            raceEntry.AddDriver(driver);

            Assert.Throws<InvalidOperationException>(() => raceEntry.AddDriver(driver),
                "Driver Pesho is already added.");
        }

        [Test]
        public void AddMethodShouldWorksCorrectly()
        {
            UnitCar car = new UnitCar("Toyota Avensis", 150, 2000);
            UnitDriver driver = new UnitDriver("Pesho", car);

            string expected = "Driver Pesho added in race.";

            Assert.AreEqual(expected, raceEntry.AddDriver(driver));
        }

        [Test]
        public void AddMethodShouldIncreaseCount()
        {
            UnitCar car1 = new UnitCar("Toyota Avensis", 150, 2000);
            UnitDriver driver1 = new UnitDriver("Pesho", car1);

            UnitCar car2 = new UnitCar("Toyota Corolla", 120, 1800);
            UnitDriver driver2 = new UnitDriver("Gosho", car2);

            raceEntry.AddDriver(driver1);
            raceEntry.AddDriver(driver2);

            Assert.AreEqual(2, raceEntry.Counter);
        }

        [Test]
        public void CalculateAverageHorsePowerMethodShouldThrowsException()
        {
            UnitCar car = new UnitCar("Toyota Avensis", 150, 2000);
            UnitDriver driver = new UnitDriver("Pesho", car);           

            raceEntry.AddDriver(driver);

            Assert.Throws<InvalidOperationException>(() => raceEntry.CalculateAverageHorsePower(),
                 "The race cannot start with less than 2 participants.");
        }

        [Test]
        public void CalculateAverageHorsePowerMethodShouldWorksCorrectly()
        {
            UnitCar car = new UnitCar("Toyota Avensis", 150, 2000);
            UnitDriver driver = new UnitDriver("Pesho", car);

            UnitCar car2 = new UnitCar("Toyota Corolla", 120, 1800);
            UnitDriver driver2 = new UnitDriver("Gosho", car2);

            raceEntry.AddDriver(driver);
            raceEntry.AddDriver(driver2);

            double expectedResult = (car.HorsePower + car2.HorsePower) / 2;

            Assert.AreEqual(expectedResult, raceEntry.CalculateAverageHorsePower());
        }

    }
}