using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        private Smartphone testPhone;
        private Shop testShop;

        [SetUp]
        public void SetUp()
        {
            this.testPhone = new Smartphone("Nokia", 50);
            this.testShop = new Shop(2);
        }

        [Test]
        public void ContructorShouldSetProperly()
        {
            Shop newShop = new Shop(3);
            newShop.Add(this.testPhone);

            int actualCount = newShop.Count;
            int actualCapacity = newShop.Capacity;

            int expectedCount = 1;
            int expectedCapacity = 3;

            Assert.AreEqual(actualCount, expectedCount);
            Assert.AreEqual(actualCapacity, expectedCapacity);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(0)]
        public void CapacityShouldSetCorrectly(int capacity)
        {
            Shop newShop = new Shop(capacity);

            int actualCapacity = newShop.Capacity;
            int expectedCapacity = capacity;

            Assert.AreEqual(actualCapacity, expectedCapacity);
        }

        [TestCase(-1)]
        [TestCase(-20)]
        public void CapacityShouldThrowIfValueBelowZero(int capacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Shop newShop = new Shop(capacity);
            }, "Invalid capacity.");
        }

        [Test]
        public void CountShouldReturnCorrectCountOfTheShopCollection()
        {
            this.testShop.Add(this.testPhone);

            int actualCount = this.testShop.Count;
            int expectedCount = 1;

            Assert.AreEqual(actualCount, expectedCount);
        }

        [Test]
        public void CountShouldReturnZeroIfCollectionIsEmpty()
        {
            int actualCount = this.testShop.Count;
            int expectedCount = 0;

            Assert.AreEqual(actualCount, expectedCount);
        }

        [Test]
        public void AddShouldThrowIfPhoneAlreadyExists()
        {
            this.testShop.Add(this.testPhone);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.testShop.Add(this.testPhone);
            }, $"The phone model {this.testPhone.ModelName} already exist.");
        }

        [Test]
        public void AddShouldThrowIfCapacityReached()
        {
            Smartphone newSmartphone = new Smartphone("Sony", 60);
            Smartphone newSmartphone2 = new Smartphone("Samsung", 70);

            this.testShop.Add(this.testPhone);
            this.testShop.Add(newSmartphone);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.testShop.Add(newSmartphone2);
            }, "The shop is full.");
        }

        [Test]
        public void AddShouldAddProperly()
        {
            this.testShop.Add(this.testPhone);

            Assert.AreEqual(this.testShop.Count, 1);
        }

        [Test]
        public void RemoveShouldThrowIfPhoneDoesntExists()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.testShop.Remove(this.testPhone.ModelName);
            }, $"The phone model {this.testPhone.ModelName} doesn't exist.");
        }

        [Test]
        public void RemoveShouldRemoveProperly()
        {
            this.testShop.Add(this.testPhone);

            this.testShop.Remove(this.testPhone.ModelName);

            Assert.AreEqual(this.testShop.Count, 0);
        }

        [Test]
        public void TestPhoneShouldThrowIfPhoneDoesntExists()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.testShop.TestPhone(this.testPhone.ModelName, 20);
            }, $"The phone model {this.testPhone.ModelName} doesn't exist.");
        }

        [Test]
        public void TestPhoneShouldThrowIfPhonesBatteryIsLowerThenTheBatteryUsage()
        {
            this.testShop.Add(this.testPhone);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.testShop.TestPhone(this.testPhone.ModelName, 60);
            }, $"The phone model {this.testPhone.ModelName} is low on batery.");
        }

        [Test]
        public void TestPhoneShouldDecreaseTheBatteryOfThePhoneByTheBaterryUsage()
        {
            this.testShop.Add(this.testPhone);

            this.testShop.TestPhone(this.testPhone.ModelName, 20);

            int actualBattery = this.testPhone.CurrentBateryCharge;
            int expectedBattery = 30;

            Assert.AreEqual(actualBattery, expectedBattery);
        }

        [Test]
        public void ChargePhoneShouldThrowIfPhoneDoesntExists()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.testShop.ChargePhone(this.testPhone.ModelName);
            }, $"The phone model {this.testPhone.ModelName} doesn't exist.");
        }

        [Test]
        public void ChargePhoneShouldIncreasePhonesBatteryToItsMaximum()
        {
            this.testShop.Add(this.testPhone);
            this.testShop.TestPhone(this.testPhone.ModelName, 20);
            this.testShop.ChargePhone(this.testPhone.ModelName);

            int actualCharge = this.testPhone.CurrentBateryCharge;
            int expectedCharge = this.testPhone.MaximumBatteryCharge;

            Assert.AreEqual(actualCharge, expectedCharge);
        }
    }
}