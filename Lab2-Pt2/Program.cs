using Lab2_Pt2;
using Lab2_Pt2.model;

class Program
{
    public static void Main()
    {
        var publisher = new Publisher.Builder()
            .WithName("CoolBooks Publishing")
            .Build();

        var authorFred = new Author.Builder()
            .WithName("Fred Derf")
            .WithAge(43)
            .Build();

        var authorFreeman = new Author.Builder()
            .WithName("Mr Freeman")
            .WithAge(34)
            .Build();

        var book = new Book.Builder()
            .WithEditionId(751)
            .WithTitle("Life is Live")
            .WithReleaseDate("14:51 14-05-2024")
            .WithPublisher(publisher)
            .WithGenre("Fantasy")
            .AddAuthor(authorFred)
            .Build();

        var textBook = new TextBook.Builder()
            .WithEditionId(82342345)
            .WithTitle("C# for dummies")
            .WithReleaseDate("24-02-1999")
            .WithPublisher(publisher)
            .WithSubject("Programming")
            .WithGenre("Fantasy")
            .AddAuthor(authorFred)
            .AddAuthor(authorFreeman)
            .Build();

        var magazine = new Magazine.Builder()
            .WithEditionId(9152411293)
            .WithTitle("Save urself")
            .WithReleaseDate("10-01-2020")
            .WithPublisher(publisher)
            .WithGenre("Science")
            .WithHeadline("How to protect urself while covid")
            .Build();

        PrintedEdition[] library =
        [
            book,
            textBook,
            magazine
        ];

        foreach (var item in library)
        {
            Console.WriteLine(item.ToString());
        }
    }
}