using NUnit.Framework;
using System;
using System.Collections.Generic;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private Dictionary<string, UnitDriver> drivers;
        private UnitCar car;
        private UnitDriver driver;
        private RaceEntry entry;
        [SetUp]
        public void Setup()
        {
            this.drivers = new Dictionary<string, UnitDriver>();
            this.car = new UnitCar("Model", 150, 1500.0);
            this.driver = new UnitDriver("Driver", car);
            this.entry = new RaceEntry();
        }

        [Test]
        public void CheckIfConstructorWorksCorrectly()
        {
            Assert.IsNotNull(drivers);
            Assert.IsNotNull(car);
            Assert.IsNotNull(driver);
        }
        [Test]
        public void AddDriverWorksCorrectly()
        {
            entry.AddDriver(driver);
            Assert.That(entry.Counter, Is.EqualTo(1));
        }
        [Test]
        public void CheckIfAddDriverThrowsInvalidOperationException()
        {
            UnitDriver driver = null;
            RaceEntry entry = new RaceEntry();
            Assert.Throws<InvalidOperationException>(() =>
            {
                entry.AddDriver(driver);
            });
        }
        [Test]
        public void CheckIfAddDriverThrowsExceptionWhenAddingSameDriver()
        {
            var driver = new UnitDriver("Ivan", car);
            var driver2 = new UnitDriver("Ivan", car);
            Assert.Throws<InvalidOperationException>(() =>
            {
                entry.AddDriver(driver);
                entry.AddDriver(driver2);
            });
        }
        [Test]
        public void TestIfResultOfAddDriverIsCorrect()
        {
            var driver = new UnitDriver("Ivan", car);
            string result = entry.AddDriver(driver);
            Assert.AreEqual(result, "Driver Ivan added in race.");
        }
        [Test]
        public void CheckIfCalculateAvgHorsePowerWorksCorrectly()
        {
            var car1 = new UnitCar("Model1", 150, 1500.0);
            var car2 = new UnitCar("Model2", 130, 1500.0);
            var car3 = new UnitCar("Model3", 110, 1500.0);
            var car4 = new UnitCar("Model4", 190, 1500.0);
            var driver1 = new UnitDriver("Ivan1", car1);
            var driver2 = new UnitDriver("Ivan2", car2);
            var driver3 = new UnitDriver("Ivan3", car3);
            var driver4 = new UnitDriver("Ivan4", car4);
            entry.AddDriver(driver1);
            entry.AddDriver(driver2);
            entry.AddDriver(driver3);
            entry.AddDriver(driver4);
            int expectedResult = (car1.HorsePower + car2.HorsePower + car3.HorsePower + car4.HorsePower) / 4;
            Assert.AreEqual(entry.CalculateAverageHorsePower(), expectedResult);
        }
        [Test]
        public void CheckIfCalculateAvgHorsePowerThrowsException()
        {
            var car1 = new UnitCar("Model1", 150, 1500.0);
            var driver1 = new UnitDriver("Ivan1", car1);
            entry.AddDriver(driver1);
            Assert.Throws<InvalidOperationException>(() =>
            {
                entry.CalculateAverageHorsePower();
            });
        }
    }
}