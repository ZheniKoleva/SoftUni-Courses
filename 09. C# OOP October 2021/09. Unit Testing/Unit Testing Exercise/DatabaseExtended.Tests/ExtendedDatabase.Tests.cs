using NUnit.Framework;
using System;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]        
        [TestCase(1, "Pesho", 9)]
        [TestCase(56, "Gosho", 16)]
        [TestCase(2, "Pesho", 1)]
        public void ConstructorShoulWorksCorrectly(long id, string name, int count)
        {
            Person[] people = new Person[count];

            for (int i = 0; i < count; i++)
            {
                people[i] = new Person(id + i, name + i);
            }           

            ExtendedDatabase db = new ExtendedDatabase(people);
            Assert.AreEqual(count, db.Count);
        }

        [Test]
        [TestCase(1, "Pesho", 24)]
        [TestCase(56, "Gosho", 34)]
        [TestCase(2, "Pesho", 87)]
        public void ConstructorShouldThrowsExceptionIfAddMoreThan16People(long id, string name, int count)
        {
            Person[] people = new Person[count];

            for (int i = 0; i < count; i++)
            {
                people[i] = new Person(id + i, name + i);
            }
           
            Assert.Throws<ArgumentException>(() => new ExtendedDatabase(people),
                "Provided data length should be in range [0..16]!");
        }

        [Test]
        [TestCase(1, "Pesho", 5)]
        [TestCase(56, "Gosho", 7)]
        [TestCase(2, "Pesho", 13)]
        public void AddMethodShouldWorksCorrectly(long id, string name, int count)
        {
            Person[] people = new Person[count];

            for (int i = 0; i < count; i++)
            {
                people[i] = new Person(id + i, name + i);
            }

            ExtendedDatabase db = new ExtendedDatabase(people);
            Person toAdd = new Person(33474743, "Stamat");
            db.Add(toAdd);

            Assert.AreEqual(count + 1, db.Count);           
        }

        [Test]
        [TestCase(1, "Pesho", 16)]        
        public void AddMethodShouldThrowsExceptionIfAddMoreThan16People(long id, string name, int count)
        {
            Person[] people = new Person[count];

            for (int i = 0; i < count; i++)
            {
                people[i] = new Person(id + i, name + i);
            }

           ExtendedDatabase db = new ExtendedDatabase(people);            

            Assert.Throws<InvalidOperationException>(() => db.Add(new Person(33474743, "Stamat")),
               "Array's capacity must be exactly 16 integers!");
        }

        [Test]
        [TestCase(1, "Pesho", 5)]
        [TestCase(56, "Gosho", 7)]
        [TestCase(2, "Pesho", 13)]
        public void AddMethodShouldThrowsExceptionIfAddExistingUserName(long id, string name, int count)
        {
            Person[] people = new Person[count];

            for (int i = 0; i < count; i++)
            {
                people[i] = new Person(id + i, name + i);
            }

            ExtendedDatabase db = new ExtendedDatabase(people);
            Random random = new Random();            
            string existingUserName = people[random.Next(people.Length)].UserName;
            Person toAdd = new Person(4654765, existingUserName);

            Assert.Throws<InvalidOperationException>(() => db.Add(toAdd),
               "There is already user with this username!");
        }

        [Test]
        [TestCase(1, "Pesho", 5)]
        [TestCase(56, "Gosho", 7)]
        [TestCase(2, "Pesho", 13)]
        public void AddMethodShouldThrowsExceptionIfAddExistingId(long id, string name, int count)
        {
            Person[] people = new Person[count];

            for (int i = 0; i < count; i++)
            {
                people[i] = new Person(id + i, name + i);
            }

            ExtendedDatabase db = new ExtendedDatabase(people);

            Random random = new Random();
            long existingId = people[random.Next(people.Length)].Id;            

            Assert.Throws<InvalidOperationException>(() => db.Add(new Person(existingId, "Stancho")),
               "There is already user with this Id!");
        }

        [Test]
        [TestCase(1, "Pesho", 5)]
        [TestCase(56, "Gosho", 7)]
        [TestCase(2, "Pesho", 13)]
        public void RemoveMethodShouldWorksCorrectly(long id, string name, int count)
        {
            Person[] people = new Person[count];

            for (int i = 0; i < count; i++)
            {
                people[i] = new Person(id + i, name + i);
            }

            ExtendedDatabase db = new ExtendedDatabase(people);
            db.Remove();

            Assert.AreEqual(count - 1, db.Count);
        }

        [Test]
        public void RemoveMethodShouldThrowsExceptionIfEmptyDatabase()
        {    
            ExtendedDatabase db = new ExtendedDatabase();            

            Assert.That(() => db.Remove(), Throws.InvalidOperationException);
        }

        [Test]
        [TestCase(1, "Pesho", 5, "Pesho4")]
        [TestCase(56, "Gosho", 7, "Gosho6")]
        [TestCase(2, "Pesho", 13, "Pesho10")]
        public void FindByUserNameMethodShouldWorksCorrectly(long id, string name, int count, string searchedName)
        {
            Person[] people = new Person[count];

            for (int i = 0; i < count; i++)
            {
                people[i] = new Person(id + i, name + i);
            }

            ExtendedDatabase db = new ExtendedDatabase(people);
            Person result = db.FindByUsername(searchedName);

            Assert.AreEqual(searchedName, result.UserName);
        }

        [Test]
        [TestCase(1, "Pesho", 5, "Pesho")]
        [TestCase(56, "Gosho", 7, "GoSHo")]
        [TestCase(2, "Pesho", 13, "Pesho")]
        public void FindByUserNameMethodShouldThrowsExceptionForUnexistingUserName(long id, string name, int count, string searchedName)
        {
            Person[] people = new Person[count];

            for (int i = 0; i < count; i++)
            {
                people[i] = new Person(id + i, name + i);
            }

            ExtendedDatabase db = new ExtendedDatabase(people);            

            Assert.Throws<InvalidOperationException>(() => db.FindByUsername(searchedName),
               "No user is present by this username!");
        }

        [Test]
        [TestCase(1, "Pesho", 5, null)]
        [TestCase(56, "Gosho", 7, "")]
        public void FindByUserNameMethodShouldThrowsExceptionForNullUsername(long id, string name, int count, string searchedName)
        {
            Person[] people = new Person[count];

            for (int i = 0; i < count; i++)
            {
                people[i] = new Person(id + i, name + i);
            }

            ExtendedDatabase db = new ExtendedDatabase(people);

            Assert.Throws<ArgumentNullException>(() => db.FindByUsername(searchedName),
               "Username parameter is null!");
        }

        [Test]
        [TestCase(1, "Pesho", 5, 4)]
        [TestCase(56, "Gosho", 7, 58)]
        [TestCase(2, "Pesho", 13, 3)]
        public void FindByIdMethodShouldWorksCorrectly(long id, string name, int count, long searchedId)
        {
            Person[] people = new Person[count];

            for (int i = 0; i < count; i++)
            {
                people[i] = new Person(id + i, name + i);
            }

            ExtendedDatabase db = new ExtendedDatabase(people);
            Person result = db.FindById(searchedId);

            Assert.AreEqual(searchedId, result.Id);
        }

        [Test]
        [TestCase(1, "Pesho", 5, 56)]
        [TestCase(56, "Gosho", 7, 13456)]
        [TestCase(2, "Pesho", 13, 78567)]
        public void FindByIdMethodShouldThrowsExceptionForUnexistingId(long id, string name, int count, long searchedId)
        {
            Person[] people = new Person[count];

            for (int i = 0; i < count; i++)
            {
                people[i] = new Person(id + i, name + i);
            }

            ExtendedDatabase db = new ExtendedDatabase(people);          

            Assert.Throws<InvalidOperationException>(() => db.FindById(searchedId),
                "No user is present by this ID!");              
        }

        [Test]
        [TestCase(1, "Pesho", 5, -2747)]
        [TestCase(56, "Gosho", 7, -343)]
        [TestCase(2, "Pesho", 13, -3445)]
        public void FindByIdMethodShouldThrowsExceptionForNegativeId(long id, string name, int count, long searchedId)
        {
            Person[] people = new Person[count];

            for (int i = 0; i < count; i++)
            {
                people[i] = new Person(id + i, name + i);
            }

            ExtendedDatabase db = new ExtendedDatabase(people);

            Assert.Throws<ArgumentOutOfRangeException>(() => db.FindById(searchedId),
                "Id should be a positive number!");
        }

    }
}