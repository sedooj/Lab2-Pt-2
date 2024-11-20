using System;
using Lab2_Pt2.model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lab2_Pt2.Tests.model
{
    [TestClass]
    public class AuthorTests
    {
        [TestMethod]
        public void AuthorBuilder_WithValidNameAndAge_CreatesAuthor()
        {
            var builder = new Author.Builder()
                .WithName("Test Name")
                .WithAge(35);

            var author = builder.Build();

            Assert.AreEqual("Test Name", author.Name);
            Assert.AreEqual(35, author.Age);
        }

        [TestMethod]
        public void AuthorBuilder_WithInvalidName_ThrowsException()
        {
            var builder = new Author.Builder();
            Assert.ThrowsException<ValidationNotBlankException>(() => builder.WithName(""));
        }

        [TestMethod]
        public void AuthorBuilder_WithInvalidAge_ThrowsException()
        {
            var builder = new Author.Builder();
            Assert.ThrowsException<ValidationNotCourseInException<int>>(() => builder.WithAge(-1));
        }

        [TestMethod]
        public void AuthorBuilder_CopyConstructor_CopiesExistingAuthor()
        {
            var originalAuthor = new Author.Builder()
                .WithName("Test Name")
                .WithAge(28)
                .Build();

            var copiedBuilder = new Author.Builder(originalAuthor);
            var copiedAuthor = copiedBuilder.Build();

            Assert.AreEqual(originalAuthor.Name, copiedAuthor.Name);
            Assert.AreEqual(originalAuthor.Age, copiedAuthor.Age);
        }

        [TestMethod]
        public void Author_ToString_ReturnsExpectedFormat()
        {
            var author = new Author.Builder()
                .WithName("Test Name")
                .WithAge(35)
                .Build();

            var result = author.ToString();

            Assert.AreEqual("[Type: Author, Name: Test Name, Age: 35]", result);
        }
    }
}