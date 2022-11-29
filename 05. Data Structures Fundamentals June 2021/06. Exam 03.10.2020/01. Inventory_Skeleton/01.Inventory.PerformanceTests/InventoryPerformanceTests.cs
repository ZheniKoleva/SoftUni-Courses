namespace _01.Inventory.PerformanceTests
{
    using _01.Inventory;
    using _01.Inventory.Interfaces;
    using _01.Inventory.Models;
    using NUnit.Framework;
    using System;
    using System.Diagnostics;

    public class InventoryPerformanceTests
    {
        [Test]
        public void Swap_1000_Entries()
        {
            Random rnd = new Random();
            Stopwatch sw = new Stopwatch();
            IHolder inventory = new Inventory();
            for (int i = 0; i < 1000; i++)
            {
                int rndAmmunition = rnd.Next(100);
                int rndMaxCapacity = rndAmmunition + 10;

                inventory.Add(new Pistol(i, rndMaxCapacity, rndAmmunition));
            }

            var allWeapons = inventory.RetrieveAll();
            var secondToLast = allWeapons[allWeapons.Count - 2];
            var last = allWeapons[allWeapons.Count - 1];

            sw.Start();
            for (int i = 0; i < 1000; i++)
            {
                inventory.Swap(secondToLast, last);
            }
            sw.Stop();

            Assert.IsTrue(sw.ElapsedMilliseconds <= 90);
        }
    }
}