using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private BankVault vault;
        private Item item;
        private Item item2;
        [SetUp]
        public void Setup()
        {
            this.item = new Item("Owner", "1234");
            this.item2 = new Item("Owner2", "12345");
            this.vault = new BankVault();
        }

        [Test]
        public void CheckIfConstructorWorksCorrectly()
        {
            Assert.IsNotNull(vault);
        }
        [Test]
        public void CheckAddItemWorksCorrectly()
        {
            vault.AddItem("A1", item);
            Assert.That(vault.VaultCells["A1"].ItemId, Is.EqualTo("1234"));
        }
        [Test]
        public void AddItemThrowsExceptionWhenNoCell()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                vault.AddItem("p1", item);
            });
        }
        [Test]
        public void AddItemThrowsExceptionWhenCellAreadyTaken()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                vault.AddItem("A1", item);
                vault.AddItem("A1", item2);
            });
        }
        [Test]
        public void AddItemThrowsExceptionWhenItemAlreadyAdded()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                vault.AddItem("A1", item);
                vault.AddItem("A2", item);
            });
        }
        [Test]
        public void AddItemReturnsCorrectly()
        {
            Assert.AreEqual(vault.AddItem("A1", item), $"Item:{ item.ItemId} saved successfully!");
        }
        [Test]
        public void CheckIfRemoveItemWorksCorrectly()
        {
            vault.AddItem("A1", item);
            vault.RemoveItem("A1", item);
            Assert.That(vault.VaultCells["A1"], Is.Null);
        }
        [Test]
        public void CheckIfRemoveItemReturnsCorrectly()
        {
            vault.AddItem("A1", item);
            Assert.AreEqual(vault.RemoveItem("A1", item), $"Remove item:{item.ItemId} successfully!");
        }
        [Test]
        public void CheckIfRemoveItemThrowExceptionWhenCellNotExist()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                vault.RemoveItem("dfd1", item);
            });
        }
        [Test]
        public void CheckIfRemoveItemThrowExceptionWhenItemNotExist()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                vault.RemoveItem("A1", item);
            });
        }
    }
}