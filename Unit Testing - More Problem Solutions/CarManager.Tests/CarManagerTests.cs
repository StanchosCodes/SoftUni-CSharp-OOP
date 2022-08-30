namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        private Car testCar;

        [SetUp]
        public void SetUp()
        {
            this.testCar = new Car("Alfa", "156", 6, 62);
        }

        [Test]
        public void ConstructorShouldConstructCorrectData()
        {
            string actualMake = this.testCar.Make;
            string actualModel = this.testCar.Model;
            double actualFuelConsumtion = this.testCar.FuelConsumption;
            double actualFuelCapacity = this.testCar.FuelCapacity;
            double actualFuelAmount = this.testCar.FuelAmount;

            string expectedMake = "Alfa";
            string expectedModel = "156";
            double expectedFuelConsumption = 6;
            double expectedFuelCapacity = 62;
            double expectedFuelAmount = 0;

            Assert.AreEqual(actualMake, expectedMake);
            Assert.AreEqual(actualModel, expectedModel);
            Assert.AreEqual(actualFuelConsumtion, expectedFuelConsumption);
            Assert.AreEqual(actualFuelCapacity, expectedFuelCapacity);
            Assert.AreEqual(actualFuelAmount, expectedFuelAmount);
        }

        [TestCase("", "156", 6, 62)]
        [TestCase(null, "156", 6, 62)]
        public void MakeCannotBeNullOrEmpty(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() =>
           {
               Car invalidCar = new Car(make, model, fuelConsumption, fuelCapacity);
           }, "Make cannot be null or empty!");
        }

        [Test]
        public void MakeShouldReturnCorrectData()
        {
            string actualMake = this.testCar.Make;
            string expectedMake = "Alfa";

            Assert.AreEqual(actualMake, expectedMake);
        }

        [TestCase("Alfa", "", 6, 62)]
        [TestCase("Alfa", null, 6, 62)]
        public void ModelCannotBeNullOrEmpty(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car invalidCar = new Car(make, model, fuelConsumption, fuelCapacity);
            }, "Model cannot be null or empty!");
        }

        [Test]
        public void ModelShouldReturnCorrectData()
        {
            string actualModel = this.testCar.Model;
            string expectedModel = "156";

            Assert.AreEqual(actualModel, expectedModel);
        }

        [TestCase("Alfa", "156", 0, 62)]
        [TestCase("Alfa", "156", -6, 62)]
        public void FuelConsumptionCannotBeZeroOrNegative(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car invalidCar = new Car(make, model, fuelConsumption, fuelCapacity);
            }, "Fuel consumption cannot be zero or negative!");
        }

        [Test]
        public void FuelConsumptionShouldReturnCorrectData()
        {
            double actualFConsumption = this.testCar.FuelConsumption;
            double expectedFConsumption = 6;

            Assert.AreEqual(actualFConsumption, expectedFConsumption);
        }

        [Test]
        public void FuelAmountShouldReturnCorrectData()
        {
            double actualFAmount = this.testCar.FuelAmount;
            double expectedFAmount = 0;

            Assert.AreEqual(actualFAmount, expectedFAmount);
        }

        [TestCase("Alfa", "156", 6, 0)]
        [TestCase("Alfa", "156", 6, -6)]
        public void FuelCapacityCannotBeZeroOrNegative(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car invalidCar = new Car(make, model, fuelConsumption, fuelCapacity);
            }, "Fuel capacity cannot be zero or negative!");
        }

        [Test]
        public void FuelCapacityShouldReturnCorrectData()
        {
            double actualFCapacity = this.testCar.FuelCapacity;
            double expectedFCapacity = 62;

            Assert.AreEqual(actualFCapacity, expectedFCapacity);
        }

        [TestCase(0)]
        [TestCase(-6)]
        public void RefuelAmountCannotBeZeroOrNegative(double amount)
        {
            Assert.Throws<ArgumentException>(() =>
           {
               this.testCar.Refuel(amount);
           });
        }

        [TestCase(62)]
        [TestCase(63)]
        public void RefuelAmountCannotExceedTheFuelCapacity(double amount)
        {

            this.testCar.Refuel(amount);

            double actualFuelAmount = this.testCar.FuelAmount;
            double expectedFuelAmount = 62;

            Assert.AreEqual(actualFuelAmount, expectedFuelAmount);
        }

        [Test]
        public void RefuelShouldReturnCorrectData()
        {
            this.testCar.Refuel(20);

            double actualFAmount = this.testCar.FuelAmount;
            double expectedFAmount = 20;

            Assert.AreEqual(actualFAmount, expectedFAmount);
        }

        [TestCase(600)]
        public void NeededFuelToDriveCannotBeMoreThenTheFuelAmount(double distance)
        {
            this.testCar.Refuel(30);

            Assert.Throws<InvalidOperationException>(() =>
           {
               this.testCar.Drive(distance);
           }, "You don't have enough fuel to drive!");
        }

        [Test]
        public void DriveShouldReturnCorrectData()
        {
            this.testCar.Refuel(30);
            this.testCar.Drive(500);

            double actualFAmount = this.testCar.FuelAmount;
            double expectedFAmount = 0;

            Assert.AreEqual(actualFAmount, expectedFAmount);
        }
    }
}