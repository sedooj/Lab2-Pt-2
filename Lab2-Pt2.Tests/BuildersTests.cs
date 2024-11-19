using System;
using Lab2_Pt2.books;
using Lab2_Pt2.publisher;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lab2_Pt2.Tests
{
    [TestClass]
    public class BuilderTests
    {
        [TestMethod]
        public void PublisherBuilder_Build_ValidData()
        {
            var publisherBuilder = new PublisherBuilder();
            var publisher = publisherBuilder.SetName("Test Publisher").Build();

            Assert.AreEqual("Test Publisher", publisher.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PublisherBuilder_Build_InvalidData_ThrowsException()
        {
            var publisherBuilder = new PublisherBuilder();
            publisherBuilder.SetName("").Build();
        }

        [TestMethod]
        public void BookBuilder_Build_ValidData()
        {
            var publisher = new Publisher("Valid Publisher");
            var bookBuilder = new BookBuilder();
            var book = bookBuilder
                .SetEditionId(123)
                .SetTitle("Test Book")
                .SetReleaseDate("2023-10-10")
                .SetPublisher(publisher)
                .SetGenre("Test Genre")
                .Build();

            Assert.AreEqual(123, book.EditionID);
            Assert.AreEqual("Test Book", book.Title);
            Assert.AreEqual("2023-10-10", book.ReleaseDate);
            Assert.AreEqual("Valid Publisher", book.Publisher.Name);
            Assert.AreEqual("Test Genre", book.Genre);
        }

        [TestMethod]
        public void BookBuilder_Build_InvalidData_ResetsAndRetries()
        {
            var publisher = new Publisher("Valid Publisher");
            var bookBuilder = new BookBuilder();

            var book = bookBuilder
                .SetEditionId(-1) // Invalid data
                .SetTitle("")     // Invalid data
                .SetReleaseDate("invalid-date") // Invalid data
                .SetPublisher(publisher)
                .SetGenre("") // Invalid data
                .Build();

            Assert.AreNotEqual(-1, book.EditionID);
            Assert.AreNotEqual("", book.Title);
            Assert.AreNotEqual("invalid-date", book.ReleaseDate);
            Assert.AreNotEqual("", book.Genre);
        }

        [TestMethod]
        public void MagazineBuilder_Build_ValidData()
        {
            var publisher = new Publisher("Valid Publisher");
            var magazineBuilder = new MagazineBuilder();
            var magazine = magazineBuilder
                .SetEditionId(321)
                .SetTitle("Test Magazine")
                .SetReleaseDate("2023-11-01")
                .SetPublisher(publisher)
                .SetHeadline("Test Headline")
                .Build();

            Assert.AreEqual(321, magazine.EditionID);
            Assert.AreEqual("Test Magazine", magazine.Title);
            Assert.AreEqual("2023-11-01", magazine.ReleaseDate);
            Assert.AreEqual("Valid Publisher", magazine.Publisher.Name);
            Assert.AreEqual("Test Headline", magazine.Headline);
        }

        [TestMethod]
        public void MagazineBuilder_Build_InvalidData_ResetsAndRetries()
        {
            var publisher = new Publisher("Valid Publisher");
            var magazineBuilder = new MagazineBuilder();

            var magazine = magazineBuilder
                .SetEditionId(0) // Invalid data
                .SetTitle("")    // Invalid data
                .SetReleaseDate("invalid-date") // Invalid data
                .SetPublisher(publisher)
                .SetHeadline("") // Invalid data
                .Build();

            Assert.AreNotEqual(0, magazine.EditionID);
            Assert.AreNotEqual("", magazine.Title);
            Assert.AreNotEqual("invalid-date", magazine.ReleaseDate);
            Assert.AreNotEqual("", magazine.Headline);
        }

        [TestMethod]
        public void TextBookBuilder_Build_ValidData()
        {
            var publisher = new Publisher("Valid Publisher");
            var textbookBuilder = new TextBookBuilder();
            var textbook = textbookBuilder
                .SetEditionId(987)
                .SetTitle("Test TextBook")
                .SetReleaseDate("2023-12-31")
                .SetPublisher(publisher)
                .SetSubject("Test Subject")
                .Build();

            Assert.AreEqual(987, textbook.EditionID);
            Assert.AreEqual("Test TextBook", textbook.Title);
            Assert.AreEqual("2023-12-31", textbook.ReleaseDate);
            Assert.AreEqual("Valid Publisher", textbook.Publisher.Name);
            Assert.AreEqual("Test Subject", textbook.Subject);
        }

        [TestMethod]
        public void TextBookBuilder_Build_InvalidData_ResetsAndRetries()
        {
            var publisher = new Publisher("Valid Publisher");
            var textbookBuilder = new TextBookBuilder();

            var textbook = textbookBuilder
                .SetEditionId(-123) // Invalid data
                .SetTitle("")       // Invalid data
                .SetReleaseDate("invalid-date") // Invalid data
                .SetPublisher(publisher)
                .SetSubject("")     // Invalid data
                .Build();

            Assert.AreNotEqual(-123, textbook.EditionID);
            Assert.AreNotEqual("", textbook.Title);
            Assert.AreNotEqual("invalid-date", textbook.ReleaseDate);
            Assert.AreNotEqual("", textbook.Subject);
        }
    }
}