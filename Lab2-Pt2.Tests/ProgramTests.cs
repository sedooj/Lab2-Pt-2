using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab2_Pt2;
using Lab2_Pt2.books;
using Lab2_Pt2.publisher;

namespace Lab2_Pt2_Tests
{
    [TestClass]
    public class PublisherTests
    {
        [TestMethod]
        public void Publisher_ToString_ReturnsCorrectString()
        {
            var publisher = new Publisher("CoolBooks Publishing");
            var result = publisher.ToString();
            Assert.IsTrue(result.Contains("CoolBooks Publishing"));
        }
    }

    [TestClass]
    public class PersonTests
    {
        [TestMethod]
        public void Person_ToString_ReturnsCorrectString()
        {
            var person = new Person("John Doe", 30);
            var result = person.ToString();
            Assert.IsTrue(result.Contains("John Doe"));
            Assert.IsTrue(result.Contains("30"));
        }
    }

    [TestClass]
    public class AuthorTests
    {
        [TestMethod]
        public void Author_AddWork_AddsCorrectly()
        {
            var author = new Author("Fred Derf", 43);
            var publisher = new Publisher("CoolBooks Publishing");
            var book = new Book(751, "Life is live", "14:51 14-05-2024", publisher, "Fantasy");
            author.AddWork(book);
            CollectionAssert.Contains(author.Works, book);
        }

        [TestMethod]
        public void Author_ToString_ReturnsCorrectString()
        {
            var author = new Author("Fred Derf", 43);
            var result = author.ToString();
            Assert.IsTrue(result.Contains("Fred Derf"));
            Assert.IsTrue(result.Contains("43"));
        }
    }

    [TestClass]
    public class PrintEditionTests
    {
        [TestMethod]
        public void PrintEdition_AddAuthor_AddsCorrectly()
        {
            var publisher = new Publisher("CoolBooks Publishing");
            var author = new Author("Mr Freeman", 34);
            var book = new Book(751, "Life is live", "14:51 14-05-2024", publisher, "Fantasy");
            book.AddAuthor(author);
            CollectionAssert.Contains(book.Authors, author);
        }

        [TestMethod]
        public void PrintEdition_Equals_ReturnsTrueForSameEditionID()
        {
            var publisher = new Publisher("CoolBooks Publishing");
            var book1 = new Book(751, "Life is live", "14:51 14-05-2024", publisher, "Fantasy");
            var book2 = new Book(751, "Another book", "15-05-2024", publisher, "Mystery");
            Assert.IsTrue(book1.Equals(book2));
        }

        [TestMethod]
        public void PrintEdition_ToString_ReturnsCorrectString()
        {
            var publisher = new Publisher("CoolBooks Publishing");
            var author = new Author("Mr Freeman", 34);
            var book = new Book(751, "Life is live", "14:51 14-05-2024", publisher, "Fantasy");
            book.AddAuthor(author);
            var result = book.ToString();
            Assert.IsTrue(result.Contains("Life is live"));
            Assert.IsTrue(result.Contains("CoolBooks Publishing"));
            Assert.IsTrue(result.Contains("Mr Freeman"));
        }
    }

    [TestClass]
    public class BookTests
    {
        [TestMethod]
        public void Book_ToString_ReturnsCorrectString()
        {
            var publisher = new Publisher("CoolBooks Publishing");
            var book = new Book(751, "Life is live", "14:51 14-05-2024", publisher, "Fantasy");
            var result = book.ToString();
            Assert.IsTrue(result.Contains("Life is live"));
            Assert.IsTrue(result.Contains("Fantasy"));
        }
    }

    [TestClass]
    public class TextBookTests
    {
        [TestMethod]
        public void TextBook_ToString_ReturnsCorrectString()
        {
            var publisher = new Publisher("CoolBooks Publishing");
            var textbook = new TextBook(851244, "C# for dummies", "24-02-1999", publisher, "Programming");
            var result = textbook.ToString();
            Assert.IsTrue(result.Contains("C# for dummies"));
            Assert.IsTrue(result.Contains("Programming"));
        }
    }

    [TestClass]
    public class MagazineTests
    {
        [TestMethod]
        public void Magazine_ToString_ReturnsCorrectString()
        {
            var publisher = new Publisher("CoolBooks Publishing");
            var magazine = new Magazine(9152411293, "Save urself", "10-01-2020", publisher, "How to protect urself while covid");
            var result = magazine.ToString();
            Assert.IsTrue(result.Contains("Save urself"));
            Assert.IsTrue(result.Contains("How to protect urself while covid"));
        }
    }
}