namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class AquariumsTests
    {
        [Test]
        public void ConstructorShouldThrowExceptionForInvalidAquariumName()
        {
            Assert.Throws<ArgumentNullException>(() => new Aquarium(null, 15),
                "Invalid aquarium name!");        
        }

        [Test]
        public void ConstructorShouldThrowExceptionForInvalidAquariumCapacity()
        {
            Assert.Throws<ArgumentException>(() => new Aquarium("Pesho", -15),
                "Invalid aquarium capacity!");
        }

        [Test]
        public void ConstructorShouldSetAquariumName()
        {
            Aquarium aquarium = new Aquarium("Pesho", 15);

            Assert.AreEqual("Pesho", aquarium.Name);
        }

        [Test]
        public void ConstructorShouldSetAquariumCapacity()
        {
            Aquarium aquarium = new Aquarium("Pesho", 15);

            Assert.AreEqual(15, aquarium.Capacity);
        }

        [Test]
        public void AddFishShouldThrowExceptionForFullAquarium()
        {
            Aquarium aquarium = new Aquarium("Pesho", 2);

            Fish fish = new Fish("Gosho");
            Fish fish2 = new Fish("Misho");

            aquarium.Add(fish);
            aquarium.Add(fish2);

            Assert.Throws<InvalidOperationException>(() => aquarium.Add(new Fish("Tosho")),
                "Aquarium is full!");
        }

        [Test]
        public void AddFishShouldWorksCorrectly()
        {
            Aquarium aquarium = new Aquarium("Pesho", 3);

            Fish fish = new Fish("Gosho");
            Fish fish2 = new Fish("Misho");

            aquarium.Add(fish);
            aquarium.Add(fish2);

            Assert.AreEqual(2, aquarium.Count);
        }

        [Test]
        public void RemoveFishShouldThrowExceptionForUnexistingFish()
        {
            Aquarium aquarium = new Aquarium("Pesho", 2);          

            string fishToRemove = "Gosho";

            Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish(fishToRemove),
                $"Fish with the name {fishToRemove} doesn't exist!");
        }

        [Test]
        public void RemoveFishShouldWorksCorrectly()
        {
            Aquarium aquarium = new Aquarium("Pesho", 2);

            Fish fish = new Fish("Gosho");
            Fish fish2 = new Fish("Misho");

            aquarium.Add(fish);
            aquarium.Add(fish2);
            aquarium.RemoveFish(fish.Name);

            Assert.AreEqual(1, aquarium.Count);
        }

        [Test]
        public void SellFishShouldThrowExceptionForUnexistingFish()
        {
            Aquarium aquarium = new Aquarium("Pesho", 2);

            string fishToRemove = "Gosho";

            Assert.Throws<InvalidOperationException>(() => aquarium.SellFish(fishToRemove),
                $"Fish with the name {fishToRemove} doesn't exist!");
        }

        [Test]
        public void SellFishShouldChangeFishAvailability()
        {
            Aquarium aquarium = new Aquarium("Pesho", 3);

            Fish fish = new Fish("Gosho");
            Fish fish2 = new Fish("Misho");

            aquarium.Add(fish);
            aquarium.Add(fish2);

            Fish toSell = aquarium.SellFish(fish.Name);

            Assert.AreEqual(fish, toSell);
            Assert.IsFalse(toSell.Available);
        }

        [Test]
        public void ReportShouldWorksCorrectly()
        {
            Aquarium aquarium = new Aquarium("Pesho", 3);

            Fish fish = new Fish("Gosho");
            Fish fish2 = new Fish("Misho");

            aquarium.Add(fish);
            aquarium.Add(fish2);

            string expected = $"Fish available at {aquarium.Name}: {fish.Name}, {fish2.Name}";

            string actual = aquarium.Report();

            Assert.AreEqual(expected, actual);            
        }

    }
}
