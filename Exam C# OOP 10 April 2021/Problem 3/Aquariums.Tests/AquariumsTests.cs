namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    public class AquariumsTests
    {
        private Fish fish;
        private Fish fish2;
        private List<Fish> fishList;
        private Aquarium aquarium;
        [SetUp]
        public void Setup()
        {
            this.fish = new Fish("Joro");
            this.fish2 = new Fish("Kolio");
            this.fishList = new List<Fish>();
            this.aquarium = new Aquarium("Aquarium", 10);
        }
        [Test]
        public void CheckExceptionNameProp()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Aquarium aqu = new Aquarium(null, 10);
            });
        }
        [Test]
        public void CheckExceptionNameProp2()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Aquarium aqu = new Aquarium("", 10);
            });
        }
        [Test]
        public void CheckExceptionCapacityProp()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Aquarium aqu = new Aquarium("Akvarium", -10);
            });
        }
        [Test]
        public void CountPropReturnsCorrectANDADDMethodWorksCorrectly()
        {
            aquarium.Add(fish);
            Assert.AreEqual(aquarium.Count, 1);
        }
        [Test]
        public void AddToAquariumThrowException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                for (int i = 0; i < 15; i++)
                {
                    aquarium.Add(new Fish($"Joro-{i}"));
                }
            });
        }
        [Test]
        public void RemoveWorksCorrectly()
        {
            aquarium.Add(fish);
            aquarium.RemoveFish("Joro");
            Assert.AreEqual(aquarium.Count, 0);
        }
        [Test]
        public void CheckRemoveThrowsException()
        {
            aquarium.Add(fish);
            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.RemoveFish("Ivancho");
            });
        }
        [Test]
        public void CheckSellFishThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.SellFish("Gogo");
            });
        }
        [Test]
        public void SellFishWorks()
        {
            aquarium.Add(fish);
            aquarium.SellFish("Joro");
            Assert.AreEqual(fish.Available, false);
        }
        [Test]
        public void SellFishWorks2()
        {
            aquarium.Add(fish);
            var soldFish = aquarium.SellFish("Joro");
            Assert.AreEqual(soldFish, fish);
        }
        [Test]
        public void FishReport()
        {
            aquarium.Add(fish);
            var report = aquarium.Report();
            Assert.AreEqual(report, $"Fish available at {aquarium.Name}: {fish.Name}");

        }
    }
}
