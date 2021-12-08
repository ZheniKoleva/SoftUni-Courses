using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private BankVault bankVault;

        private Item item;

        [SetUp]
        public void Setup()
        {
            bankVault = new BankVault();
            item = new Item("Pesho", "123");
        }


        [Test]
        public void ConstructorShouldInitializeBankVaultyCorrectly()
        {
            Assert.IsNotNull(bankVault);
        }

        [Test]
        public void AddMethodShouldThrowsExceptionForUnexistingcell()
        {
            string cell = "D1";

            Assert.Throws<ArgumentException>(() => bankVault.AddItem(cell, item),
                "Cell doesn't exists!");
        }

        [Test]
        public void AddMethodShouldThrowsExceptionForUnAvailableCell()
        {
            string cell = "A1";

            bankVault.AddItem(cell, item);

            Item itemToInsert = new Item("Pesho", "124");

            Assert.Throws<ArgumentException>(() => bankVault.AddItem(cell, itemToInsert),
                "Cell is already taken!");
        }

        [Test]
        public void AddMethodShouldWorksCorrectlyForAlreadyTakenCell()
        {
            string cell = "A2";
            bankVault.AddItem(cell, item);

            string cellToInsert = "B1";

            Assert.Throws<InvalidOperationException>(() => bankVault.AddItem(cellToInsert, item),
                "Item is already in cell!");
        }

        [Test]
        public void AddMethodShouldWorksCorrectly()
        {
            string cell = "A1";           

            string expected = $"Item:{item.ItemId} saved successfully!";
            string actual = bankVault.AddItem(cell, item);

            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void RemoveMethodShouldThrowsExceptionForUnexsotingcell()
        {
            string cell = "D1";

            Assert.Throws<ArgumentException>(() => bankVault.RemoveItem(cell, item),
                "Cell doesn't exists!");
        }

        [Test]
        public void RemoveMethodShouldThrowsExceptionForUnexsitingitem()
        {
            string cell = "B1";

            bankVault.AddItem(cell, item);

            Item itemToRemove = new Item("Pesho", "124");

            Assert.Throws<ArgumentException>(() => bankVault.RemoveItem(cell, itemToRemove),
                "Item in that cell doesn't exists!");
        }

        [Test]
        public void RemoveMethodShouldWorksCorrectly()
        {
            string cell = "C3";
           
            bankVault.AddItem(cell, item);

            string expected = $"Remove item:{item.ItemId} successfully!";
            string actual = bankVault.RemoveItem(cell, item);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void VaultCellsShouldWorksCorrectly()
        {
            string firstCell = "B2";
            string secondCell = "B3";
            string thirdCell = "B4";

            Item secondItem = new Item("Gosho", "1234");
            Item thirdItem = new Item("Tosho", "12345");

            bankVault.AddItem(firstCell, item);
            bankVault.AddItem(secondCell, secondItem);
            bankVault.AddItem(thirdCell, thirdItem);

            Dictionary<string, Item> expected = new Dictionary<string, Item>
            {
                { firstCell, item},
                { secondCell, secondItem},
                { thirdCell, thirdItem}            
            };

            Dictionary<string, Item> actual = bankVault.VaultCells.Where(x => x.Value != null)
                .ToDictionary(x => x.Key, x => x.Value);

           CollectionAssert.AreEqual(expected, actual);
        }

    }
}