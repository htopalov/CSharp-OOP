using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Computers.Tests
{
    public class Tests
    {
        private ComputerManager manager;
        private Computer computer;
        [SetUp]
        public void Setup()
        {
            manager = new ComputerManager();
            computer = new Computer("Manufacturer", "Model", 13.50m);
        }
        [Test]
        public void CheckIfConstructorWorksCorrectly()
        {
            Assert.IsNotNull(manager);
        }
        [Test]
        public void CheckIfAddComputerWorksCorrectly()
        {
            //////////////////////////////
            manager.AddComputer(computer);
            Assert.AreEqual(manager.Count, 1);
        }
        [Test]
        public void CheckIfValidateNullValueMethodThrowsExceptionWhenAdding()
        {
            ////////////////////////////////////
            Computer comp = null;
            Assert.Throws<ArgumentNullException>(() =>
            {
                manager.AddComputer(comp);
            });
        }
        [Test]
        public void CheckIfAddComputerThrowsExceptionWhenComputerExists()
        {
            //////////////////////////////////////
            Assert.Throws<ArgumentException>(() =>
            {
                for (int i = 0; i < 3; i++)
                {
                    manager.AddComputer(computer);
                }
            });
        }
        [Test]
        public void CheckIfRemoveComputerWorksCorrectly()
        {
            /////////////////////////////
            manager.AddComputer(computer);
            manager.RemoveComputer("Manufacturer", "Model");
            Assert.AreEqual(manager.Count, 0);
        }
        [Test]
        public void RemoveMethodShouldThrowNullExceptionWhenManufacturerIsNull()
        {
            this.manager.AddComputer(this.computer);

            Assert.Throws<ArgumentNullException>(() =>
            {
                this.manager.RemoveComputer(null, "a");
            });
        }

        [Test]
        public void RemoveMethodShouldThrowNullExceptionWhenModelIsNull()
        {
            this.manager.AddComputer(this.computer);

            Assert.Throws<ArgumentNullException>(() =>
            {
                this.manager.RemoveComputer("sony", null);
            });
        }
        [Test]
        public void CheckIfGetComputerWorksCorrectly()
        {
            manager.AddComputer(computer);
            var returned = manager.GetComputer("Manufacturer", "Model");
            Assert.AreEqual(computer, returned);
        }
        [Test]
        public void CheckIfGetComputerThrowsExceptionWhenComputerNull()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                manager.GetComputer("Apple", "Mac");
            });
        }
        [Test]
        public void CheckIfGetComputersByManufacturerWorksCorrectly()
        {
            manager.AddComputer(new Computer("Apple", "Mac1", 12.4m));
            manager.AddComputer(new Computer("Apple", "Mac2", 122.4m));
            manager.AddComputer(new Computer("Apple", "Mac3", 121.4m));
            var listByManufacturer = manager.GetComputersByManufacturer("Apple");
            Assert.IsNotNull(listByManufacturer);
        }
        [Test]
        public void CheckIfGetComputersByManufacturerReturnsNullWhenNoComputerWithThisManufacturer()
        {
            manager.AddComputer(new Computer("Apple", "Mac1", 12.4m));
            manager.AddComputer(new Computer("Apple", "Mac2", 122.4m));
            manager.AddComputer(new Computer("Apple", "Mac3", 121.4m));
            var listByManufacturer = manager.GetComputersByManufacturer("Dell");
            Assert.AreEqual(listByManufacturer.Count, 0);
        }
        [Test]
        public void CheckIfGetComputersByManufacturerWithManufacturerNullThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var listByManufacturer = manager.GetComputersByManufacturer(null);
            });

        }
        [Test]
        public void CheckNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var listByManufacturer = manager.GetComputer(null, null);
            });
        }
        [Test]
        public void CheckComputersProperty()
        {
            manager.AddComputer(new Computer("Apple", "Mac1", 12.4m));
            manager.AddComputer(new Computer("Apple", "Mac2", 122.4m));
            manager.AddComputer(new Computer("Apple", "Mac3", 121.4m));
            Assert.AreEqual(manager.Count, manager.Computers.Count);
        }
        [Test]
        public void CheckIfComputerReturnsReadOnly()
        {
            manager.AddComputer(new Computer("Apple", "Mac1", 12.4m));
            manager.AddComputer(new Computer("Apple", "Mac2", 122.4m));
            manager.AddComputer(new Computer("Apple", "Mac3", 121.4m));
            Assert.True(manager.Computers is IReadOnlyCollection<Computer>);
        }

    }
}