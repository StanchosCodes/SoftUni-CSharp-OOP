namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        private Database db;

        [SetUp]
        public void SetUp()
        {
            this.db = new Database();
        }

        [TestCase(new int[] { })]
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void ConstructorShoulAddUpTo16Integers(int[] elements)
        {
            // Arrange
            Database testDB = new Database(elements);

            // Act
            int[] actualResult = testDB.Fetch();
            int[] expectedResult = elements;

            int actualCount = testDB.Count;
            int expectedCount = elements.Length;

            // Assert
            CollectionAssert.AreEqual(actualResult, expectedResult, "Contructor should initialize field data correctly!");
            Assert.AreEqual(actualCount, expectedCount, "Contructor should set count with the elements length correctly");
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 })]
        public void ContructorShouldntAddMoreThen16Integers(int[] elements)
        {
            Assert.Throws<InvalidOperationException>(() =>
           {
               Database testDB = new Database(elements);
           }, "Array's capacity must be exactly 16 integers!");
        }

        [TestCase(new int[] { })]
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void AddShouldAddUpTo16Elements(int[] elements)
        {
            // Act
            foreach (int element in elements)
            {
                this.db.Add(element);
            }

            int[] actualResult = this.db.Fetch();
            int[] expectedResult = elements;

            int actualCount = this.db.Count;
            int expectedCount = elements.Length;

            // Assert
            CollectionAssert.AreEqual(actualResult, expectedResult, "Add should the elements to the field");
            Assert.AreEqual(actualCount, expectedCount, "Add should change the count field");
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void AddShouldThrowAnExceptionIfMoreThen16IntegersAreGiven(int[] elements)
        {
            for (int i = 1; i <= 16; i++)
            {
                this.db.Add(i);
            }
            Assert.Throws<InvalidOperationException>(() =>
           {
                   this.db.Add(17);
           }, "Array's capacity must be exactly 16 integers!");
        }

        [Test]
        public void RemoveShouldThrowExceptionWhenDatabaseIsEmpty()
        {
            Assert.Throws<InvalidOperationException>(() =>
           {
               this.db.Remove();
           }, "The collection is empty!");
        }

        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1 })]
        public void RemoveShouldRemoveTheLastElement(int[] elements)
        {
            foreach (int element in elements)
            {
                this.db.Add(element);
            }

            for (int i = 0; i < elements.Length; i++)
            {
                this.db.Remove();
            }

            int[] actualResult = this.db.Fetch();
            int[] expectedResult = new int[] { };

            int actualCount = this.db.Count;
            int expectedCount = 0;

            CollectionAssert.AreEqual(actualResult, expectedResult, "Remove should remove an element in the database!");
            Assert.AreEqual(actualCount, expectedCount, "Remove should change the count field!");
        }

        [Test]
        public void FetchShouldReturnACopyArray()
        {
            this.db.Add(1);

            int[] actualArray = this.db.Fetch();
            int[] expectedArray = new int[] { 1 };

            CollectionAssert.AreEqual(actualArray, expectedArray, "Fetch method should return a copy of the array in the database!");
        }
    }
}
