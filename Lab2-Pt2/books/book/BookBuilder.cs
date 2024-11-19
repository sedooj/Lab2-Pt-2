using Lab2_Pt2.publisher;

namespace Lab2_Pt2.books;

public class BookBuilder
{
    private long _editionId;
    private string? _title;
    private string? _releaseDate;
    private Publisher? _publisher;
    private string? _genre;

    public BookBuilder SetEditionId(long editionId)
    {
        if (editionId <= 0)
        {
            Console.WriteLine("Edition ID must be positive. Try again.");
            return this;
        }

        _editionId = editionId;
        return this;
    }

    public BookBuilder SetTitle(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            Console.WriteLine("Title cannot be empty. Try again.");
            return this;
        }

        _title = title;
        return this;
    }

    public BookBuilder SetReleaseDate(string releaseDate)
    {
        _releaseDate = releaseDate;
        return this;
    }

    public BookBuilder SetPublisher(Publisher publisher)
    {
        _publisher = publisher;
        return this;
    }

    public BookBuilder SetGenre(string genre)
    {
        if (string.IsNullOrWhiteSpace(genre))
        {
            Console.WriteLine("Genre cannot be empty. Try again.");
            return this;
        }

        _genre = genre;
        return this;
    }

    public Book Build()
    {
        if (_editionId <= 0 || string.IsNullOrWhiteSpace(_title) ||
            string.IsNullOrWhiteSpace(_releaseDate) || _publisher == null ||
            string.IsNullOrWhiteSpace(_genre))
        {
            Console.WriteLine("Invalid book data. Restarting process.");
            return Restart();
        }

        return new Book(_editionId, _title, _releaseDate, _publisher, _genre);
    }

    private Book Restart()
    {
        return new BookBuilder()
            .SetEditionId(GetNumber("Enter a valid edition ID:"))
            .SetTitle(GetInput("Enter a valid title:"))
            .SetReleaseDate(GetInput("Enter a valid release date:"))
            .SetPublisher(new PublisherBuilder().SetName(GetInput("Enter publisher name:")).Build())
            .SetGenre(GetInput("Enter a valid genre:"))
            .Build();
    }

    private string GetInput(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine() ?? string.Empty;
    }

    private long GetNumber(string prompt)
    {
        Console.Write(prompt);
        if (long.TryParse(Console.ReadLine(), out var result))
        {
            return result;
        }

        Console.WriteLine("Invalid number. Try again.");
        return GetNumber(prompt);
    }
}