using NUnit.Framework;
using System;

namespace Tests
{
    public class WarriorTests
    {
        private const int MIN_ATTACK_HP = 30;

        private Warrior attacker;

        private Warrior defender;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("Pesho", 100, 0)]
        [TestCase("Gosho", int.MaxValue, int.MaxValue)]
        [TestCase("Stancho", 45654, 785564)]
        public void ConstructorShouldWorksCorrectly(string name, int damage, int hp)
        {
            Warrior warrior = new Warrior(name, damage, hp);

            Assert.AreEqual(name, warrior.Name);
            Assert.AreEqual(damage, warrior.Damage);
            Assert.AreEqual(hp, warrior.HP);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        [TestCase(" ")]
        public void NameShouldThrowExceptionIfNullOrWhiteSpaceOrEmpty(string name)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, 100, 80),
                "Name should not be empty or whitespace!");
        }

        [Test]
        [TestCase(0)]
        [TestCase(int.MinValue)]
        public void DamageShouldThrowExceptionIfNegativeOrZero(int damage)
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Pesho", damage, 200),
                "Damage value should be positive!");
        }

        [Test]
        [TestCase(int.MinValue)]
        [TestCase(-34325)]
        public void HPShouldThrowExceptionIfNegative(int hp)
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Pesho", 1000, hp),
                "HP should not be negative!");
        }

        [Test]
        [TestCase(MIN_ATTACK_HP)]
        [TestCase(15)]        
        public void AttackMethodShouldThrowExceptionIfAttackerHPAreEqualOrBelowMinAttackHP(
            int attackerHP)
        {
            attacker = new Warrior("Pesho", 100, attackerHP);
            defender = new Warrior("Gosho", 200, 50);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(defender),
                "Your HP is too low in order to attack other warriors!");
        }

        [Test]
        [TestCase(MIN_ATTACK_HP)]       
        [TestCase(23)]
        public void AttackMethodShouldThrowExceptionIfDefenderHPAreEqualOrBelowMinAttackHP(           
            int defenderHP)
        {
            attacker = new Warrior("Pesho", 100, 100);
            defender = new Warrior("Gosho", 80, defenderHP);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(defender),
                $"Enemy HP must be greater than {MIN_ATTACK_HP} in order to attack him!");
        }

        [Test]
        [TestCase(120, 150)]
        [TestCase(100, 345)]
        public void AttackMethodShouldThrowExceptionIfAttackerHPAreLessThanDefenderDamage(
            int attackerHP, int defenderDamage)
        {
            attacker = new Warrior("Pesho", 100, attackerHP);
            defender = new Warrior("Gosho", 150, defenderDamage);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(defender),
                "You are trying to attack too strong enemy");
        }

        [Test]
        [TestCase(100, 120, 100, 100)]
        [TestCase(100, 100, 70, 150)]
        [TestCase(100, 100, 70, 90)]
        public void AttackMethodShouldWorksCorrectly(
            int attackerDamage, int attackerHP,
            int defenderDamage, int defenderHP)
        {
            attacker = new Warrior("Pesho", attackerDamage, attackerHP);
            defender = new Warrior("Gosho", defenderDamage, defenderHP);

            int expectedAttackerHP = attackerHP - defenderDamage;           

            attacker.Attack(defender);

            Assert.AreEqual(expectedAttackerHP, attacker.HP);
            Assert.GreaterOrEqual(defender.HP, 0);                    
        }

        //[Test]
        //[TestCase(150, 120, 100, 100)]
        //[TestCase(100, 100, 80, 90)]
        //public void AttackMethodShouldWorksCorrectlyAndDefenderHPAreZero(
        //    int attackerDamage, int attackerHP,
        //    int defenderDamage, int defenderHP)
        //{
        //    attacker = new Warrior("Pesho", attackerDamage, attackerHP);
        //    defender = new Warrior("Gosho", defenderDamage, defenderHP);

        //    int expectedAttackerHP = attackerHP - defenderDamage;

        //    attacker.Attack(defender);

        //    Assert.AreEqual(expectedAttackerHP, attacker.HP);
        //    Assert.AreEqual(0, defender.HP);
        //}

        //[Test]
        //[TestCase(200, 120, 100, 300)]
        //[TestCase(100, 100, 80, 150)]
        //[TestCase(300, 500, 250, 500)]
        //public void DefenderHPAreDecreasedByAttackerDamage(
        //   int attackerDamage, int attackerHP,
        //    int defenderDamage, int defenderHP)
        //{
        //    attacker = new Warrior("Pesho", attackerDamage, attackerHP);
        //    defender = new Warrior("Gosho", defenderDamage, defenderHP);

        //    int expectedDefenderHP = defenderHP - attackerDamage;

        //    attacker.Attack(defender);

        //    Assert.AreEqual(expectedDefenderHP, defender.HP);
        //}



    }
}