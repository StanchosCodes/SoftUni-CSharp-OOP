namespace DatabaseExtended.Tests
{
    using System;
    using NUnit.Framework;
    using ExtendedDatabase;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Database testdb;

        [SetUp]
        public void SetUp()
        {
            this.testdb = new Database();
        }

        [Test]
        public void ShouldHaveLengthOf16()
        {
            for (int i = 0; i < 16; i++)
            {
                Person personToAdd = new Person(i, $"{i}");
                this.testdb.Add(personToAdd);
            }

            Person overflowPerson = new Person(98, "Stancho");

            Assert.Throws<InvalidOperationException>(() =>
           {
               this.testdb.Add(overflowPerson);
           }, "Array's capacity must be exactly 16 integers!");
        }

        [Test]
        public void ShouldThrowIfRangeIsBiggerThan16()
        {
            Person[] people = new Person[19];
            for (int i = 0; i < 19; i++)
            {
                Person currPerson = new Person(i, $"{i}");
                people[i] = currPerson;
            }

            Assert.Throws<ArgumentException>(() =>
            {
                new Database(people);
            }, "Provided data length should be in range [0..16]!");
        }

        [Test]
        public void AddShouldAddToTheArray()
        {
            Person newPerson = new Person(98, "Stancho");

            this.testdb.Add(newPerson);

            Assert.That(this.testdb.Count, Is.EqualTo(1));
        }

        [Test]
        public void AddShouldThrowIfUserNameExists()
        {
            Person firstPerson = new Person(98, "Stancho");
            Person secondPerson = new Person(123, "Stancho");

            this.testdb.Add(firstPerson);

            Assert.Throws<InvalidOperationException>(() =>
           {
               this.testdb.Add(secondPerson);
           }, "There is already user with this username!");
        }

        [Test]
        public void AddShouldThrowIfUserIdExists()
        {
            Person firstPerson = new Person(98, "Stancho");
            Person secondPerson = new Person(98, "Pesho");

            this.testdb.Add(firstPerson);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.testdb.Add(secondPerson);
            }, "There is already user with this Id!");
        }

        [Test]
        public void CannotRemoveFromEmptyArray()
        {
            Assert.Throws<InvalidOperationException>(() =>
           {
               this.testdb.Remove();
           });
        }

        [Test]
        public void ShouldRemoveTheLastPerson()
        {
            Person firstPerson = new Person(98, "Stancho");
            // Person secondPerson = new Person(123, "Pesho");

            this.testdb.Add(firstPerson);
            // this.testdb.Add(secondPerson);
            this.testdb.Remove();

            // Database[] actualArr = new Database[] { this.testdb };
            // Database[] expectedArr = new Database[] { new Database( new Person (98, "Stancho")) };

            // CollectionAssert.AreEqual(actualArr, expectedArr);

            Assert.AreEqual(this.testdb.Count, 0);
        }

        [Test]
        public void FindShouldThrowIfUserDoesntExist()
        {
            Person firstPerson = new Person(98, "Stancho");
            this.testdb.Add(firstPerson);

            Assert.Throws<InvalidOperationException>(() =>
           {
               this.testdb.FindByUsername("Sashka");
           }, "No user is present by this username!");
        }

        [Test]
        public void FindShouldThrowIfUserIsNull()
        {
            Person firstPerson = new Person(98, "Stancho");
            this.testdb.Add(firstPerson);

            Assert.Throws<ArgumentNullException>(() =>
            {
                this.testdb.FindByUsername(null);
            }, "Username parameter is null!");
        }

        [Test]
        public void FindShouldThrowIfUserIsLowerCase()
        {
            Person firstPerson = new Person(98, "Stancho");
            this.testdb.Add(firstPerson);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.testdb.FindByUsername("stancho");
            });
        }

        [Test]
        public void FindShouldThrowIfIdDoesntExist()
        {
            Person firstPerson = new Person(98, "Stancho");
            this.testdb.Add(firstPerson);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.testdb.FindById(123);
            }, "No user is present by this Id!");
        }

        [Test]
        public void FindShouldThrowIfIdIsNegative()
        {
            Person firstPerson = new Person(98, "Stancho");
            this.testdb.Add(firstPerson);

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                this.testdb.FindById(-123);
            }, "Id should be a positive number!");
        }

        [Test]
        public void FindShouldReturnUser()
        {
            Person firstPerson = new Person(98, "Stancho");
            this.testdb.Add(firstPerson);

            Person result = this.testdb.FindByUsername("Stancho");

            Assert.AreEqual((result.UserName, result.Id), (firstPerson.UserName, firstPerson.Id));
        }

        [Test]
        public void FindShouldReturnUserWithThatId()
        {
            Person firstPerson = new Person(98, "Stancho");
            this.testdb.Add(firstPerson);

            Person result = this.testdb.FindById(98);

            Assert.AreEqual((result.UserName, result.Id), (firstPerson.UserName, firstPerson.Id));
        }
    }
}