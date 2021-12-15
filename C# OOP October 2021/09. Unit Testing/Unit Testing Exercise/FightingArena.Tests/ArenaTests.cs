using NUnit.Framework;
using System;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;

        private Warrior first;

        private Warrior second;

        [SetUp]
        public void Setup()
        {
            arena = new Arena();
            first = new Warrior("Pesho", 150, 120);
            second = new Warrior("Gosho", 100, 100);
        }

        [Test]
        public void ConstructorShouldWorkCorrectly()           
        {    
            Assert.IsNotNull(arena);
        }


        [Test] 
        [TestCase("Stancho", 4325, 7264, 12)]
        [TestCase("Pesho", 100, 15, 1)]
        public void EnrollMethodShouldWorkCorrectly(
            string warriorName, 
            int warriorDamage, 
            int warriorHP, 
            int warriorCount)
        {           

            for (int i = 0; i < warriorCount; i++)
            {
                arena.Enroll(new Warrior(warriorName + i, warriorDamage + i, warriorHP + i));
            }

            Assert.AreEqual(warriorCount, arena.Count);
        }

        [Test]
        [TestCase("Stancho", 4325, 7264, 12)]
        [TestCase("Pesho", 100, 15, 5)]
        public void EnrollMethodShouldThrowExceptionIfEnrollExistingWarriorName(
           string warriorName,
           int warriorDamage,
           int warriorHP,
           int warriorCount)
        {          

            for (int i = 0; i < warriorCount; i++)
            {
                arena.Enroll(new Warrior(warriorName + i, warriorDamage + i, warriorHP + i));
            }

            Random random = new Random();
            int existingNameIndx = random.Next(warriorCount);
            Warrior toEnroll = new Warrior(warriorName + existingNameIndx, 200, 300);

            Assert.Throws<InvalidOperationException>(() => arena.Enroll(toEnroll),
                "Warrior is already enrolled for the fights!");
        }

        [Test]        
        public void WarriorsShouldWorkCorrectly()
        {            
            Warrior[] expected = new Warrior[] { first, second };
            
            arena.Enroll(first);
            arena.Enroll(second);           

            CollectionAssert.AreEqual(expected, arena.Warriors);
        }

        [Test]
        [TestCase("Pesho", "Gosho")]       
        public void FightMethodShouldWorkCorrectly(string firstWarriorName, string secondWarriorName)
        {    
            arena.Enroll(first);
            arena.Enroll(second);

            int expectedFirstHp = first.HP - second.Damage;            

            arena.Fight(firstWarriorName, secondWarriorName);

            Assert.AreEqual(expectedFirstHp, first.HP); 
            Assert.GreaterOrEqual(second.HP, 0);             
        }

        [Test]
        [TestCase("Tosho", "Gosho")]
        [TestCase("Pesho", "Stamat")]
        public void FightMethodShouldThrowExceptionWhenWarriorDoesnotExist(string firstWarriorName, string secondWarriorName)
        {   
            arena.Enroll(first);
            arena.Enroll(second);

            Assert.Throws<InvalidOperationException>(() 
                => arena.Fight(firstWarriorName, secondWarriorName)); 
        }
    }
}
