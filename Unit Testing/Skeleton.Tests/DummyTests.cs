using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private Dummy testDummy;
        [SetUp]
        public void SetUp()
        {
            this.testDummy = new Dummy(10, 10);
        }

        [Test]
        public void DummyShouldLoseHealthWhenAttacked()
        {
            // Arrange
            Axe testAxe = new Axe(5, 10);

            // Act
            testAxe.Attack(this.testDummy);

            int actualHealth = this.testDummy.Health;
            int expectedHealth = 10 - 5; // dummy health - attack points -> 5

            // Assert
            Assert.AreEqual(actualHealth, expectedHealth);
        }

        [Test]
        public void DummyShouldntBeAttackedIfIsDead()
        {
            // Act
            this.testDummy.TakeAttack(10);

            // Assert
            Assert.Throws<InvalidOperationException>(() =>
           {
               this.testDummy.TakeAttack(10);
           }, "Dummy is dead.");
        }

        [Test]
        public void AliveDummyCantGiveExperience()
        {
            // Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.testDummy.GiveExperience();
            }, "Target is not dead.");
        }

        [Test]
        public void DeadDummyCanGiveExperience()
        {
            Dummy testDummy = new Dummy(0, 10);
            int actualXP = testDummy.GiveExperience();
            int expectedXP = 10;

            Assert.AreEqual(actualXP, expectedXP);
        }
    }
}