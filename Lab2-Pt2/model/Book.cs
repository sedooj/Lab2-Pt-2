namespace Lab2_Pt2.model;

public class Book : PrintedEdition
{
    protected Book(long editionId, string title, string releaseDate, Publisher publisher, Author[] authors,
        string genre) :
        base(editionId, title, releaseDate, publisher, authors)
    {
        Genre = genre;
    }

    public string Genre { get; }

    public override string ToString()
    {
        return $"{base.ToString()}, Genre: {Genre}";
    }

    public class Builder()
    {
        public Builder(Book book) : this()
        {
            _editionId = book.EditionId;
            _title = book.Title;
            _releaseDate = book.ReleaseDate;
            _publisher = book.Publisher;
            _authors = book.Authors.ToList();
            _genre = book.Genre;
        }

        private long? _editionId;
        private string? _title;
        private string? _releaseDate;
        private Publisher? _publisher;
        private readonly List<Author> _authors = [];
        private string? _genre;

        public Builder WithEditionId(long editionId)
        {
            _editionId = Validator.RequireGreaterThan(editionId, 0, nameof(editionId));
            return this;
        }

        public Builder WithTitle(string title)
        {
            _title = Validator.RequireNotBlank(title, nameof(title));
            return this;
        }

        public Builder WithReleaseDate(string releaseDate)
        {
            _releaseDate = Validator.RequireNotBlank(releaseDate, nameof(releaseDate));
            return this;
        }

        public Builder WithPublisher(Publisher publisher)
        {
            _publisher = Validator.RequireNotNull(publisher, nameof(publisher));
            return this;
        }

        public Builder AddAuthor(Author author)
        {
            _authors.Add(Validator.RequireNotNull(author, nameof(author)));
            return this;
        }

        public Builder WithGenre(string genre)
        {
            _genre = Validator.RequireNotBlank(genre, nameof(genre));
            return this;
        }

        public Book Build()
        {
            var editionId = Validator.RequireNotNull(_editionId, nameof(_editionId));
            var title = Validator.RequireNotNull(_title, nameof(_title));
            var releaseDate = Validator.RequireNotNull(_releaseDate, nameof(_releaseDate));
            var publisher = Validator.RequireNotNull(_publisher, nameof(_publisher));
            var genre = Validator.RequireNotNull(_genre, nameof(_genre));

            return new Book(
                editionId,
                title,
                releaseDate,
                publisher,
                _authors.ToArray(),
                genre
            );
        }
    }
}