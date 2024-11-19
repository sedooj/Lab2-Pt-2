using Lab2_Pt2;
using Lab2_Pt2.books;

var publisher = new Publisher( "CoolBooks Publishing");
var author1 = new Author("Mr Freeman", 34);
var author2 = new Author("Fred Derf", 43);

var book = new Book(751,"Life is live", "14:51 14-05-2024", publisher, "Fantasy");
book.AddAuthor(author1);

var textbook = new TextBook(851244, "C# for dummies", "24-02-1999", publisher, "Programming");
textbook.AddAuthor(author1);
textbook.AddAuthor(author2);

var magazine = new Magazine(9152411293, "Save urself", "10-01-2020", publisher, "How to protect urself while covid");

PrintEdition[] library = new PrintEdition[]
{
    book,
    textbook,
    magazine
};

foreach (var item in library)
{
    Console.WriteLine(item.ToString());

    item.PrintData();
    item.Publish();

    Console.WriteLine();
}