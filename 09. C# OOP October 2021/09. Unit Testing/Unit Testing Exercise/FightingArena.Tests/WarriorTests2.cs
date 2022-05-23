using NUnit.Framework;
using System;

namespace Tests
{
    public class WarriorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("Pesho", 50, 50)]
        [TestCase("Gosho", int.MaxValue, 50)]
        [TestCase("Dragan", 50, int.MaxValue)]
        public void ConstructorShouldWorksCorrectly(string name, int damage, int hp)
        {
            Warrior warrior = new Warrior(name, damage, hp);

            Assert.AreEqual(name, warrior.Name);
            Assert.AreEqual(damage, warrior.Damage);
            Assert.AreEqual(hp, warrior.HP);
        }

        [Test]
        [TestCase("", 50, 50)]
        [TestCase(" ", 50, int.MaxValue)]
        [TestCase(null, int.MaxValue, 50)]
        public void PropertyNameShouldThrowsExceptionWhenItIsNullOrEmpty(string name, int damage, int hp)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name,damage,hp), "Name should not be empty or whitespace!");
        }

        [Test]
        [TestCase("Pesho", 0, 50)]
        [TestCase("Gosho", -1, 50)]
        [TestCase("Dragan", int.MinValue, int.MaxValue)]
        public void PropertyDamageShouldThrowsExceptionWhenItIsNegativeOrZero(string name, int damage, int hp)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, damage, hp), "Damage value should be positive!");
        }

        [Test]
        [TestCase("Pesho", 50, -1)]
        [TestCase("Gosho", int.MaxValue, -50)]
        [TestCase("Dragan", 50, int.MinValue)]
        public void PropertyHPShouldThrowsExceptionWhenItIsNegative(string name, int damage, int hp)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, damage, hp), "HP should not be negative!");
        }

        [Test]
        [TestCase("Pesho", 50, 30, "Gosho", 50, 50)]
        [TestCase("Gosho", 50, 29, "Dragan", 50, 49)]
        [TestCase("Oktai", 50, 0, "Mehmed", 50, 40)]
        public void MethodAttackShouldThrowsExceptionWhenMyHPIsLessThanOrEqual30(string myName, int myDamage, int myHP, string enemyName, int enemyDamage, int enemyHP)
        {
            Warrior warrior = new Warrior(myName, myDamage, myHP);
            Warrior enemyWarrior = new Warrior(enemyName, enemyDamage, enemyHP);

            Assert.Throws<InvalidOperationException>(() => warrior.Attack(enemyWarrior), "Your HP is too low in order to attack other warriors!");
        }

        [Test]
        [TestCase("Pesho", 50, 50, "Gosho", 50, 30)]
        [TestCase("Gosho", 50, 49, "Dragan", 50, 29)]
        [TestCase("Oktai", 50, 40, "Mehmed", 50, 0)]
        public void MethodAttackShouldThrowsExceptionWhenEnemyHPIsLessThanOrEqual30(string myName, int myDamage, int myHP, string enemyName, int enemyDamage, int enemyHP)
        {
            Warrior warrior = new Warrior(myName, myDamage, myHP);
            Warrior enemyWarrior = new Warrior(enemyName, enemyDamage, enemyHP);

            Assert.Throws<InvalidOperationException>(() => warrior.Attack(enemyWarrior), "Enemy HP must be greater than 30 in order to attack him!");
        }

        [Test]
        [TestCase("Pesho", 50, 31, "Gosho", 50, 45)]
        [TestCase("Gosho", 50, 50, "Dragan", 60, 49)]
        [TestCase("Oktai", 50, 70, "Mehmed", 71, 31)]
        public void MethodAttackShouldThrowsExceptionWhenMyHPIsLessThanEnemyDamage(string myName, int myDamage, int myHP, string enemyName, int enemyDamage, int enemyHP)
        {
            Warrior warrior = new Warrior(myName, myDamage, myHP);
            Warrior enemyWarrior = new Warrior(enemyName, enemyDamage, enemyHP);

            Assert.Throws<InvalidOperationException>(() => warrior.Attack(enemyWarrior), "You are trying to attack too strong enemy");
        }

        [Test]
        [TestCase("Pesho", 50, 70, "Gosho", 50, 45)]
        [TestCase("Gosho", 50, 50, "Dragan", 40, 49)]
        [TestCase("Oktai", 50, 70, "Mehmed", 49, 31)]
        public void MethodAttackShouldWorksCorrectly(string myName, int myDamage, int myHP, string enemyName, int enemyDamage, int enemyHP)
        {
            Warrior myWarrior = new Warrior(myName, myDamage, myHP);
            Warrior enemyWarrior = new Warrior(enemyName, enemyDamage, enemyHP);

            myWarrior.Attack(enemyWarrior);

            Assert.AreEqual(myHP - enemyWarrior.Damage, myWarrior.HP);
            Assert.AreEqual(0, enemyWarrior.HP);
        }

        [Test]
        [TestCase("Pesho", 50, 70, "Gosho", 50, 55)]
        [TestCase("Gosho", 50, 50, "Dragan", 40, 51)]
        [TestCase("Oktai", 50, 70, "Mehmed", 49, 70)]
        public void MethodAttackShouldReturnsEnemyHp(string myName, int myDamage, int myHP, string enemyName, int enemyDamage, int enemyHP)
        {
            Warrior myWarrior = new Warrior(myName, myDamage, myHP);
            Warrior enemyWarrior = new Warrior(enemyName, enemyDamage, enemyHP);

            myWarrior.Attack(enemyWarrior);

            Assert.AreEqual(enemyHP - myWarrior.Damage, enemyWarrior.HP);
        }
    }
}