using Lab2_Pt2.repository;

namespace Lab2_Pt2;

public abstract class PrintEdition(long editionId, string title, string releaseDate, Publisher publisher) : IPublisher
{
    public long EditionID { get; set;  } = editionId;
    public string Title { get; set; } = title;
    public string ReleaseDate { get; set; } = releaseDate;
    public Publisher Publisher { get; set; } = publisher;
    public List<Author> Authors { get; } = new List<Author>();

    public void AddAuthor(Author author)
    {
        Authors.Add(author);
        author.AddWork(this);
    }
    
    private string GetAuthors()
    {
        return Authors.Count > 0
            ? string.Join(", ", Authors.Select(a => a.Name))
            : "No authors";
    }

    public void Publish()
    {
        Console.WriteLine("Publishing " + Title + " by " + GetAuthors() + ", at " + ReleaseDate + " to " + Publisher.Name);
    }

    public override bool Equals(object? obj)
    {
        if (obj is PrintEdition edition)
        {
            return EditionID == edition.EditionID;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return EditionID.GetHashCode();
    }
    
    public override string ToString()
    {
        string authors = Authors.Count > 0 
            ? string.Join(", ", Authors.Select(a => a.Name)) 
            : "No authors";
        
        return $"[Type: {GetType().Name}] EditionID: {EditionID} Title: {Title}, Publisher: {Publisher.Name}, Release Date: {ReleaseDate}, Authors: {authors}";
    }
}