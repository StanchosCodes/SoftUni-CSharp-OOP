namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class ArenaTests
    {
        private Arena testArena;

        [SetUp]
        public void SetUp()
        {
            this.testArena = new Arena();
        }

        [Test]
        public void ConstructorShouldInitializeIReadOnlyCollectionWarrior()
        {
            // Checking if the constructor is encapsulated properly

            string actualType = typeof(Arena)
                .GetProperties()
                .First(pr => pr.Name == "Warriors")
                .PropertyType
                .Name;

            string expectedType = typeof(IReadOnlyCollection<Warrior>).Name;

            Assert.AreEqual(actualType, expectedType);
        }

        [Test]
        public void ConstructorShouldInitializeEmptyCollection()
        {
            List<Warrior> actualCollection = this.testArena.Warriors.ToList();
            List<Warrior> expectedCollection = new List<Warrior>();

            CollectionAssert.AreEqual(actualCollection, expectedCollection);
        }

        [Test]
        public void CountShouldReturnZeroIfCollectionIsEmpty()
        {
            int actualCount = this.testArena.Count;
            int expectedCount = 0;

            Assert.AreEqual(actualCount, expectedCount);
        }

        [Test]
        public void CountShouldReturnTheCorrectCountOfTheCollection()
        {
            Warrior testWarrior = new Warrior("Pesho", 60, 50);
            this.testArena.Enroll(testWarrior);

            int actualCount = this.testArena.Count;
            int expectedCount = 1;

            Assert.AreEqual(actualCount, expectedCount);
        }

        [Test]
        public void EnrollShouldThrowExceptionIfWarriorExists()
        {
            Warrior testWarrior = new Warrior("Pesho", 60, 50);
            this.testArena.Enroll(testWarrior);

            Assert.Throws<InvalidOperationException>(() =>
           {
               this.testArena.Enroll(testWarrior);
           }, "Warrior is already enrolled for the fights!");
        }

        [Test]
        public void FightShouldThrowExceptionIfAttackerIsNotEnrolled()
        {
            Warrior testWarrior = new Warrior("Pesho", 60, 50);
            Warrior testWarrior2 = new Warrior("Gosho", 50, 40);

            this.testArena.Enroll(testWarrior);

            Assert.Throws<InvalidOperationException>(() =>
           {
               this.testArena.Fight(testWarrior.Name, testWarrior2.Name);
           }, $"There is no fighter with name {testWarrior2.Name} enrolled for the fights!");
        }

        [Test]
        public void FightShouldThrowExceptionIfDeffenderIsNotEnrolled()
        {
            Warrior testWarrior = new Warrior("Pesho", 60, 50);
            Warrior testWarrior2 = new Warrior("Gosho", 50, 40);

            this.testArena.Enroll(testWarrior2);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.testArena.Fight(testWarrior.Name, testWarrior2.Name);
            }, $"There is no fighter with name {testWarrior.Name} enrolled for the fights!");
        }

        [Test]
        public void FightShouldInvokeAttackOfTheFirstGivenWarriorAsArgumentIfBothWarriorsAreEnrolled()
        {
            Warrior testWarrior = new Warrior("Pesho", 60, 50);
            Warrior testWarrior2 = new Warrior("Gosho", 50, 40);

            this.testArena.Enroll(testWarrior);
            this.testArena.Enroll(testWarrior2);

            this.testArena.Fight(testWarrior.Name, testWarrior2.Name);

            int actualTestWarrior2Hp = testWarrior2.HP;
            int expectedTestWarrior2Hp = 0;

            Assert.AreEqual(actualTestWarrior2Hp, expectedTestWarrior2Hp);
        }
    }
}
