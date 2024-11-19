using Lab2_Pt2.publisher;

namespace Lab2_Pt2.books;

public class MagazineBuilder
{
    private long _editionId;
    private string? _title;
    private string? _releaseDate;
    private Publisher? _publisher;
    private string? _headline;

    public MagazineBuilder SetEditionId(long editionId)
    {
        if (editionId <= 0)
        {
            Console.WriteLine("Edition ID must be positive. Try again.");
            return this;
        }

        _editionId = editionId;
        return this;
    }

    public MagazineBuilder SetTitle(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            Console.WriteLine("Title cannot be empty. Try again.");
            return this;
        }

        _title = title;
        return this;
    }

    public MagazineBuilder SetReleaseDate(string releaseDate)
    {
        _releaseDate = releaseDate;
        return this;
    }

    public MagazineBuilder SetPublisher(Publisher publisher)
    {
        _publisher = publisher;
        return this;
    }

    public MagazineBuilder SetHeadline(string headline)
    {
        if (string.IsNullOrWhiteSpace(headline))
        {
            Console.WriteLine("Headline cannot be empty. Try again.");
            return this;
        }

        _headline = headline;
        return this;
    }

    public Magazine Build()
    {
        if (_editionId <= 0 || string.IsNullOrWhiteSpace(_title) ||
            string.IsNullOrWhiteSpace(_releaseDate) || _publisher == null ||
            string.IsNullOrWhiteSpace(_headline))
        {
            Console.WriteLine("Invalid magazine data. Restarting process.");
            return Restart();
        }

        return new Magazine(_editionId, _title, _releaseDate, _publisher, _headline);
    }

    private Magazine Restart()
    {
        return new MagazineBuilder()
            .SetEditionId(GetNumber("Enter a valid edition ID:"))
            .SetTitle(GetInput("Enter a valid title:"))
            .SetReleaseDate(GetInput("Enter a valid release date:"))
            .SetPublisher(new PublisherBuilder().SetName(GetInput("Enter publisher name:")).Build())
            .SetHeadline(GetInput("Enter a valid headline:"))
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