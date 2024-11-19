using System.Collections.Immutable;
using Lab2_Pt2.model;

namespace Lab2_Pt2;

public abstract class PrintedEdition
{
    public long EditionId { get; }
    public string Title { get; }
    public string ReleaseDate { get; }
    public Publisher Publisher { get; }
    public ImmutableList<Author> Authors { get; }

    protected PrintedEdition(long editionId, string title, string releaseDate, Publisher publisher, Author[] authors)
    {
        EditionId = editionId;
        Title = title;
        ReleaseDate = releaseDate;
        Publisher = publisher;
        Authors = authors.ToImmutableList();
    }

    public override int GetHashCode()
    {
        return EditionId.GetHashCode();
    }

    public override string ToString()
    {
        var authors = Authors.Count > 0
            ? string.Join(", ", Authors.Select(a => a.Name))
            : "No authors";

        return
            $"[Type: {GetType().Name}] EditionID: {EditionId}, Title: {Title}, Publisher: {Publisher.Name}, Release Date: {ReleaseDate}, Authors: {authors}";
    }
}