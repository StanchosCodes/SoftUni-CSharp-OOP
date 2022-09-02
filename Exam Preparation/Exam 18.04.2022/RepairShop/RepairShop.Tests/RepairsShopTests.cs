using NUnit.Framework;
using System;

namespace RepairShop.Tests
{
    public class Tests
    {
        [TestFixture]
        public class RepairsShopTests
        {
            private Car testCar;
            private Garage testGarage;

            [SetUp]
            public void SetUp()
            {
                this.testCar = new Car("Alfa", 5);
                this.testGarage = new Garage("Peshos", 2);
            }

            [Test]
            public void ConstructorShouldSetProperValues()
            {
                Garage newGarage = new Garage("Goshos", 5);

                string actualName = newGarage.Name;
                int actualMechanics = newGarage.MechanicsAvailable;

                string expectedName = "Goshos";
                int expectedMechanics = 5;

                Assert.AreEqual(actualName, expectedName);
                Assert.AreEqual(actualMechanics, expectedMechanics);
            }

            [TestCase("")]
            [TestCase(null)]
            public void NameShouldThrowExceptionIfNullOrWhiteSpace(string name)
            {
                Assert.Throws<ArgumentNullException>(() =>
                {
                    Garage newGarage = new Garage(name, 5);
                }, "Invalid garage name.");
            }

            [TestCase(0)]
            [TestCase(-1)]
            public void MechanicsShouldThrowIfBelowOrZero(int count)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Garage newGarage = new Garage("Goshos", count);
                }, "At least one mechanic must work in the garage.");
            }

            [Test]
            public void CarsInGarageShouldReturnActualCountOfTheCars()
            {
                Car testCar2 = new Car("Baraka", 10);

                this.testGarage.AddCar(this.testCar);
                this.testGarage.AddCar(testCar2);

                int actualCount = this.testGarage.CarsInGarage;
                int expectedCount = 2;

                Assert.AreEqual(actualCount, expectedCount);
            }

            [Test]
            public void AddCarShouldThrowIfCountOfTheCarsEqualsOrBelowCountOfMechanics()
            {
                Car testCar2 = new Car("Baraka", 10);
                Car testCar3 = new Car("Baraka2", 15);

                this.testGarage.AddCar(this.testCar);
                this.testGarage.AddCar(testCar2);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    this.testGarage.AddCar(testCar3);
                }, "No mechanic available.");
            }

            [Test]
            public void AddCarShouldAddCarCorrectlyOfAvailableMechanics()
            {
                this.testGarage.AddCar(this.testCar);

                int actualCount = this.testGarage.CarsInGarage;
                int expectedCount = 1;

                Assert.AreEqual(actualCount, expectedCount);
            }

            [Test]
            public void FixCarShouldThrowIfTheCarDoesntExist()
            {
                Assert.Throws<InvalidOperationException>(() =>
                {
                    this.testGarage.FixCar(this.testCar.CarModel);
                }, $"The car {this.testCar.CarModel} doesn't exist.");
            }

            [Test]
            public void FixCarShouldReturnTheFixedCarWithNoIssues()
            {
                this.testGarage.AddCar(this.testCar);

                this.testGarage.FixCar(this.testCar.CarModel);

                int actualNumberOfIssues = this.testCar.NumberOfIssues;
                int expectedNumbersOfIssues = 0;


                Assert.AreEqual(actualNumberOfIssues, expectedNumbersOfIssues);
            }

            [Test]
            public void RemoveFixedCarsShouldThrowIfNoFixedCarsInTheGarage()
            {
                Assert.Throws<InvalidOperationException>(() =>
                {
                    this.testGarage.RemoveFixedCar();
                }, "No fixed cars available.");
            }

            [Test]
            public void RemoveFixedCarsShouldRemoveAllFixedCarsFromTheGarage()
            {
                Car testCar2 = new Car("Baraka", 10);

                this.testGarage.AddCar(this.testCar);
                this.testGarage.AddCar(testCar2);

                this.testGarage.FixCar(this.testCar.CarModel);
                this.testGarage.FixCar(testCar2.CarModel);

                this.testGarage.RemoveFixedCar();

                int actualCount = this.testGarage.CarsInGarage;
                int expectedCount = 0;

                Assert.AreEqual(actualCount, expectedCount);
            }

            [Test]
            public void ReportShouldReturnAllCarsNamesWhichAreNotFixed()
            {
                Car testCar2 = new Car("Baraka", 10);

                this.testGarage.AddCar(this.testCar);
                this.testGarage.AddCar(testCar2);

                string actualReport = this.testGarage.Report();
                string expectedReport = "There are 2 which are not fixed: Alfa, Baraka.";

                Assert.AreEqual(actualReport, expectedReport);
            }
        }
    }
}