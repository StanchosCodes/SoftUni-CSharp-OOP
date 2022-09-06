namespace Robots.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class RobotsTests
    {
        private Robot testRobot;
        private RobotManager testManager;

        [SetUp]
        public void SetUp()
        {
            this.testRobot = new Robot("Pesho", 100);
            this.testManager = new RobotManager(2);
        }

        [Test]
        public void CapacityShouldSetProperly()
        {
            RobotManager newManager = new RobotManager(3);

            int actualCapacity = newManager.Capacity;

            Assert.AreEqual(actualCapacity, 3);
        }

        [Test]
        public void CapacityShouldThrowIfCapacityBelowZero()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                RobotManager newManager = new RobotManager(-1);
            }, "Invalid capacity!");
        }

        [Test]
        public void CountShouldReturnCorrectly()
        {
            this.testManager.Add(this.testRobot);

            int actualCount = this.testManager.Count;

            Assert.AreEqual(actualCount, 1);
        }

        [Test]
        public void CountShouldReturnZeroIfCollectionIsEmpty()
        {
            int actualCount = this.testManager.Count;

            Assert.AreEqual(actualCount, 0);
        }

        [Test]
        public void AddShouldAddProperly()
        {
            Robot newRobot = new Robot("Gosho", 60);

            this.testManager.Add(this.testRobot);
            this.testManager.Add(newRobot);

            int actualCount = this.testManager.Count;

            Assert.AreEqual(actualCount, 2);
        }

        [Test]
        public void AddShouldThrowIfRobotAlreadyExists()
        {
            this.testManager.Add(this.testRobot);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.testManager.Add(this.testRobot);
            }, $"There is already a robot with name {this.testRobot.Name}!");
        }

        [Test]
        public void AddShouldThrowIfCapacityReached()
        {
            Robot newRobot = new Robot("Gosho", 60);
            Robot newRobot2 = new Robot("Hosho", 80);

            this.testManager.Add(this.testRobot);
            this.testManager.Add(newRobot);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.testManager.Add(newRobot2);
            }, "Not enough capacity!");
        }

        [Test]
        public void RemoveShouldRemoveProperly()
        {
            this.testManager.Add(this.testRobot);

            this.testManager.Remove(this.testRobot.Name);

            Assert.AreEqual(this.testManager.Count, 0);
        }

        [Test]
        public void RemoveShouldThrowIfRobotDoesntExist()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.testManager.Remove(this.testRobot.Name);
            }, $"Robot with the name {this.testRobot.Name} doesn't exist!");
        }

        [TestCase(20)]
        [TestCase(10)]
        public void WorkShouldDecreaseBatteryProperly(int batteryUsage)
        {
            this.testManager.Add(this.testRobot);
            int currBattery = this.testRobot.Battery;

            this.testManager.Work(this.testRobot.Name, "test", batteryUsage);

            int actualBatteryLeft = this.testRobot.Battery;
            int expectedBatteryLeft = currBattery - batteryUsage;

            Assert.AreEqual(actualBatteryLeft, expectedBatteryLeft);
        }

        [Test]
        public void WorkShouldThrowIfRobotDoesntExist()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.testManager.Work(this.testRobot.Name, "test", 20);
            }, $"Robot with the name {this.testRobot.Name} doesn't exist!");
        }

        [Test]
        public void WorkShouldThrowIfRobotDoesntHaveEnoughBattery()
        {
            this.testManager.Add(this.testRobot);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.testManager.Work(this.testRobot.Name, "test", 110);
            }, $"{this.testRobot.Name} doesn't have enough battery!");
        }

        [Test]
        public void ChargeShouldMaxOutTheRobotsBattery()
        {
            this.testManager.Add(this.testRobot);
            this.testManager.Work(this.testRobot.Name, "test", 60);

            this.testManager.Charge(this.testRobot.Name);

            int actualBattery = this.testRobot.Battery;
            int expectedBattery = 100;

            Assert.AreEqual(actualBattery, expectedBattery);
        }

        [Test]
        public void ChargeShouldThrowIfRobotDoesntExist()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.testManager.Charge(this.testRobot.Name);
            }, $"Robot with the name {this.testRobot.Name} doesn't exist!");
        }
    }
}
