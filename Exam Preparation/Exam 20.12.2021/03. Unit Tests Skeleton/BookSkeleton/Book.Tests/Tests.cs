namespace Book.Tests
{
    using System;

    using NUnit.Framework;

    [TestFixture]
    public class Tests
    {
        private Book testBook;

        [SetUp]
        public void SetUp()
        {
            this.testBook = new Book("Harry Potter", "JK Rolling");
        }

        [Test]
        public void ContructorShouldSetProperly()
        {
            string actualBookName = this.testBook.BookName;
            string actualAuthor = this.testBook.Author;

            Assert.AreEqual(actualBookName, "Harry Potter");
            Assert.AreEqual(actualAuthor, "JK Rolling");
        }
        [Test]
        public void FootNoteCountShouldReturnActualCount()
        {
            int actualCount = this.testBook.FootnoteCount;

            Assert.AreEqual(actualCount, 0);
        }

        [TestCase(null)]
        [TestCase("")]
        public void NameShouldThrowIfNullOrEmpty(string name)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Book newBook = new Book(name, "Stancho");
            }, $"Invalid {nameof(this.testBook.BookName)}!");
        }

        [TestCase(null)]
        [TestCase("")]
        public void AuthorShouldThrowIfNullOrEmpty(string author)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Book newBook = new Book("StanchosBook", author);
            }, $"Invalid {nameof(this.testBook.Author)}!");
        }

        [Test]
        public void AddFootNoteShouldThrowIfNoteExists()
        {
            this.testBook.AddFootnote(1, "Hey");

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.testBook.AddFootnote(1, "Hi");
            }, "Footnote already exists!");
        }

        [Test]
        public void AddFootNoteShouldAddProperly()
        {
            this.testBook.AddFootnote(1, "Hey");

            string actualNote = this.testBook.FindFootnote(1);

            Assert.AreEqual(actualNote, "Footnote #1: Hey");
        }

        [Test]
        public void FindFootNoteShouldThrowIfDoesntExist()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.testBook.FindFootnote(1);
            }, "Footnote doesn't exists!");
        }

        [Test]
        public void AlterFootNoteShouldThrowIfNoteDoesntExist()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.testBook.AlterFootnote(1, "New Text");
            }, "Footnote does not exists!");
        }

        [Test]
        public void AlterFootNoteShouldSetNewTextCorectly()
        {
            this.testBook.AddFootnote(1, "Hi");
            this.testBook.AlterFootnote(1, "New Text");

            string actualText = this.testBook.FindFootnote(1);

            Assert.AreEqual(actualText, "Footnote #1: New Text");
        }
    }
}