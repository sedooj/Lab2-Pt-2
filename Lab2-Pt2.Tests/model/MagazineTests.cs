using System.Collections.Generic;
using System.Linq;
using Lab2_Pt2.model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lab2_Pt2.Tests.model
{
    [TestClass]
    public class MagazineTests
    {
        [TestMethod]
        public void MagazineBuilder_WithValidData_CreatesMagazine()
        {
            var publisher = new Publisher.Builder()
                .WithName("Test Publisher")
                .Build();

            var author = new Author.Builder()
                .WithName("TestName")
                .WithAge(40)
                .Build();

            var magazine = new Magazine.Builder()
                .WithEditionId(202)
                .WithTitle("Tech Monthly")
                .WithReleaseDate("2024-02-01")
                .WithPublisher(publisher)
                .AddAuthor(author)
                .WithGenre("Technology")
                .WithHeadline("Top Innovations of the Year")
                .Build();

            Assert.AreEqual(202, magazine.EditionId);
            Assert.AreEqual("Tech Monthly", magazine.Title);
            Assert.AreEqual("2024-02-01", magazine.ReleaseDate);
            Assert.AreEqual(publisher, magazine.Publisher);
            CollectionAssert.AreEqual(new List<Author> { author }, magazine.Authors);
            Assert.AreEqual("Technology", magazine.Genre);
            Assert.AreEqual("Top Innovations of the Year", magazine.Headline);
        }

        [TestMethod]
        public void MagazineBuilder_WithInvalidEditionId_ThrowsValidationException()
        {
            var builder = new Magazine.Builder();
            Assert.ThrowsException<ValidationNotCourseInException<long>>(() => builder.WithEditionId(0));
        }

        [TestMethod]
        public void MagazineBuilder_WithInvalidTitle_ThrowsValidationException()
        {
            var builder = new Magazine.Builder();
            Assert.ThrowsException<ValidationNotBlankException>(() => builder.WithTitle(""));
        }

        [TestMethod]
        public void MagazineBuilder_WithInvalidReleaseDate_ThrowsValidationException()
        {
            var builder = new Magazine.Builder();
            Assert.ThrowsException<ValidationNotBlankException>(() => builder.WithReleaseDate(""));
        }

        [TestMethod]
        public void MagazineBuilder_WithInvalidPublisher_ThrowsValidationException()
        {
            var builder = new Magazine.Builder();
            Assert.ThrowsException<ValidationNullException>(() => builder.WithPublisher(null));
        }

        [TestMethod]
        public void MagazineBuilder_WithInvalidAuthor_ThrowsValidationException()
        {
            var builder = new Magazine.Builder();
            Assert.ThrowsException<ValidationNullException>(() => builder.AddAuthor(null));
        }

        [TestMethod]
        public void MagazineBuilder_WithInvalidGenre_ThrowsValidationException()
        {
            var builder = new Magazine.Builder();
            Assert.ThrowsException<ValidationNotBlankException>(() => builder.WithGenre(""));
        }

        [TestMethod]
        public void MagazineBuilder_WithInvalidHeadline_ThrowsValidationException()
        {
            var builder = new Magazine.Builder();
            Assert.ThrowsException<ValidationNotBlankException>(() => builder.WithHeadline(""));
        }

        [TestMethod]
        public void MagazineBuilder_CopyConstructor_CreatesCopy()
        {
            var publisher = new Publisher.Builder()
                .WithName("Test Publisher")
                .Build();

            var author = new Author.Builder()
                .WithName("Jane Doe")
                .WithAge(40)
                .Build();

            var originalMagazine = new Magazine.Builder()
                .WithEditionId(202)
                .WithTitle("Tech Monthly")
                .WithReleaseDate("2024-02-01")
                .WithPublisher(publisher)
                .AddAuthor(author)
                .WithGenre("Technology")
                .WithHeadline("Top Innovations of the Year")
                .Build();

            var copiedBuilder = new Magazine.Builder(originalMagazine);
            var copiedMagazine = copiedBuilder.Build();

            Assert.AreEqual(originalMagazine.EditionId, copiedMagazine.EditionId);
            Assert.AreEqual(originalMagazine.Title, copiedMagazine.Title);
            Assert.AreEqual(originalMagazine.ReleaseDate, copiedMagazine.ReleaseDate);
            Assert.AreEqual(originalMagazine.Publisher, copiedMagazine.Publisher);
            CollectionAssert.AreEqual(originalMagazine.Authors, copiedMagazine.Authors);
            Assert.AreEqual(originalMagazine.Genre, copiedMagazine.Genre);
            Assert.AreEqual(originalMagazine.Headline, copiedMagazine.Headline);
        }

        [TestMethod]
        public void Magazine_ToString_ReturnsExpectedFormat()
        {
            var publisher = new Publisher.Builder()
                .WithName("Test Publisher")
                .Build();

            var author = new Author.Builder()
                .WithName("Jane Doe")
                .WithAge(40)
                .Build();

            var magazine = new Magazine.Builder()
                .WithEditionId(202)
                .WithTitle("Tech Monthly")
                .WithReleaseDate("2024-02-01")
                .WithPublisher(publisher)
                .AddAuthor(author)
                .WithGenre("Technology")
                .WithHeadline("Top Innovations of the Year")
                .Build();

            var expectedResult =
                $"[Type: Magazine] EditionID: {magazine.EditionId}, Title: {magazine.Title}, Publisher: {magazine.Publisher.Name}, Release Date: {magazine.ReleaseDate}, Authors: {string.Join(", ", magazine.Authors.Select(a => a.Name))}, Genre: {magazine.Genre}, Headline: {magazine.Headline}";

            Assert.AreEqual(expectedResult, magazine.ToString());
        }
    }
}