using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab2_Pt2.model;

namespace Lab2_Pt2.Tests.model
{
    [TestClass]
    public class TextBookTests
    {
        [TestMethod]
        public void TextBookBuilder_WithValidData_CreatesTextBook()
        {
            var publisher = new Publisher.Builder()
                .WithName("Test Publisher")
                .Build();

            var author = new Author.Builder()
                .WithName("Author Name")
                .WithAge(45)
                .Build();

            var textBook = new TextBook.Builder()
                .WithEditionId(1)
                .WithTitle("TextBook Title")
                .WithReleaseDate("2024-11-01")
                .WithPublisher(publisher)
                .AddAuthor(author)
                .WithGenre("Education")
                .WithSubject("Mathematics")
                .Build();

            Assert.AreEqual(1, textBook.EditionId);
            Assert.AreEqual("TextBook Title", textBook.Title);
            Assert.AreEqual("2024-11-01", textBook.ReleaseDate);
            Assert.AreEqual(publisher, textBook.Publisher);
            CollectionAssert.AreEqual(new[] { author }, textBook.Authors);
            Assert.AreEqual("Education", textBook.Genre);
            Assert.AreEqual("Mathematics", textBook.Subject);
        }

        [TestMethod]
        public void TextBookBuilder_WithInvalidSubject_ThrowsException()
        {
            var builder = new TextBook.Builder();
            Assert.ThrowsException<ValidationNotBlankException>(() => builder.WithSubject(""));
        }

        [TestMethod]
        public void TextBookBuilder_WithInvalidTitle_ThrowsException()
        {
            var builder = new TextBook.Builder();
            Assert.ThrowsException<NullReferenceException>(() => builder.WithTitle(null));
        }

        [TestMethod]
        public void TextBookBuilder_CopyConstructor_CreatesCopy()
        {
            var publisher = new Publisher.Builder()
                .WithName("Test Publisher")
                .Build();

            var author = new Author.Builder()
                .WithName("Author Name")
                .WithAge(45)
                .Build();

            var originalTextBook = new TextBook.Builder()
                .WithEditionId(1)
                .WithTitle("TextBook Title")
                .WithReleaseDate("2024-11-01")
                .WithPublisher(publisher)
                .AddAuthor(author)
                .WithGenre("Education")
                .WithSubject("Mathematics")
                .Build();

            var copiedBuilder = new TextBook.Builder(originalTextBook);
            var copiedTextBook = copiedBuilder.Build();

            Assert.AreEqual(originalTextBook.EditionId, copiedTextBook.EditionId);
            Assert.AreEqual(originalTextBook.Title, copiedTextBook.Title);
            Assert.AreEqual(originalTextBook.ReleaseDate, copiedTextBook.ReleaseDate);
            Assert.AreEqual(originalTextBook.Publisher, copiedTextBook.Publisher);
            CollectionAssert.AreEqual(originalTextBook.Authors, copiedTextBook.Authors);
            Assert.AreEqual(originalTextBook.Genre, copiedTextBook.Genre);
            Assert.AreEqual(originalTextBook.Subject, copiedTextBook.Subject);
        }

        [TestMethod]
        public void TextBook_ToString_ReturnsExpectedFormat()
        {
            var publisher = new Publisher.Builder()
                .WithName("Test Publisher")
                .Build();

            var author = new Author.Builder()
                .WithName("Author Name")
                .WithAge(45)
                .Build();

            var textBook = new TextBook.Builder()
                .WithEditionId(1)
                .WithTitle("TextBook Title")
                .WithReleaseDate("2024-11-01")
                .WithPublisher(publisher)
                .AddAuthor(author)
                .WithGenre("Education")
                .WithSubject("Mathematics")
                .Build();

            var expectedResult =
                $"[Type: TextBook] EditionID: {textBook.EditionId}, Title: {textBook.Title}, Publisher: {textBook.Publisher.Name}, Release Date: {textBook.ReleaseDate}, Authors: {string.Join(", ", textBook.Authors.Select(a => a.Name))}, Genre: {textBook.Genre}, Subject: {textBook.Subject}";

            Assert.AreEqual(expectedResult, textBook.ToString());
        }
    }
}