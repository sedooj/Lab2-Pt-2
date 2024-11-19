namespace Lab2_Pt2.books;

public class Book(long editionId, string title, string releaseDate, Publisher publisher, string genre)
    : PrintEdition(editionId, title, releaseDate, publisher)
{
    public string Genre { get; set; } = genre;

    public override void PrintData()
    {
        Console.WriteLine("Book ({0}):\nTitle: {1}\nGenre: {2}", EditionID, Title, Genre);
    }
    
    public override string ToString()
    {
        return base.ToString();
    }
}