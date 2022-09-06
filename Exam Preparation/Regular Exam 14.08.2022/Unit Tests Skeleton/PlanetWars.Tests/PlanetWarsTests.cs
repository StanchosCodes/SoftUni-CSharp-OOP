using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            private Planet testPlanet;
            private Weapon testWeapon;

            [SetUp]
            public void SetUp()
            {
                this.testPlanet = new Planet("Pesho", 100);
                this.testWeapon = new Weapon("PeshoWeapon", 20, 10);
            }

            [Test]
            public void WeaponNameShouldSetProperly()
            {
                Assert.AreEqual(this.testWeapon.Name, "PeshoWeapon");
            }

            [Test]
            public void WeaponPriceShouldSetProperly()
            {
                Assert.AreEqual(this.testWeapon.Price, 20);
            }

            [Test]
            public void WeaponPriceShouldThrowIfPriceBelowZero()
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Weapon newWeapon = new Weapon("new", -1, 10);
                }, "Price cannot be negative.");
            }

            [Test]
            public void DestructionLevelShouldSetProperly()
            {
                Assert.AreEqual(this.testWeapon.DestructionLevel, 10);
            }

            [Test]
            public void IncreaseDestructionLevelShouldIncreaseByOne()
            {
                this.testWeapon.IncreaseDestructionLevel();

                Assert.AreEqual(this.testWeapon.DestructionLevel, 11);
            }

            [TestCase(10)]
            [TestCase(11)]
            public void IsNuclearShouldReturnTrueIfDestructionLevelIsBiggerOrEqualToTen(int destructionLevel)
            {
                Weapon newWeapon = new Weapon("test", 10, destructionLevel);

                Assert.IsTrue(newWeapon.IsNuclear);
            }

            [Test]
            public void IsNuclearShouldReturnFalseIfDestructionLevelIsBelowTen()
            {
                Weapon newWeapon = new Weapon("test", 10, 9);

                Assert.IsFalse(newWeapon.IsNuclear);
            }

            [Test]
            public void PlanetNameShouldSetProperly()
            {
                Assert.AreEqual(this.testPlanet.Name, "Pesho");
            }

            [TestCase(null)]
            [TestCase("")]
            public void PlanetNameShouldThrowIfNullOtWhiteEmpty(string name)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Planet newPlanet = new Planet(name, 20);
                }, "Invalid planet Name");
            }

            [Test]
            public void PlanetBudgetShouldSetProperly()
            {
                Assert.AreEqual(this.testPlanet.Budget, 100);
            }

            [Test]
            public void PlanetBudgetShouldThrowIfBelowZero()
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Planet newPlanet = new Planet("Gosho", -10);
                }, "Budget cannot drop below Zero!");
            }

            [Test]
            public void ConstructorShouldInitializeEmptyCollection()
            {
                List <Weapon> newList = new List<Weapon>();

                CollectionAssert.AreEqual(this.testPlanet.Weapons, newList);
            }

            [Test]
            public void MiliraryRatioShouldReturnSumOfAllWeaponsDestructionLevel()
            {
                Weapon newWeapon = new Weapon("Gosho", 20, 10);

                this.testPlanet.AddWeapon(this.testWeapon);
                this.testPlanet.AddWeapon(newWeapon);

                double power = this.testPlanet.MilitaryPowerRatio;
                double expected = 20;

                Assert.AreEqual(power, expected);
            }

            [Test]
            public void ProfitShouldAddAmount()
            {
                this.testPlanet.Profit(20);

                Assert.AreEqual(this.testPlanet.Budget, 120);
            }

            [Test]
            public void SpendFundShouldDecreaseBudget()
            {
                this.testPlanet.SpendFunds(20);

                Assert.AreEqual(this.testPlanet.Budget, 80);
            }

            [Test]
            public void SpendFundsShouldThrowIfNotEnoughBudget()
            {
                Assert.Throws<InvalidOperationException>(() =>
                {
                    this.testPlanet.SpendFunds(110);
                }, "Not enough funds to finalize the deal.");
            }

            [Test]
            public void AddWeaponShouldThrowIfWeaponAlreadyAdded()
            {
                this.testPlanet.AddWeapon(this.testWeapon);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    this.testPlanet.AddWeapon(this.testWeapon);
                }, $"There is already a {this.testWeapon.Name} weapon.");
            }

            [Test]
            public void AddWeaponShouldAddCorrectly()
            {
                this.testPlanet.AddWeapon(this.testWeapon);

                int actualCount = this.testPlanet.Weapons.Count;
                int expectedCount = 1;

                Assert.AreEqual(actualCount, expectedCount);
            }

            [Test]
            public void RemoveWeaponShouldRemoveProperlyIfExists()
            {
                this.testPlanet.AddWeapon(this.testWeapon);
                this.testPlanet.RemoveWeapon(this.testWeapon.Name);

                int actualCount = this.testPlanet.Weapons.Count;
                int expectedCount = 0;

                Assert.AreEqual(actualCount, expectedCount);
            }

            [Test]
            public void RemoveWeaponShouldDoNothingIfWeaponDoesntExist()
            {
                this.testPlanet.AddWeapon(this.testWeapon);
                this.testPlanet.RemoveWeapon("Shotgun");

                int actualCount = this.testPlanet.Weapons.Count;
                int expectedCount = 1;

                Assert.AreEqual(actualCount, expectedCount);
            }

            [Test]
            public void UpgradeWeaponShouldThrowIfWeaponDoesntExist()
            {
                Assert.Throws<InvalidOperationException>(() =>
                {
                    this.testPlanet.UpgradeWeapon(this.testWeapon.Name);
                }, $"{this.testWeapon.Name} does not exist in the weapon repository of {this.testPlanet.Name}");
            }

            [Test]
            public void UpgradeWeaponShouldIncreseDestructionLevelIfWeaponExists()
            {
                this.testPlanet.AddWeapon(this.testWeapon);
                this.testPlanet.UpgradeWeapon(this.testWeapon.Name);

                double actualDestructionLevel = this.testPlanet.MilitaryPowerRatio;
                double expectedDestructionLevel = 11;

                Assert.AreEqual(actualDestructionLevel, expectedDestructionLevel);
            }

            [Test]
            public void DestructOpponentShouldThrowIfTheOpponentIsWithHigherMilitaryPowerRatio()
            {
                Planet opponent = new Planet("Test", 200);
                Weapon strongerWeapon = new Weapon("Stronger", 100, 20);

                opponent.AddWeapon(strongerWeapon);
                this.testPlanet.AddWeapon(this.testWeapon);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    this.testPlanet.DestructOpponent(opponent);
                }, $"{opponent.Name} is too strong to declare war to!");
            }

            [Test]
            public void DestructShouldReturnAMessageIfDestructionSuccesfull()
            {
                Planet opponent = new Planet("Test", 200);
                Weapon strongerWeapon = new Weapon("Stronger", 100, 20);

                opponent.AddWeapon(strongerWeapon);
                this.testPlanet.AddWeapon(this.testWeapon);

                string actualMessage = opponent.DestructOpponent(this.testPlanet);
                string expectedMessage = $"{this.testPlanet.Name} is destructed!";

                Assert.AreEqual(actualMessage, expectedMessage);
            }
        }
    }
}
