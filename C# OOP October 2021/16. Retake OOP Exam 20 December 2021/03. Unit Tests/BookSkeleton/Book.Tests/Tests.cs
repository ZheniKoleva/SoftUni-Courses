namespace Book.Tests
{
    using System;

    using NUnit.Framework;

    public class Tests
    {        
        [TestCase(null)]
        [TestCase("")]        
        public void ConstructorShoulThrowExceptionForInvalidBookName(string name)
        {
            Assert.Throws<ArgumentException>(() => new Book(name, "Stephen King"));            
        }

        [TestCase(null)]
        [TestCase("")]        
        public void ConstructorShoulThrowExceptionForInvalidAuthorName(string name)
        {
            Assert.Throws<ArgumentException>(() => new Book("It", name));
        }

        [Test]
        public void ConstructorShouldInitializeBook()
        {
            Book book = new Book("It", "Stephen King");

            Assert.IsNotNull(book);            
        }

        [Test]
        public void ConstructorShouldReturnCorrectBookProperties()
        {
            Book book = new Book("It", "Stephen King");
            
            Assert.AreEqual("It", book.BookName);
            Assert.AreEqual("Stephen King", book.Author);
            Assert.AreEqual(0, book.FootnoteCount);
        }

        [Test]
        public void AddFootnoteShouldAddNotesCorrectly()
        {
            Book book = new Book("It", "Stephen King");
            book.AddFootnote(1, "alabala");

            Assert.AreEqual(1, book.FootnoteCount);
        }

        [Test]
        public void AddFootnoteShouldThrowsExceptionForExistingNote()
        {
            Book book = new Book("It", "Stephen King");
            book.AddFootnote(1, "alabala");

            Assert.Throws<InvalidOperationException>(() => book.AddFootnote(1, "alabala"),
                "Footnote already exists!");
        }

        [Test]
        public void FindFootnoteShouldThrowsExceptionForUnexistingNote()
        {
            Book book = new Book("It", "Stephen King");            

            Assert.Throws<InvalidOperationException>(() => book.FindFootnote(1),
                "Footnote doesn't exists!");
        }

        [Test]
        public void AddFootnoteShouldReturnNote()
        {
            Book book = new Book("It", "Stephen King");
            book.AddFootnote(1, "alabala");

            string actual = book.FindFootnote(1);
            string expected = $"Footnote #1: alabala";

            Assert.AreEqual(expected, actual); 
        }

        [Test]
        public void AlterFootnoteShouldThrowsExceptionForUnexistingNote()
        {
            Book book = new Book("It", "Stephen King");

            Assert.Throws<InvalidOperationException>(() => book.AlterFootnote(1, "my new text"),
                "Footnote doesn't exists!");
        }

        [Test]
        public void AlterFootnoteShouldChangeNoteContent()
        {
            Book book = new Book("It", "Stephen King");
            book.AddFootnote(1, "my first note");
            book.AddFootnote(2, "my second note");

            book.AlterFootnote(2, "my changed second note");

            string expected = $"Footnote #2: my changed second note";
            string actual = book.FindFootnote(2);

            Assert.AreEqual(expected, actual);
        }
    }

}