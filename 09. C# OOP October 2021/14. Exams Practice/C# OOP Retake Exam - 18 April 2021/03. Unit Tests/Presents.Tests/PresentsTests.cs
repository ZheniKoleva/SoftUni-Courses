namespace Presents.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class PresentsTests
    {
        private Bag bag;

        private Present fisrtPresent;

        private Present secondPresent;

        [SetUp]
        public void SetUp()
        { 
            bag = new Bag();
            fisrtPresent = new Present("Santa", 15.5);
            secondPresent = new Present("Santa Claus", 20.00);
        }

        [Test]
        public void ConstructirShoulInitialiseBag()
        {
            Assert.IsNotNull(bag);
            Assert.AreEqual(0, bag.GetPresents().Count);
        }

        [Test]
        public void CreateShouldThrowsExceptionIfPresentIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => bag.Create(null),
                "Present is null");
        }

        [Test]
        public void CreateShouldThrowsExceptionIfPresentExists()
        {            
            bag.Create(fisrtPresent);

            Assert.Throws<InvalidOperationException>(() => bag.Create(fisrtPresent),
                "This present already exists!");
        }

        [Test]
        public void CreateShouldWorksCorrectly()
        {           
            bag.Create(fisrtPresent);

            int presentsInBag = bag.GetPresents().Count;

            Assert.AreEqual(1, presentsInBag);
        }

        [Test]
        public void CreateShouldReturnCorrectString()
        {
            string expected = $"Successfully added present {fisrtPresent.Name}.";
            string actual = bag.Create(fisrtPresent);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void RemoveShouldReturnTrue()
        {
            bag.Create(fisrtPresent);     
            
            bool isRemoved = bag.Remove(fisrtPresent);

            Assert.IsTrue(isRemoved);
        }

        [Test]
        public void RemoveShouldReturnTrueAndShouldRedusePresentsCount()
        {
            bag.Create(fisrtPresent);

            bag.Remove(fisrtPresent);

            Assert.AreEqual(0, bag.GetPresents().Count);
        }

        [Test]
        public void RemoveShouldReturnFalseForUnexistingPresent()
        {
            bag.Create(fisrtPresent);            

            bool isRemoved = bag.Remove(secondPresent);

            Assert.IsFalse(isRemoved);
        }


        [Test]
        public void GetPresentWithLeastMagic()
        {
            bag.Create(secondPresent);
            bag.Create(fisrtPresent);

            Present expected = fisrtPresent;

            Present actual = bag.GetPresentWithLeastMagic();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetPresentWithLeastMagicShoulThrowExceptionForEmptyCollection()
        {
            Assert.Throws<InvalidOperationException>(() => bag.GetPresentWithLeastMagic());
        }

        [Test]
        public void GetPresentShouldWorksCorrectly()
        {
            bag.Create(fisrtPresent);
            bag.Create(secondPresent);

            Present expected = secondPresent;
            Present actual = bag.GetPresent(secondPresent.Name);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetPresentShouldReturnNullForUnexistingPresent()
        {
            bag.Create(fisrtPresent);            

            Present expected = null;
            Present actual = bag.GetPresent(secondPresent.Name);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetPresentsShouldWorksCorrectly()
        {
            bag.Create(fisrtPresent);
            bag.Create(secondPresent);

            IEnumerable<Present> expected = new List<Present> { fisrtPresent, secondPresent };
            IEnumerable<Present> actual = bag.GetPresents();

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void GetPresentsShouldReturnEmptyCollection()
        {
            CollectionAssert.IsEmpty(bag.GetPresents());
        }


    }
}
