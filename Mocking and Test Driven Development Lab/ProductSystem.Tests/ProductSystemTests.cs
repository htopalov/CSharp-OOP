using Mocking_and_Test_Driven_Development_Lab.Contracs;
using Moq;
using NUnit.Framework;
using System;
using Mocking_and_Test_Driven_Development_Lab;
using System.Collections.Generic;

namespace ProductSystem.Tests
{
    [TestFixture]
    public class ProductSystemTests
    {
        private IList<IProduct> repo;
        private Mock<IProduct> productMock1;
        private Mock<IProduct> productMock2;
        private Mock<IProduct> productMock3;
        private Mocking_and_Test_Driven_Development_Lab.ProductSystem system;
        [SetUp]
        public void SetUp()
        {
            repo = new List<IProduct>();
            system = new Mocking_and_Test_Driven_Development_Lab.ProductSystem(repo);
            productMock1 = new Mock<IProduct>();
            productMock2 = new Mock<IProduct>();
            productMock3 = new Mock<IProduct>();
            productMock1.Setup(p => p.Label).Returns("Jeans");
            productMock1.Setup(p => p.Price).Returns(12.50m);
            productMock1.Setup(p => p.Quantity).Returns(12);
            productMock2.Setup(p => p.Label).Returns("Shirt");
            productMock2.Setup(p => p.Price).Returns(24.50m);
            productMock2.Setup(p => p.Quantity).Returns(1);
            productMock3.Setup(p => p.Label).Returns("Boots");
            productMock3.Setup(p => p.Price).Returns(112.50m);
            productMock3.Setup(p => p.Quantity).Returns(1);
        }
        [Test]
        public void ProductShouldBeAddedToSystem()
        {

            system.Add(productMock1.Object);
            Assert.That(system[0].Label, Is.EqualTo("Jeans"));
        }
        [Test]
        public void SystemShouldContainProduct()
        {
            repo.Add(productMock1.Object);
            Assert.That(system.Contains(productMock1.Object), Is.True);
        }
        [Test]
        public void AddThrowsExceptionIfProductAlreadyAdded()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                system.Add(productMock1.Object);
                system.Add(productMock1.Object);
            });

        }
        [Test]
        public void CountShouldWorkCorrectly()
        {
            repo.Add(productMock1.Object);
            Assert.That(system.Count, Is.EqualTo(1));
        }
        [Test]
        public void FindShouldFindProductCorrectly()
        {
            repo.Add(productMock1.Object);
            Assert.That(system.Find(0), Is.EqualTo(system[0]));
        }
        [TestCase(-1)]
        [TestCase(123)]
        public void FindShouldThrowExceptionWhenIndexIsInvalid(int index)
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                system.Add(productMock1.Object);
                system.Find(index);
            });
        }
        [Test]
        public void FindAllByPriceWorksReturnsEmptyCollection()
        {
            system.Add(productMock1.Object);
            system.Add(productMock2.Object);
            system.Add(productMock3.Object);
            var list = system.FindAllByPrice(234.34m);
            Assert.That(list, Is.Empty);
        }
        [Test]
        public void FindAllByPriceWorksReturnsCollectionWithProductsFoundAccordingToPrice()
        {
            system.Add(productMock1.Object);
            system.Add(productMock2.Object);
            system.Add(productMock3.Object);
            var list = system.FindAllByPrice(24.50m);
            Assert.That(list[0], Is.EqualTo(productMock2.Object));
        }
        [Test]
        public void FindAllByQuantityWorksReturnsEmptyCollection()
        {
            system.Add(productMock1.Object);
            system.Add(productMock2.Object);
            system.Add(productMock3.Object);
            var list = system.FindAllByQuantity(23);
            Assert.That(list, Is.Empty);
        }
        [Test]
        public void FindAllByQuantityWorksReturnsCollectionWithProductsFoundAccordingToQuantity()
        {
            system.Add(productMock1.Object);
            system.Add(productMock2.Object);
            system.Add(productMock3.Object);
            var list = system.FindAllByQuantity(1);
            Assert.That(list.Count, Is.EqualTo(2));
        }
        [Test]
        public void FindAllInPriceRangeWorksReturnsEmptyCollection()
        {
            system.Add(productMock1.Object);
            system.Add(productMock2.Object);
            system.Add(productMock3.Object);
            var list = system.FindAllInPriceRange(200,300);
            Assert.That(list, Is.Empty);
        }
        [Test]
        public void FindAllInPriceRangeWorksReturnsCollectionWithProductsFoundAccordingToPriceRange()
        {
            system.Add(productMock1.Object);
            system.Add(productMock2.Object);
            system.Add(productMock3.Object);
            var list = system.FindAllInPriceRange(12.01m, 25.56m);
            Assert.That(list.Count, Is.EqualTo(2));
        }
        [Test]
        public void FindByLabelShouldThrowExceptionWhenProductLabelNotExists()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                system.FindByLabel("Label");
            });
        }
        [Test]
        public void FindByLabelShouldReturnProductWithGivenLabel()
        {
            system.Add(productMock1.Object);
            var product = system.FindByLabel("Jeans");
            Assert.That(product, Is.EqualTo(productMock1.Object));
        }
        [Test]
        public void FindMostExpensiveProductWorksCorrectly()
        {
            system.Add(productMock1.Object);
            system.Add(productMock2.Object);
            system.Add(productMock3.Object);
            var product = system.FindMostExpensiveProducts();
            Assert.AreEqual(product, productMock3.Object);
        }
    }
}
