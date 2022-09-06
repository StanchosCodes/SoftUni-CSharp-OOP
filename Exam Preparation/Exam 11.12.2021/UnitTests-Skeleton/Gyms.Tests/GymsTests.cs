namespace Gyms.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class GymsTests
    {
        private Athlete testAthlete;
        private Gym testGym;

        [SetUp]
        public void SetUp()
        {
            this.testAthlete = new Athlete("Pesho");
            this.testGym = new Gym("Biceps", 2);
        }

        [Test]
        public void NameShouldSetValueProperly()
        {
            Gym newGym = new Gym("Leg Day", 2);

            string actualName = newGym.Name;
            string expectedName = "Leg Day";

            Assert.AreEqual(actualName, expectedName);
        }

        [TestCase(null)]
        [TestCase("")]
        public void NameShouldThrowIfIsNullOrEmpty(string name)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Gym newGym = new Gym(name, 2);
            }, "Invalid gym name.");
        }

        [Test]
        public void CapacityShouldSetProperValue()
        {
            Gym newGym = new Gym("Peshos", 2);

            int actualCapacity = newGym.Capacity;
            int expectedCapacity = 2;

            Assert.AreEqual(actualCapacity, expectedCapacity);
        }

        [Test]
        public void CapacityShouldThrowIfCapacityBelowZero()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Gym newGym = new Gym("Peshos", -1);
            }, "Invalid gym capacity.");
        }

        [Test]
        public void CountShouldReturnZeroIfEmptyCollection()
        {
            int actualCount = this.testGym.Count;

            Assert.AreEqual(actualCount, 0);
        }

        [Test]
        public void CountShouldReturnCorrectValue()
        {
            this.testGym.AddAthlete(this.testAthlete);

            int actualCount = this.testGym.Count;

            Assert.AreEqual(actualCount, 1);
        }

        [Test]
        public void AddAthleteShouldAddProperlyToTheCollection()
        {
            Athlete newAthete = new Athlete("Gosho");

            this.testGym.AddAthlete(this.testAthlete);
            this.testGym.AddAthlete(newAthete);

            int actualCount = this.testGym.Count;

            Assert.AreEqual(actualCount, 2);
        }

        [Test]
        public void AddAthleteShouldThrowIfCapacityReached()
        {
            Athlete newAthete = new Athlete("Gosho");
            Athlete newAthete2 = new Athlete("Hosho");

            this.testGym.AddAthlete(this.testAthlete);
            this.testGym.AddAthlete(newAthete);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.testGym.AddAthlete(newAthete2);
            }, "The gym is full.");
        }

        [Test]
        public void RemoveAthleteShouldRemoveProperlyFromTheCollection()
        {
            this.testGym.AddAthlete(this.testAthlete);
            this.testGym.RemoveAthlete(this.testAthlete.FullName);

            int actualCount = this.testGym.Count;

            Assert.AreEqual(actualCount, 0);
        }

        [Test]
        public void RemoveAthleteShouldThrowIfAthleteDoesntExist()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.testGym.RemoveAthlete(this.testAthlete.FullName);
            }, $"The athlete {this.testAthlete.FullName} doesn't exist.");
        }

        [Test]
        public void InjuredAthleteShouldSetInjuredPropertyOfAtleteToTrue()
        {
            this.testGym.AddAthlete(this.testAthlete);

            this.testGym.InjureAthlete(this.testAthlete.FullName);

            Assert.IsTrue(this.testAthlete.IsInjured);
        }

        [Test]
        public void InjuredAthleteShouldReturnTheInjuredAthlete()
        {
            this.testGym.AddAthlete(this.testAthlete);
            
            Athlete actualAthlete = this.testGym.InjureAthlete(this.testAthlete.FullName);

            string actualName = actualAthlete.FullName;
            string expectedName = this.testAthlete.FullName;

            Assert.AreEqual(actualName, expectedName);
        }

        [Test]
        public void InjuredAthletShouldThrowIfAthleteDoesntExistInTheCollection()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.testGym.InjureAthlete(this.testAthlete.FullName);
            }, $"The athlete {this.testAthlete.FullName} doesn't exist.");
        }

        [Test]
        public void ReportShouldReturnTheNamesOfTheNoneInjuredAthletes()
        {
            Athlete newAthlete = new Athlete("Gosho");

            this.testGym.AddAthlete(this.testAthlete);
            this.testGym.AddAthlete(newAthlete);

            string actualReport = this.testGym.Report();
            string expectedReport = $"Active athletes at {this.testGym.Name}: Pesho, Gosho";

            Assert.AreEqual(actualReport, expectedReport);
        }

        [Test]
        public void ReportShouldReturnNoNamesIfCollectionIsEmpty()
        {
            string actualReport = this.testGym.Report();
            string expectedReport = $"Active athletes at {this.testGym.Name}: ";
        }
    }
}
