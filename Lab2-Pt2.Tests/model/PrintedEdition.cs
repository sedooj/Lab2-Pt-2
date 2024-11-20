using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab2_Pt2.model;

namespace Lab2_Pt2.Tests
{
    [TestClass]
    public class PrintedEditionTests
    {
        private Publisher testPublisher;
        private Author[] testAuthors;

        [TestInitialize]
        public void Setup()
        {
            testPublisher = new Publisher.Builder().WithName("Test Publisher").Build();
            testAuthors = new[]
            {
                new Author.Builder().WithName("Test Author 1").WithAge(40).Build(),
                new Author.Builder().WithName("Test Author 2").WithAge(35).Build()
            };
        }

        [TestMethod]
        public void PrintedEdition_Creation_Success()
        {
            var printedEdition = new MockPrintedEdition(123, "Test Title", "2024-11-01", testPublisher, testAuthors);

            Assert.AreEqual(123, printedEdition.EditionId);
            Assert.AreEqual("Test Title", printedEdition.Title);
            Assert.AreEqual("2024-11-01", printedEdition.ReleaseDate);
            Assert.AreEqual(testPublisher.Name, printedEdition.Publisher.Name);
            Assert.AreEqual(2, printedEdition.Authors.Count);
        }

        [TestMethod]
        public void PrintedEdition_ToString_ReturnsExpectedFormat()
        {
            var printedEdition = new MockPrintedEdition(123, "Test Title", "2024-11-01", testPublisher, testAuthors);

            var result = printedEdition.ToString();

            var expectedString = "[Type: MockPrintedEdition] EditionID: 123, Title: Test Title, Publisher: Test Publisher, Release Date: 2024-11-01, Authors: Test Author 1, Test Author 2";
            Assert.AreEqual(expectedString, result);
        }

        [TestMethod]
        public void PrintedEdition_ToString_WithNoAuthors_ReturnsCorrectString()
        {
            var printedEdition = new MockPrintedEdition(124, "Test Title No Authors", "2024-11-01", testPublisher, new Author[0]);

            var result = printedEdition.ToString();

            var expectedString = "[Type: MockPrintedEdition] EditionID: 124, Title: Test Title No Authors, Publisher: Test Publisher, Release Date: 2024-11-01, Authors: No authors";
            Assert.AreEqual(expectedString, result);
        }
        
        [TestMethod]
        public void PrintedEdition_Equals_DifferentEditionId_ReturnsFalse()
        {
            var printedEdition1 = new MockPrintedEdition(125, "Test Title", "2024-11-01", testPublisher, testAuthors);
            var printedEdition2 = new MockPrintedEdition(126, "Test Title", "2024-11-01", testPublisher, testAuthors);

            Assert.IsFalse(printedEdition1.Equals(printedEdition2));
        }

        [TestMethod]
        public void PrintedEdition_GetHashCode_ReturnsSameValueForEqualObjects()
        {
            var printedEdition1 = new MockPrintedEdition(127, "Test Title", "2024-11-01", testPublisher, testAuthors);
            var printedEdition2 = new MockPrintedEdition(127, "Test Title", "2024-11-01", testPublisher, testAuthors);

            Assert.AreEqual(printedEdition1.GetHashCode(), printedEdition2.GetHashCode());
        }

        [TestMethod]
        public void PrintedEdition_GetHashCode_ReturnsDifferentValueForDifferentObjects()
        {
            var printedEdition1 = new MockPrintedEdition(128, "Test Title", "2024-11-01", testPublisher, testAuthors);
            var printedEdition2 = new MockPrintedEdition(129, "Test Title", "2024-11-01", testPublisher, testAuthors);

            Assert.AreNotEqual(printedEdition1.GetHashCode(), printedEdition2.GetHashCode());
        }

        // Mock implementation to test abstract class
        private class MockPrintedEdition : PrintedEdition
        {
            public MockPrintedEdition(long editionId, string title, string releaseDate, Publisher publisher, Author[] authors)
                : base(editionId, title, releaseDate, publisher, authors)
            {
            }
        }
    }
}