namespace INStock.Tests
{
    using NUnit.Framework;
    using System;
    using Contracts;
    using Models;
    using System.Collections.Generic;

    [TestFixture]
    public class ProductStockTests
    {
        private IProduct defProduct;
        private IProductStock defProductStock;

        [SetUp]
        public void SetUp()
        {
            this.defProduct = new Product("banana", 1.90m, 5);
            this.defProductStock = new ProductStock();
        }

        [Test]
        public void IndexerShouldReturnCorrectProductAtTheGivenIndex()
        {
            this.defProductStock.Add(this.defProduct);

            IProduct actualProduct = this.defProductStock[0];

            Assert.AreEqual(actualProduct.Label, this.defProduct.Label);
        }

        [Test]
        public void AddShouldAddTheProductToTheCollection()
        {
            this.defProductStock.Add(this.defProduct);

            int actualCount = this.defProductStock.Count;
            int expectedCount = 1;

            Assert.AreEqual(actualCount, expectedCount);
        }

        [Test]
        public void ContainsShouldReturnTrueWhenProductExists()
        {
            this.defProductStock.Add(this.defProduct);

            Assert.IsTrue(this.defProductStock.Contains(this.defProduct));
        }

        [Test]
        public void ContainsShouldReturnFalseWhenProductExists()
        {
            Assert.IsFalse(this.defProductStock.Contains(this.defProduct));
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public void FindByIndexShouldReturnCorrectProductIfExists(int index)
        {
            IProduct product2 = new Product("Orange", 2.50m, 2);
            IProduct product3 = new Product("Pineapple", 2.90m, 1);

            this.defProductStock.Add(this.defProduct);
            this.defProductStock.Add(product2);
            this.defProductStock.Add(product3);

            IProduct currProduct = this.defProductStock.Find(index);

            Assert.IsNotNull(currProduct);
        }

        [TestCase(2)]
        [TestCase(3)]
        public void FindByIndexShouldThrowExceptionIfIndexIsOutOfTheRangeOfTheCollection(int index)
        {
            IProduct product2 = new Product("Orange", 2.50m, 2);

            this.defProductStock.Add(this.defProduct);
            this.defProductStock.Add(product2);

            Assert.Throws<IndexOutOfRangeException>(() =>
           {
               this.defProductStock.Find(index);
           });
        }

        [Test]
        public void FindByPriceShouldReturnAllTheProductsWithTheGivenPrice()
        {
            IProduct mango = new Product("Mango", 1.50m, 2);
            IProduct plum = new Product("Plum", 1.50m, 5);
            IProduct apple = new Product("Apple", 1.50m, 4);

            this.defProductStock.Add(mango);
            this.defProductStock.Add(plum);
            this.defProductStock.Add(apple);

            IEnumerable<IProduct> productsByPrice = new List<IProduct>();

            productsByPrice = this.defProductStock.FindAllByPrice(1.50);

            List<IProduct> expectedProducts = new List<IProduct> { mango, plum, apple };

            CollectionAssert.AreEqual(productsByPrice, expectedProducts);
        }

        [Test]
        public void FindByPriceShouldReturnAnEmptyCollectionIfNoneOfTheProductsRespondToTheGivenPrice()
        {
            IEnumerable<IProduct> productsByPrice = new List<IProduct>();

            productsByPrice = this.defProductStock.FindAllByPrice(1.50);

            List<IProduct> expectedProducts = new List<IProduct>();

            CollectionAssert.AreEqual(productsByPrice, expectedProducts);
        }

        [Test]
        public void FindByQuantityShouldReturnAllTheProductsWithTheGivenQuantity()
        {
            IProduct mango = new Product("Mango", 2.90m, 4);
            IProduct plum = new Product("Plum", 1.20m, 4);
            IProduct apple = new Product("Apple", 1.10m, 4);

            this.defProductStock.Add(mango);
            this.defProductStock.Add(plum);
            this.defProductStock.Add(apple);

            IEnumerable<IProduct> productsByPrice = new List<IProduct>();

            productsByPrice = this.defProductStock.FindAllByQuantity(4);

            List<IProduct> expectedProducts = new List<IProduct> { mango, plum, apple };

            CollectionAssert.AreEqual(productsByPrice, expectedProducts);
        }

        [Test]
        public void FindByQuantityShouldReturnAnEmptyCollectionIfNoneOfTheProductsRespondToTheGivenQuantity()
        {
            IEnumerable<IProduct> productsByPrice = new List<IProduct>();

            productsByPrice = this.defProductStock.FindAllByQuantity(4);

            List<IProduct> expectedProducts = new List<IProduct>();

            CollectionAssert.AreEqual(productsByPrice, expectedProducts);
        }

        [Test]
        public void FindAllInRangeShouldReturnAllProductsInTheGivenPriceRangeInclusivlyInDescendingOrder()
        {
            IProduct mango = new Product("Mango", 2.90m, 4);
            IProduct plum = new Product("Plum", 1.20m, 4);
            IProduct apple = new Product("Apple", 1.10m, 4);

            this.defProductStock.Add(apple);
            this.defProductStock.Add(mango);
            this.defProductStock.Add(plum);

            IEnumerable<IProduct> productsByPriceRange = new List<IProduct>();

            productsByPriceRange = this.defProductStock.FindAllInRange(1.10, 2.90);

            List<IProduct> expectedProducts = new List<IProduct> { mango, plum, apple };

            CollectionAssert.AreEqual(productsByPriceRange, expectedProducts);
        }

        [Test]
        public void FindAllInRangeShouldReturnAnEmptyCollectionIfNoneOfTheProductsRespondToTheGivenRange()
        {
            IEnumerable<IProduct> productsByPriceRange = new List<IProduct>();

            productsByPriceRange = this.defProductStock.FindAllInRange(1.10 , 2.90);

            List<IProduct> expectedProducts = new List<IProduct>();

            CollectionAssert.AreEqual(productsByPriceRange, expectedProducts);
        }

        [Test]
        public void FindByLabelShouldReturnTheProductWithTheGivenLabel()
        {
            this.defProductStock.Add(this.defProduct);

            IProduct actualProduct = this.defProductStock.FindByLabel("banana");

            Assert.AreEqual(actualProduct, this.defProduct);
        }

        [Test]
        public void FindByLabelShouldThrowExceptionIfTheLabelDoesntExist()
        {
            Assert.Throws<ArgumentException>(() =>
           {
               this.defProductStock.FindByLabel("apple");
           });
        }

        [Test]
        public void FindMostExpensiveProductShouldReturnTheProductWithTheHighestPrice()
        {
            IProduct mango = new Product("Mango", 2.90m, 4);
            IProduct plum = new Product("Plum", 1.20m, 4);
            IProduct apple = new Product("Apple", 1.10m, 4);

            this.defProductStock.Add(apple);
            this.defProductStock.Add(mango);
            this.defProductStock.Add(plum);

            IProduct expensiveProduct = this.defProductStock.FindMostExpensiveProduct();

            IProduct expectedProduct = mango;

            Assert.AreEqual(expensiveProduct, expectedProduct);
        }

        [Test]
        public void RemoveShouldReturnTrueWhenAProductIsRemovedSuccessfully()
        {
            this.defProductStock.Add(this.defProduct);

            bool isRemoved = this.defProductStock.Remove(this.defProduct);

            Assert.IsTrue(isRemoved);
        }

        [Test]
        public void RemoveShouldReturnFalseWhenAProductIsNotRemovedSuccessfully()
        {
            IProduct mango = new Product("Mango", 2.90m, 4);
            this.defProductStock.Add(mango);

            bool isRemoved = this.defProductStock.Remove(this.defProduct);

            Assert.IsFalse(isRemoved);
        }
    }
}
