using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void AxeShouldLoosDurabilityAfterEachAttack()
        {
            // Arrange
            Axe testAxe = new Axe(20, 10);
            Dummy testDummy = new Dummy(50, 100);

            // Act
            testAxe.Attack(testDummy);

            int actualDurability = testAxe.DurabilityPoints;
            int expectedDurability = 9;

            // Assert
            Assert.AreEqual(actualDurability, expectedDurability);
        }

        
        [Test]
        public void AxeShoudntAttackIfItIsBroken()
        {
            // Arrange
            Axe testAxe = new Axe(10, -5);
            Dummy testDummy = new Dummy(10, 20);

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                testAxe.Attack(testDummy);
            }, "Axe is broken.");
        }
    }
}