using Lab2_Pt2.publisher;

namespace Lab2_Pt2.books;

public class Magazine(long editionId, string title, string releaseDate, Publisher publisher, string headline)
    : Book(editionId, title, releaseDate, publisher, headline)
{
    public string Headline { get; set; } = headline;
    
    public override string ToString()
    {
        return $"{base.ToString()}, Headline: {Headline}";
    }
}