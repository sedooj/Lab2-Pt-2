namespace Lab2_Pt2.books;

public class Magazine(long editionId, string title, string releaseDate, Publisher publisher, string headline)
    : Book(editionId, title, releaseDate, publisher, headline)
{
    public string Headline { get; set; } = headline;
    
    public override void PrintData()
    {
        Console.WriteLine("Magazine ({0}):\nTitle: {1}\nHeadline: {2}", EditionID, Title, Headline);
    }
    
    public override string ToString()
    {
        return $"{base.ToString()}, Headline: {Headline}";
    }
}