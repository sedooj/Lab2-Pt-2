using Lab2_Pt2;
using Lab2_Pt2.books;
using Lab2_Pt2.publisher;

var publisher = new PublisherBuilder()
    .SetName("CoolBooks Publishing")
    .Build();

var author_Fred = new AuthorBuilder()
    .SetName("Fred Derf")
    .SetAge(43)
    .Build();

var author_Freeman = new AuthorBuilder()
    .SetName("Mr Freeman")
    .SetAge(34)
    .Build();

var book = new BookBuilder()
    .SetEditionId(751)
    .SetTitle("Life is Live")
    .SetReleaseDate("14:51 14-05-2024")
    .SetPublisher(publisher)
    .SetGenre("Fantasy")
    .Build();

book.AddAuthor(author_Fred);

var textBook = new TextBookBuilder()
    .SetEditionId(82342345)
    .SetTitle("C# for dummies")
    .SetReleaseDate("24-02-1999")
    .SetPublisher(publisher)
    .SetSubject("Programming")
    .Build();

textBook.AddAuthor(author_Fred);
textBook.AddAuthor(author_Freeman);


var magazine = new MagazineBuilder()
    .SetEditionId(9152411293)
    .SetTitle("Save urself")
    .SetReleaseDate("10-01-2020")
    .SetPublisher(publisher)
    .SetHeadline("How to protect urself while covid")
    .Build();

PrintEdition[] library = new PrintEdition[]
{
    book,
    textBook,
    magazine
};

foreach (var item in library)
{
    Console.WriteLine(item.ToString());

    item.Publish();

    Console.WriteLine();
}

Console.WriteLine(book.ToString());