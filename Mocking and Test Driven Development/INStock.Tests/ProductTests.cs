namespace INStock.Tests
{
    using NUnit.Framework;
    using Contracts;
    using Models;

    [TestFixture]
    public class ProductTests
    {
        [Test]
        public void ConstructorShouldInitializeTheProductCorrect()
        {
            IProduct product2 = new Product("kiwi", 2.10m, 2);

            string actualName = product2.Label;
            decimal actualPrice = product2.Price;
            int actualQuantity = product2.Quantity;

            string expectedName = "kiwi";
            decimal expectedPrice = 2.10m;
            int expectedQuantity = 2;

            Assert.AreEqual(actualName, expectedName);
            Assert.AreEqual(actualPrice, expectedPrice);
            Assert.AreEqual(actualQuantity, expectedQuantity);
        }
    }
}