using FrontDeskApp;
using NUnit.Framework;
using System;

namespace BookigApp.Tests
{
    [TestFixture]
    public class Tests
    {
        private Hotel testHotel;
        private Room testRoom;

        [SetUp]
        public void Setup()
        {
            this.testHotel = new Hotel("Stancho", 3);
            this.testRoom = new Room(3, 20);
        }

        [TestCase(null)]
        [TestCase(" ")]
        public void FullNameShouldThrowIfNullOrWhiteSpace(string name)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Hotel newHotel = new Hotel(name, 4);
            });
        }

        [Test]
        public void FullnameShouldSetProperly()
        {
            Assert.AreEqual(this.testHotel.FullName, "Stancho");
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(6)]
        [TestCase(8)]
        public void CategoryShouldThrowIfBelow1OrAbove5(int category)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Hotel newHotel = new Hotel("Stanchoo", category);
            });
        }

        [Test]
        public void CategoryShouldSetProperly()
        {
            Assert.AreEqual(this.testHotel.Category, 3);
        }

        [Test]
        public void TurnOverShouldReturnZeroIfNoGuests()
        {
            Assert.AreEqual(this.testHotel.Turnover, 0);
        }

        [Test]
        public void AddShouldAddProperly()
        {
            this.testHotel.AddRoom(this.testRoom);

            Assert.AreEqual(this.testHotel.Rooms.Count, 1);
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void BookRoomShouldThrowIfAdultsBelowOrEqualToZero(int adults)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.testHotel.BookRoom(adults, 2, 2, 10);
            });
        }

        [TestCase(-1)]
        public void BookRoomShouldThrowIfChildrenBelowZero(int children)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.testHotel.BookRoom(1, children, 2, 10);
            });
        }

        [TestCase(-1)]
        [TestCase(0)]
        public void BookRoomShouldThrowIfDurationBelowOne(int duration)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.testHotel.BookRoom(1, 2, duration, 10);
            });
        }

        [Test]
        public void BookShouldDoNothingIfBedsNotEnough()
        {
            this.testHotel.AddRoom(this.testRoom);

            this.testHotel.BookRoom(2, 2, 3, 10);

            Assert.AreEqual(this.testHotel.Bookings.Count, 0);
        }

        [Test]
        public void BookShouldDoNothingIfBudgetNotEnough()
        {
            this.testHotel.AddRoom(this.testRoom);

            this.testHotel.BookRoom(1, 2, 4, 50);

            Assert.AreEqual(this.testHotel.Bookings.Count, 0);
        }

        [Test]
        public void BookShouldBookCorectly()
        {
            this.testHotel.AddRoom(this.testRoom);

            this.testHotel.BookRoom(1, 2, 2, 60);

            Assert.AreEqual(this.testHotel.Bookings.Count, 1);
        }

        [Test]
        public void TurnOverShouldIncreaseIfBookingsOccured()
        {
            this.testHotel.AddRoom(this.testRoom);
            this.testHotel.BookRoom(1, 2, 2, 60);

            Assert.AreEqual(this.testHotel.Turnover, 40);
        }
    }
}