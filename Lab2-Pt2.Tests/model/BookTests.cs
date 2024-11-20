using Lab2_Pt2.model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lab2_Pt2.Tests.model;

[TestClass]
public class BookTests
{
    [TestMethod]
    public void Build_ValidBook_ReturnsBookInstance()
    {
        var publisher = new Publisher.Builder()
            .WithName("Test Publisher")
            .Build();

        var author = new Author.Builder()
            .WithName("Test Author")
            .WithAge(30)
            .Build();

        var book = new Book.Builder()
            .WithEditionId(1)
            .WithTitle("Test Book")
            .WithReleaseDate("2024-11-20")
            .WithPublisher(publisher)
            .AddAuthor(author)
            .WithGenre("Fiction")
            .Build();

        Assert.AreEqual(1, book.EditionId);
        Assert.AreEqual("Test Book", book.Title);
        Assert.AreEqual("2024-11-20", book.ReleaseDate);
        Assert.AreEqual(publisher, book.Publisher);
        CollectionAssert.Contains(book.Authors, author);
        Assert.AreEqual("Fiction", book.Genre);
    }

    [TestMethod]
    public void Build_MissingTitle_ThrowsValidationNullException()
    {
        var publisher = new Publisher.Builder()
            .WithName("Test Publisher")
            .Build();

        var author = new Author.Builder()
            .WithName("Test Author")
            .WithAge(30)
            .Build();

        Assert.ThrowsException<ValidationNullException>(() =>
            new Book.Builder()
                .WithEditionId(1)
                .WithReleaseDate("2024-11-20")
                .WithPublisher(publisher)
                .AddAuthor(author)
                .WithGenre("Fiction")
                .Build());
    }

    [TestMethod]
    public void Build_InvalidEditionId_ThrowsValidationNotCourseInException()
    {
        Assert.ThrowsException<ValidationNotCourseInException<long>>(() =>
            new Book.Builder()
                .WithEditionId(-1)
                .WithTitle("Test Book")
                .WithReleaseDate("2024-11-20")
                .WithPublisher(new Publisher.Builder()
                    .WithName("Test Publisher")
                    .Build())
                .WithGenre("Fiction")
                .Build());
    }

    [TestMethod]
    public void Build_InvalidGenre_ThrowsValidationNotBlankException()
    {
        var publisher = new Publisher.Builder()
            .WithName("Test Publisher")
            .Build();

        Assert.ThrowsException<ValidationNotBlankException>(() =>
            new Book.Builder()
                .WithEditionId(1)
                .WithTitle("Test Book")
                .WithReleaseDate("2024-11-20")
                .WithPublisher(publisher)
                .WithGenre("")
                .Build());
    }
}