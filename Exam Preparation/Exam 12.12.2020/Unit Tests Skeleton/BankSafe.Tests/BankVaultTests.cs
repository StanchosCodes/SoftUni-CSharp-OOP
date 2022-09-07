using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace BankSafe.Tests
{
    [TestFixture]
    public class BankVaultTests
    {
        private BankVault testVault;
        private Item testItem;

        [SetUp]
        public void SetUp()
        {
            this.testVault = new BankVault();
            this.testItem = new Item("Stancho", "A1");
        }

        [Test]
        public void ContructorShouldCreateDictionaryOfStringAndItemWithCells()
        {
            Dictionary<string, Item> testDictionary = new Dictionary<string, Item>
            {
                {"A1", null},
                {"A2", null},
                {"A3", null},
                {"A4", null},
                {"B1", null},
                {"B2", null},
                {"B3", null},
                {"B4", null},
                {"C1", null},
                {"C2", null},
                {"C3", null},
                {"C4", null},
            };

            CollectionAssert.AreEqual(this.testVault.VaultCells, testDictionary);
        }

        [Test]
        public void AddItemShouldThrowIfCellDoesntExist()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.testVault.AddItem("C5", this.testItem);
            }, "Cell doesn't exists!");
        }

        [Test]
        public void AddItemShouldThrowIfCellIsTaken()
        {
            Item item2 = new Item("Stanchoo", "A1");

            this.testVault.AddItem("A1", item2);

            Assert.Throws<ArgumentException>(() =>
            {
                this.testVault.AddItem("A1", this.testItem);
            }, "Cell is already taken!");
        }

        [Test]
        public void AddShouldThrowIfItemIsAlreadyInTheCell()
        {
            this.testVault.AddItem("A2", this.testItem);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.testVault.AddItem("A1", this.testItem);
            }, "Item is already in cell!");
        }

        [Test]
        public void AddShouldAddCorrectly()
        {
            string result = this.testVault.AddItem("A1", this.testItem);
            string expectedResult = $"Item:{this.testItem.ItemId} saved successfully!";

            Assert.AreEqual(result, expectedResult);
        }

        [Test]
        public void RemoveItemShouldThrowIfCellDoesntExist()
        {
            this.testVault.AddItem("A1", this.testItem);

            Assert.Throws<ArgumentException>(() =>
            {
                this.testVault.RemoveItem("C5", this.testItem);
            }, "Cell doesn't exists!");
        }

        [Test]
        public void RemoveShouldThrowIfItemDoesntExist()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.testVault.RemoveItem("A1", this.testItem);
            }, "Item in that cell doesn't exists!");
        }

        [Test]
        public void RemoveItemShouldRemoveCorrectly()
        {
            this.testVault.AddItem("A1", this.testItem);

            string result = this.testVault.RemoveItem("A1", this.testItem);
            string expectedResult = $"Remove item:{this.testItem.ItemId} successfully!";

            Assert.AreEqual(result, expectedResult);
        }
    }
}