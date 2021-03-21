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
        private const double negativeFuelConsumption = -2.0;
        private const double zeroFuelConsumption = 0;
        private const double fuelCapacity = 50.0;
        private const double negativeFuelCapacity = -2.0;
        private const double zeroFuelCapacity = 0;
        private const double negativeFuelToRefuel = -3.0;
        private const double zeroFuelToRefuel = 0;
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
            Assert.That(ex.Message, Is.EqualTo("Make cannot be null or empty!"));
        }
        [Test]
        public void Property_Model_Setting_Correct_Value()
        {

            var ex = Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(make, string.Empty, fuelConsumption, fuelCapacity);
            });
            Assert.That(ex.Message, Is.EqualTo("Model cannot be null or empty!"));
        }
        [Test]
        public void Property_FuelConsumption_Setting_Correct_Value()
        {

            var ex = Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(make, model, negativeFuelConsumption, fuelCapacity);
                Car car2 = new Car(make, model, zeroFuelConsumption, fuelCapacity);
            });
            Assert.That(ex.Message, Is.EqualTo("Fuel consumption cannot be zero or negative!"));
        }
        [Test]
        public void Property_FuelCapacity_Setting_Correct_Value()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(make, model, fuelConsumption, negativeFuelCapacity);
                Car car2 = new Car(make, model, fuelConsumption, zeroFuelCapacity);
            });
            Assert.That(ex.Message, Is.EqualTo("Fuel capacity cannot be zero or negative!"));
        }
        [Test]
        public void Refuel_Throws_Exception_If_Refuel_Fuel_Is_Negative_Or_Zero()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(negativeFuelToRefuel);
                Car car2 = new Car(make, model, fuelConsumption, fuelCapacity);
                car2.Refuel(zeroFuelToRefuel);
            });
            Assert.That(ex.Message, Is.EqualTo("Fuel amount cannot be zero or negative!"));
        }
        [Test]
        public void Drive_Throws_Exception_For_Not_Sufficient_Fuel_To_Drive()
        {
            var ex = Assert.Throws<InvalidOperationException>(() =>
            {
                car.Drive(distance);
            });
            Assert.That(ex.Message, Is.EqualTo("You don't have enough fuel to drive!"));
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