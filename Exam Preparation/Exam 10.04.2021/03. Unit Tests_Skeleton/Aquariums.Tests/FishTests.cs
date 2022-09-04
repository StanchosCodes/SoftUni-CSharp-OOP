using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aquariums.Tests
{
    [TestFixture]
    public class FishTests
    {
        [TestCase("Fish1")]
        [TestCase("Fish2")]
        [TestCase("Fish3")]
        [TestCase("Fish4")]
        public void ConstructorShouldSetCorrectValues(string name)
        {
            Fish newFish = new Fish(name);

            Assert.AreEqual(newFish.Name, name);
        }

        [Test]
        public void ConstructorShouldSetProperAvailability()
        {
            Fish newFish = new Fish("Nemo");

            Aquarium newAquarium = new Aquarium("Nemos", 2);

            newAquarium.Add(newFish);

            Assert.IsTrue(newFish.Available);
        }
    }
}
