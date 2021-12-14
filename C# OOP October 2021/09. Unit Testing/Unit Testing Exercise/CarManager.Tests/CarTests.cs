using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("Toyota", "Avensis", 5.6, 54.5)]
        [TestCase("Opel", "Corsa", 6.8, 30)]
        public void ConstructorShouldWorksCorrectly(
            string make, 
            string model, 
            double fuelConsumption, 
            double fuelCapacity)
        {
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.AreEqual(make, car.Make);
            Assert.AreEqual(model, car.Model);
            Assert.AreEqual(fuelConsumption, car.FuelConsumption);
            Assert.AreEqual(fuelCapacity, car.FuelCapacity);
            Assert.AreEqual(0, car.FuelAmount);
        }

        [Test]
        [TestCase("", "Avensis", 5.6, 54.5)]
        [TestCase(null, "Corsa", 6.8, 30)]
        public void MakeShouldThrowsExceptionForNullOrEmpty(
           string make,
           string model,
           double fuelConsumption,
           double fuelCapacity)
        {

            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity),
                "Make cannot be null or empty!");
        }

        [Test]
        [TestCase("Toyota", "", 5.6, 54.5)]
        [TestCase("Opel", null, 6.8, 30)]
        public void ModelShouldThrowsExceptionForNullOrEmpty(
           string make,
           string model,
           double fuelConsumption,
           double fuelCapacity)
        {

            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity),
                "Model cannot be null or empty!");
        }

        [Test]
        [TestCase("Toyota", "Avensis", 0, 54.5)]
        [TestCase("Opel", "Corsa", double.MinValue, 30)]
        public void FuelConsumptionShouldThrowsExceptionForNullOrEmpty(
           string make,
           string model,
           double fuelConsumption,
           double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity),
                "Fuel consumption cannot be zero or negative!");
        }

        [Test]
        [TestCase("Toyota", "Avensis", 5.6, 0)]
        [TestCase("Opel", "Corsa", 6.8, double.MinValue)]
        public void FuelCapacityShouldThrowsExceptionForNullOrEmpty(
          string make,
          string model,
          double fuelConsumption,
          double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity),
                "Fuel capacity cannot be zero or negative!");
        }


        [Test]
        [TestCase("Toyota", "Avensis", 5.6, 54.5, 50)]
        [TestCase("Opel", "Corsa", 6.8, 30, 19)]
        public void RefuelMethodShouldWorksCorrectlyIfAddFuelWithInCapacity(
            string make,
            string model,
            double fuelConsumption,
            double fuelCapacity,
            double fuelToRefuel)
        {
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            car.Refuel(fuelToRefuel);

            Assert.AreEqual(fuelToRefuel, car.FuelAmount);            
        }

        [Test]
        [TestCase("Toyota", "Avensis", 5.6, 54.5, 100)]
        [TestCase("Opel", "Corsa", 6.8, 30, 67)]
        public void RefuelMethodShouldWorksCorrectlyIfAddFuelAboveCapacity(
            string make,
            string model,
            double fuelConsumption,
            double fuelCapacity,
            double fuelToRefuel)
        {
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            car.Refuel(fuelToRefuel);

            Assert.AreEqual(fuelCapacity, car.FuelAmount);
        }

        [Test]
        [TestCase("Toyota", "Avensis", 5.6, 54.5, double.MinValue)]
        [TestCase("Opel", "Corsa", 6.8, 30, 0)]
        public void RefuelMethodShouldThrowsExceptionIfAddNegativeFuelAmount(
           string make,
           string model,
           double fuelConsumption,
           double fuelCapacity,
           double fuelToRefuel)
        {
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.Throws<ArgumentException>(() => car.Refuel(fuelToRefuel),
                "Fuel amount cannot be zero or negative!");
        }

        [Test]
        [TestCase("Toyota", "Avensis", 5.6, 54.5, 50, 100)]
        [TestCase("Opel", "Corsa", 6.8, 30, 19, 5)]
        public void DriveMethodShouldWorksCorrectlyIfAddFuelWithInCapacity(
           string make,
           string model,
           double fuelConsumption,
           double fuelCapacity,
           double fuelToRefuel,
           double distance)
        {
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            car.Refuel(fuelToRefuel);

            double fuelLeft = car.FuelAmount - (distance / 100) * fuelConsumption;

            car.Drive(distance);

            Assert.AreEqual(fuelLeft, car.FuelAmount);
        }

        [Test]
        [TestCase("Toyota", "Avensis", 5.6, 54.5, 50, double.MaxValue)]
        [TestCase("Opel", "Corsa", 6.8, 30, 50, 5000)]
        public void DriveMethodShouldThrowsExceptionIfFuelUnsificientForDistance(
           string make,
           string model,
           double fuelConsumption,
           double fuelCapacity,
           double fuelToRefuel,
           double distance)
        {
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            car.Refuel(fuelToRefuel);            

            Assert.Throws<InvalidOperationException>(() => car.Drive(distance),
                "You don't have enough fuel to drive!");
        }
    }
}