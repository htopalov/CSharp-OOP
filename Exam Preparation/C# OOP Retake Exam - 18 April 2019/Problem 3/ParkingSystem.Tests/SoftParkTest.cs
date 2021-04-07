namespace ParkingSystem.Tests
{
    using NUnit.Framework;
    using System;

    public class SoftParkTest
    {
        private Car car;
        private SoftPark parking;
        [SetUp]
        public void Setup()
        {
            this.car = new Car("Make", "ST1949RV");
            this.parking = new SoftPark();
        }

        [Test]
        public void CheckIfParkCarThrowsExceptionWhenSpotDoesntExist()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                parking.ParkCar("p1", car);
            });
        }
        [Test]
        public void CheckIfParkCarThrowsExceptionWhenSpotTaken()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                parking.ParkCar("A1", car);
                parking.ParkCar("A1", car);
            });
        }
        [Test]
        public void CheckIfParkCarThrowsExceptionWhenCarAlreadyParked()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                parking.ParkCar("A1", car);
                parking.ParkCar("A2", car);
            });
        }
        [Test]
        public void CheckIfParkCarWorksCorrectly()
        {
            parking.ParkCar("A1", car);
            Assert.AreEqual(parking.Parking["A1"], car);
        }
        [Test]
        public void CheckIfParkCarReturnsResult()
        {
            parking.ParkCar("A1", car);
            Assert.AreEqual("Car:ST1949RV parked successfully!", $"Car:{car.RegistrationNumber} parked successfully!");
        }
        [Test]
        public void CheckIfRemoveCarThrowsExceptionWhenSpotDoesntExist()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                parking.RemoveCar("x1", car);
            });
        }
        [Test]
        public void CheckIfRemoveCarThrowsExceptionWhenCarInSpotDoesntExist()
        {
            parking.ParkCar("A1", new Car("Subaru", "SA1234SO"));
            Assert.Throws<ArgumentException>(() =>
            {
                parking.RemoveCar("A1", car);
            });
        }
        [Test]
        public void CheckIfRemoveCarWorksCorrectly()
        {
            parking.ParkCar("A1", car);
            parking.RemoveCar("A1", car);
            Assert.IsNull(parking.Parking["A1"]);
        }
        [Test]
        public void CheckIfRemoveCarReturnsResultCorrectly()
        {
            parking.ParkCar("A1", car);
            parking.RemoveCar("A1", car);
            Assert.AreEqual("Remove car:ST1949RV successfully!", $"Remove car:{car.RegistrationNumber} successfully!");
        }
    }
}