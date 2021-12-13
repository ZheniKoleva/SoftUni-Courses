using NUnit.Framework;
using System;
using System.Linq;

namespace Computers.Tests
{
    [TestFixture]
    public class Tests
    {
        private ComputerManager computerManager;

        [SetUp]
        public void Setup()
        {
            computerManager = new ComputerManager();
        }

        [Test]
        public void ConstructorShouldInitialiseListOfComputers()
        {
            Assert.IsNotNull(computerManager.Computers);           
        }


        [Test]
        public void AddMethodShouldThrowExceptionForNullComputer()
        {
            Assert.Throws<ArgumentNullException>(() => computerManager.AddComputer(null),
                "Can not be null!");
        }

        [Test]
        public void AddMethodShouldThrowExceptionForExistingComputer()
        {
            Computer computer = new Computer("Lenovo", "Yoga", 1899.99m);

            computerManager.AddComputer(computer);

            Assert.Throws<ArgumentException>(() => computerManager.AddComputer(computer),
                "This computer already exists.");
        }

        [Test]
        public void AddMethodShouldWorksCorrectly()
        {
            Computer computer = new Computer("Lenovo", "Yoga", 1899.99m);
            Computer computer2 = new Computer("Lenovo", "Yoga1", 2000.00m);
            Computer computer3 = new Computer("Lenovo", "Yoga2", 2100.99m);          

            computerManager.AddComputer(computer);
            computerManager.AddComputer(computer2);
            computerManager.AddComputer(computer3);

            Assert.AreEqual(3, computerManager.Count);
        }


        [Test]
        public void ComputersPropertyShouldReturnCorrectCollection()
        {
            Computer computer = new Computer("Lenovo", "Yoga", 1899.99m);
            Computer computer2 = new Computer("Lenovo", "Yoga1", 2000.00m);
            Computer computer3 = new Computer("Lenovo", "Yoga2", 2100.99m);

            Computer[] expected = new Computer[] { computer, computer2, computer3 };

            computerManager.AddComputer(computer);
            computerManager.AddComputer(computer2);
            computerManager.AddComputer(computer3);

            Computer[] actual = computerManager.Computers.ToArray();

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void GetComputerShouldThrowExceptionForInvalidManufacturer()
        {
            Computer computer = new Computer("Lenovo", "Yoga", 1899.99m);            

            computerManager.AddComputer(computer);
            
            Assert.Throws<ArgumentNullException>(() => computerManager.GetComputer(null, "Yoga"),
                "Can not be null!");
        }

        [Test]
        public void GetComputerShouldThrowExceptionForInvalidModel()
        {
            Computer computer = new Computer("Lenovo", "Yoga", 1899.99m);           

            computerManager.AddComputer(computer);           

            Assert.Throws<ArgumentNullException>(() => computerManager.GetComputer("Lenovo", null),
                "Can not be null!");
        }

        [Test]
        public void GetComputerShouldThrowExceptionForUnexistingComputer()
        {
            Computer computer = new Computer("Lenovo", "Yoga", 1899.99m);
            Computer computer2 = new Computer("Asus", "ROG", 2000.00m);           

            computerManager.AddComputer(computer);
            computerManager.AddComputer(computer2);

            Assert.Throws<ArgumentException>(() => computerManager.GetComputer("Acer", "Aspire 3"),
                "There is no computer with this manufacturer and model.");
        }

        [Test]
        public void GetComputerShouldWorksCorrectly()
        {
            Computer computer = new Computer("Lenovo", "Yoga", 1899.99m);
            Computer computer2 = new Computer("Asus", "ROG", 2000.00m);

            computerManager.AddComputer(computer);
            computerManager.AddComputer(computer2);

            Computer expected = computer;

            Assert.AreEqual(expected, computerManager.GetComputer("Lenovo", "Yoga"));
        }

        [Test]
        public void RemoveComputerShouldThrowEcxeptionForInvalidManufacturer()
        {
            Computer computer = new Computer("Lenovo", "Yoga", 1899.99m);
            Computer computer2 = new Computer("Asus", "ROG", 2000.00m);

            computerManager.AddComputer(computer);
            computerManager.AddComputer(computer2);            

            Assert.Throws<ArgumentNullException>(() => computerManager.RemoveComputer(null, "Yoga"),
                "Can not be null!");
        }

        [Test]
        public void RemoveComputerShouldThrowEcxeptionForInvalidModel()
        {
            Computer computer = new Computer("Lenovo", "Yoga", 1899.99m);
            Computer computer2 = new Computer("Asus", "ROG", 2000.00m);

            computerManager.AddComputer(computer);
            computerManager.AddComputer(computer2);

            Assert.Throws<ArgumentNullException>(() => computerManager.RemoveComputer("Lenovo", null),
                "Can not be null!");
        }

        [Test]
        public void RemoveComputerShouldWorksCorrectly()
        {
            Computer computer = new Computer("Lenovo", "Yoga", 1899.99m);
            Computer computer2 = new Computer("Asus", "ROG", 2000.00m);

            computerManager.AddComputer(computer);
            computerManager.AddComputer(computer2);

            Computer toRemove = computerManager.RemoveComputer("Lenovo", "Yoga");

            Assert.AreEqual(computer, toRemove);            
        }

        [Test]
        public void RemoveComputerShouldReturnCorrectCountAfterRemove()
        {
            Computer computer = new Computer("Lenovo", "Yoga", 1899.99m);
            Computer computer2 = new Computer("Asus", "ROG", 2000.00m);

            computerManager.AddComputer(computer);
            computerManager.AddComputer(computer2);

            computerManager.RemoveComputer("Lenovo", "Yoga");
            
            Assert.AreEqual(1, computerManager.Count);
        }

        [Test]
        public void GetComputersByManufacturerWorksCorrectly()
        {
            Computer computer = new Computer("Lenovo", "Yoga", 1899.99m);
            Computer computer2 = new Computer("Asus", "ROG", 2000.00m);
            Computer computer3 = new Computer("Lenovo", "Yoga1", 2000.00m);

            computerManager.AddComputer(computer);
            computerManager.AddComputer(computer2);
            computerManager.AddComputer(computer3);

            Computer[] expectedLenovo = new Computer[] { computer, computer3 };
            Computer[] actual = computerManager.GetComputersByManufacturer("Lenovo").ToArray();

            CollectionAssert.AreEquivalent(expectedLenovo, actual);
        }

        [Test]
        public void GetComputersByManufacturerShoulThrowExceptionForInvalidManufacturer()
        {
            Computer computer = new Computer("Lenovo", "Yoga", 1899.99m);
            Computer computer2 = new Computer("Asus", "ROG", 2000.00m);
            Computer computer3 = new Computer("Lenovo", "Yoga1", 2000.00m);

            computerManager.AddComputer(computer);
            computerManager.AddComputer(computer2);
            computerManager.AddComputer(computer3);

            Assert.Throws<ArgumentNullException>(() => computerManager.GetComputersByManufacturer(null),
                "Can not be null!");
        }

        [Test]
        public void GetComputersByManufacturerShoulReturnEmptyCollection()
        {
            Computer computer = new Computer("Lenovo", "Yoga", 1899.99m);
            Computer computer2 = new Computer("Asus", "ROG", 2000.00m);
            Computer computer3 = new Computer("Lenovo", "Yoga1", 2000.00m);

            computerManager.AddComputer(computer);
            computerManager.AddComputer(computer2);
            computerManager.AddComputer(computer3);

            Computer[] actual = computerManager.GetComputersByManufacturer("Acer").ToArray();

            CollectionAssert.IsEmpty(actual);
        }


    }
}