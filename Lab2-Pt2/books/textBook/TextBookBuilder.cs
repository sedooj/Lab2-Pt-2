using Lab2_Pt2.publisher;

namespace Lab2_Pt2.books;

public class TextBookBuilder
{
    private long _editionId;
    private string? _title;
    private string? _releaseDate;
    private Publisher? _publisher;
    private string? _subject;

    public TextBookBuilder SetEditionId(long editionId)
    {
        if (editionId <= 0)
        {
            Console.WriteLine("Edition ID must be positive. Try again.");
            return this;
        }

        _editionId = editionId;
        return this;
    }

    public TextBookBuilder SetTitle(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            Console.WriteLine("Title cannot be empty. Try again.");
            return this;
        }

        _title = title;
        return this;
    }

    public TextBookBuilder SetReleaseDate(string releaseDate)
    {
        _releaseDate = releaseDate;
        return this;
    }

    public TextBookBuilder SetPublisher(Publisher publisher)
    {
        _publisher = publisher;
        return this;
    }

    public TextBookBuilder SetSubject(string subject)
    {
        if (string.IsNullOrWhiteSpace(subject))
        {
            Console.WriteLine("Subject cannot be empty. Try again.");
            return this;
        }

        _subject = subject;
        return this;
    }

    public TextBook Build()
    {
        if (_editionId <= 0 || string.IsNullOrWhiteSpace(_title) ||
            string.IsNullOrWhiteSpace(_releaseDate) || _publisher == null ||
            string.IsNullOrWhiteSpace(_subject))
        {
            Console.WriteLine("Invalid textbook data. Restarting process.");
            return Restart();
        }

        return new TextBook(_editionId, _title, _releaseDate, _publisher, _subject);
    }

    private TextBook Restart()
    {
        return new TextBookBuilder()
            .SetEditionId(GetNumber("Enter a valid edition ID:"))
            .SetTitle(GetInput("Enter a valid title:"))
            .SetReleaseDate(GetInput("Enter a valid release date:"))
            .SetPublisher(new PublisherBuilder().SetName(GetInput("Enter publisher name:")).Build())
            .SetSubject(GetInput("Enter a valid subject:"))
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