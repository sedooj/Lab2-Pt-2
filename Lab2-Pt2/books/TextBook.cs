namespace Lab2_Pt2.books;

public class TextBook(long editionId, string title, string releaseDate, Publisher publisher, string subject)
    : Book(editionId, title, releaseDate, publisher, subject)
{
    public string Subject { get; set; } = subject;
    
    public override string ToString()
    {
        return $"{base.ToString()}, Subject: {Subject}";
    }
}