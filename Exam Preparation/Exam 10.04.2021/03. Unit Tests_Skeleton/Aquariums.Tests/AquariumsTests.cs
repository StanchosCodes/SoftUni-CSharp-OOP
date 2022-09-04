namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class AquariumsTests
    {
        private Fish testFish;
        private Aquarium testAquarium;

        [SetUp]
        public void SetUp()
        {
            this.testFish = new Fish("Pesho");
            this.testAquarium = new Aquarium("Peshos", 2);
        }

        [Test]
        public void ConstructorShouldSetProperly()
        {
            Aquarium testAquarium = new Aquarium("Goshos", 5);

            Assert.AreEqual(testAquarium.Name, "Goshos");
            Assert.AreEqual(testAquarium.Capacity, 5);
        }

        [TestCase(null)]
        [TestCase("")]
        public void NameShouldThrowIfNullOrEmpty(string name)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Aquarium testAquarium = new Aquarium(name, 5);
            }, "Invalid aquarium name!");
        }

        [Test]
        public void CapacityShouldThrowIfBelowZero()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Aquarium testAquarium = new Aquarium("Goshos", -1);
            }, "Invalid aquarium capacity!");
        }

        [Test]
        public void CapacityShouldReturnCorrectCapacity()
        {
            Assert.AreEqual(this.testAquarium.Capacity, 2);
        }

        [Test]
        public void CountShouldReturnCorrectCount()
        {
            this.testAquarium.Add(this.testFish);

            Assert.AreEqual(this.testAquarium.Count, 1);
        }

        [Test]
        public void FishShouldBeAvailableByDefault()
        {
            this.testAquarium.Add(this.testFish);

            Assert.IsTrue(this.testFish.Available);
        }

        [Test]
        public void AddShouldThrowIfCapacityReached()
        {
            Fish testFish2 = new Fish("Gosho");
            Fish testFish3 = new Fish("Goshoo");

            this.testAquarium.Add(this.testFish);
            this.testAquarium.Add(testFish2);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.testAquarium.Add(testFish3);
            }, "Aquarium is full!");
        }

        [Test]
        public void AddShouldAddProperly()
        {
            this.testAquarium.Add(this.testFish);

            Assert.AreEqual(this.testAquarium.Count, 1);
        }

        [Test]
        public void RemoveShouldThrowIfFishDoesntExist()
        {

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.testAquarium.RemoveFish(this.testFish.Name);
            }, $"Fish with the name {this.testFish.Name} doesn't exist!");
        }

        [Test]
        public void RemoveShouldRemoveProperly()
        {
            Fish testFish2 = new Fish("Gosho");

            this.testAquarium.Add(this.testFish);
            this.testAquarium.Add(testFish2);

            this.testAquarium.RemoveFish(testFish2.Name);

            Assert.AreEqual(this.testAquarium.Count, 1);
        }

        [Test]
        public void RemoveShouldRemoveTheFishAndDecreaseCount()
        {
            this.testAquarium.Add(this.testFish);
            this.testAquarium.RemoveFish(this.testFish.Name);

            Assert.AreEqual(this.testAquarium.Count, 0);
        }

        [Test]
        public void SellShouldThrowIfFishDoesntExist()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.testAquarium.SellFish(this.testFish.Name);
            }, $"Fish with the name {this.testFish.Name} doesn't exist!");
        }

        [Test]
        public void SellShouldSetAvailabilityToFalseIfSuccesfullySold()
        {
            this.testAquarium.Add(this.testFish);

            this.testAquarium.SellFish(this.testFish.Name);

            Assert.IsFalse(this.testFish.Available);
        }

        [Test]
        public void SellShouldReturnFishIfSold()
        {
            this.testAquarium.Add(this.testFish);

            string fishName = this.testAquarium.SellFish(this.testFish.Name).Name;

            Assert.AreEqual(fishName, "Pesho");
        }

        [Test]
        public void ReportShouldReturnAllAvailableFishsInTheAquarium()
        {
            Fish testFish2 = new Fish("Gosho");

            this.testAquarium.Add(this.testFish);
            this.testAquarium.Add(testFish2);

            string actualReport = this.testAquarium.Report();
            string expectedReport = $"Fish available at {this.testAquarium.Name}: Pesho, Gosho";
        }

        [Test]
        public void ReportShouldReturnCorrectStringWithEmptyAquarium()
        {
            string actualReport = this.testAquarium.Report();
            string expectedReport = $"Fish available at {this.testAquarium.Name}: ";

            Assert.AreEqual(actualReport, expectedReport);
        }
    }
}
