using NUnit.Framework;
using CarManager;
using System;

namespace Tests
{
    public class CarTests
    {
        private Car car;
        private const string make = "Subaru";
        private const string model = "Impreza";
        private const double fuelConsumption = 10.0;
        private const double fuelCapacity = 50.0;
        private const double distance = 10000.0;

        [SetUp]
        public void Setup()
        {
            this.car = new Car(make, model, fuelConsumption, fuelCapacity);
        }

        [Test]
        public void Test_If_Constructors_Sets_Data_Correct()
        {
            Assert.That(car.FuelAmount, Is.EqualTo(0));
            Assert.That(make, Is.EqualTo(car.Make));
            Assert.That(model, Is.EqualTo(car.Model));
            Assert.That(fuelConsumption, Is.EqualTo(car.FuelConsumption));
            Assert.That(fuelCapacity, Is.EqualTo(car.FuelCapacity));
        }
        [Test]
        public void Property_Make_Setting_Correct_Value()
        {

            var ex = Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(string.Empty, model, fuelConsumption, fuelCapacity);
            });
        }
        [Test]
        public void Property_Model_Setting_Correct_Value()
        {

            var ex = Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(make, string.Empty, fuelConsumption, fuelCapacity);
            });
        }
        [TestCase(0)]
        [TestCase(-10)]
        public void Property_FuelConsumption_Setting_Correct_Value(double consumption)
        {

            var ex = Assert.Throws<ArgumentException>(() =>
            {
                var car = new Car(make, model, consumption, fuelCapacity);
            });
        }
        [TestCase(0)]
        [TestCase(-10)]
        public void Property_FuelCapacity_Setting_Correct_Value(double capacity)
        {
            var ex = Assert.Throws<ArgumentException>(() =>
            {
                var car = new Car(make, model, fuelConsumption, capacity);
            });
        }
        [TestCase(0)]
        [TestCase(-10)]
        public void Refuel_Throws_Exception_If_Refuel_Fuel_Is_Negative_Or_Zero(double fuel)
        {
            var ex = Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(fuel);;
            });
        }
        [Test]
        public void Drive_Throws_Exception_For_Not_Sufficient_Fuel_To_Drive()
        {
            var ex = Assert.Throws<InvalidOperationException>(() =>
            {
                car.Drive(distance);
            });
        }
        [Test]
        public void Test_If_Refuel_More_Than_Capacity()
        {
            this.car.Refuel(60);
            int expectedFuel = 50;
            Assert.AreEqual(expectedFuel, this.car.FuelAmount);
        }
        [Test]
        public void Test_If_Driving_Correctly()
        {
            this.car.Refuel(10);
            this.car.Drive(10);
            double expectedFuel = 9;

            Assert.AreEqual(expectedFuel, this.car.FuelAmount);
        }
    }
}