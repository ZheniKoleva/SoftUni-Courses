namespace _01.Inventory.Tests
{
    using _01.Inventory.Interfaces;
    using _01.Inventory.Models;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class InventoryTests
    {
        private IHolder _inventory;
        private IWeapon _savedWeapon;

        [SetUp]
        public void SetupInventory()
        {
            this._inventory = new Inventory();
            ConstructorInfo[] constructors = new ConstructorInfo[]
            {
                this.GetConstructorInfo(typeof(Pistol)),
                this.GetConstructorInfo(typeof(Shotgun)),
                this.GetConstructorInfo(typeof(Minigun)),
                this.GetConstructorInfo(typeof(Sniper)),
                this.GetConstructorInfo(typeof(RocketLauncher)),
                this.GetConstructorInfo(typeof(Cannon)),
            };
            Random rnd = new Random();
            int boundIndex = rnd.Next(20);

            for (int i = 0; i < 20; i++)
            {
                var rndConstructor = constructors[rnd.Next(constructors.Length)];
                var rndAmmunition = rnd.Next(500);
                var rndMaxCapacity = rndAmmunition + rnd.Next(100);
                IWeapon rndWeapon = (IWeapon) rndConstructor
                    .Invoke(new object[] { i, rndMaxCapacity, rndAmmunition });
                if (i == boundIndex)
                {
                    this._savedWeapon = rndWeapon;
                }

                this._inventory.Add(rndWeapon);
            }
        }

        private ConstructorInfo GetConstructorInfo(Type eType)
        {
            return eType.GetConstructor(new Type[] { typeof(int), typeof(int), typeof(int) });
        }

        [Test]
        public void CapacityWorksCorrectly()
        {
            Assert.AreEqual(20, this._inventory.Capacity);
        }

        [Test]
        public void AddWorksCorrectly()
        {
            this._inventory.Add(new Sniper(21, 200, 50));
            Assert.AreEqual(21, this._inventory.Capacity);
        }

        [Test]
        public void GetByIdWorksCorrectly()
        {
            IWeapon weaponById = this._inventory.GetById(this._savedWeapon.Id);

            Assert.AreEqual(this._savedWeapon, weaponById);
        }


        [Test]
        public void ContainsFindsEntity()
        {
            Assert.IsTrue(this._inventory.Contains(this._savedWeapon));
        }


        [Test]
        public void RefillAmmunitionWorksCorrectly()
        {
            int ammoToRefill = this._savedWeapon.MaxCapacity - this._savedWeapon.Ammunition;
            int expectedAmmo = this._savedWeapon.MaxCapacity;

            this._inventory.Refill(this._savedWeapon, ammoToRefill);

            Assert.AreEqual(expectedAmmo, this._savedWeapon.Ammunition);
        }

        [Test]
        public void FireWorksCorrectly()
        {
            Random rnd = new Random();
            int ammoToFire = rnd.Next(this._savedWeapon.Ammunition);
            int expectedAmmo = this._savedWeapon.Ammunition - ammoToFire;

            bool isPossible = this._inventory.Fire(this._savedWeapon, ammoToFire);

            Assert.IsTrue(isPossible);
            Assert.AreEqual(expectedAmmo, this._savedWeapon.Ammunition);
        }

        [Test]
        public void RemoveByIdWorksCorrectly()
        {
            var expectedCapacity = 19;

            IWeapon removed = this._inventory.RemoveById(this._savedWeapon.Id);

            Assert.AreEqual(expectedCapacity, this._inventory.Capacity);
            Assert.AreEqual(this._savedWeapon, removed);
        }

        [Test]
        public void SwapWorksCorrectly()
        {
            IWeapon freshWeapon = null;

            switch (this._savedWeapon.Category)
            {
                case Category.Light:
                    freshWeapon = new Pistol(21, 500, 400);
                    break;
                case Category.Medium:
                    freshWeapon = new Minigun(21, 500, 500);
                    break;
                case Category.Heavy:
                    freshWeapon = new Cannon(21, 100, 80);
                    break;
                default:
                    break;
            }

            this._inventory.Add(freshWeapon);
            Assert.AreEqual(21, this._inventory.Capacity);

            var allWeapons = this._inventory.RetrieveAll();
            int firstIndex = allWeapons.IndexOf(this._savedWeapon);
            int secondIndex = allWeapons.IndexOf(freshWeapon);

            this._inventory.Swap(this._savedWeapon, freshWeapon);
            allWeapons = this._inventory.RetrieveAll();

            Assert.AreEqual(firstIndex, allWeapons.IndexOf(freshWeapon));
            Assert.AreEqual(secondIndex, allWeapons.IndexOf(this._savedWeapon));
        }

        [Test]
        public void RetrieveAllWorksCorrectly()
        {
            var allWeapons = this._inventory.RetrieveAll();

            Assert.AreEqual(20, allWeapons.Capacity);
        }

        [Test]
        public void ClearWorksCorrectly()
        {
            this._inventory.Clear();

            Assert.AreEqual(0, this._inventory.Capacity);
        }


        [Test]
        public void RetrieveInRangeWorksCorrectly()
        {
            this._inventory.Add(new Minigun(22, 200, 200));
            this._inventory.Add(new Cannon(23, 200, 200));

            List<IWeapon> weaponsInRange = this._inventory.RetrieveAll()
                .Where(w => (int)w.Category >= 1 && (int)w.Category <= 2)
                .OrderBy(w => w.Id)
                .ToList();

            List<IWeapon> actualWeapons = this._inventory
                .RetriveInRange(Category.Medium, Category.Heavy)
                .OrderBy(w => w.Id)
                .ToList(); ;

            Assert.AreEqual(weaponsInRange.Capacity, actualWeapons.Capacity);

            for (int i = 0; i < weaponsInRange.Count; i++)
            {
                Assert.AreEqual(weaponsInRange[i], actualWeapons[i]);
            }
        }

        [Test]
        public void EmptyArsenalWorksCorrectly()
        {
            this._inventory.Add(new Pistol(21, 200, 200));

            this._inventory.EmptyArsenal(Category.Light);

            var allLightWeapons = this._inventory
                .RetrieveAll()
                .Where(w => w.Category == Category.Light);

            foreach (var weapon in allLightWeapons)
            {
                Assert.AreEqual(0, weapon.Ammunition);
            }
        }

        [Test]
        public void RemoveHeavyWorksCorrectly()
        {
            this._inventory.Add(new Cannon(21, 200, 200));
            int expectedCount = this._inventory.RetrieveAll()
                .Count(w => w.Category == Category.Heavy);

            int actualCount = this._inventory.RemoveHeavy();
            var allHeavyWeapons = this._inventory
                .RetrieveAll()
                .Where(w => w.Category == Category.Heavy);

            Assert.AreEqual(expectedCount, actualCount);
            Assert.IsEmpty(allHeavyWeapons);
        }

        [Test]
        public void EnumeratorWorksCorrectly()
        {
            int count = 0;
            foreach (var weapon in this._inventory)
            {
                count++;
            }

            Assert.AreEqual(20, count);
        }
    }
}