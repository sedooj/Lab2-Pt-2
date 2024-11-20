namespace Lab2_Pt2.model;

public class Magazine : Book
{
    protected Magazine(long editionId, string title, string releaseDate, Publisher publisher, Author[] authors,
        string genre, string headline) : base(editionId, title, releaseDate, publisher, authors, genre)
    {
        Headline = headline;
    }

    public string Headline { get; }

    public override string ToString()
    {
        return $"{base.ToString()}, Headline: {Headline}";
    }

    public new class Builder()
    {
        public Builder(Magazine magazine) : this()
        {
            _editionId = magazine.EditionId;
            _title = magazine.Title;
            _releaseDate = magazine.ReleaseDate;
            _publisher = magazine.Publisher;
            _authors = magazine.Authors.ToList();
            _genre = magazine.Genre;
            _headline = magazine.Headline;
        }

        private long? _editionId;
        private string? _title;
        private string? _releaseDate;
        private Publisher? _publisher;
        private readonly List<Author> _authors = [];
        private string? _genre;
        private string? _headline;

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

        public Builder WithHeadline(string headline)
        {
            _headline = Validator.RequireNotBlank(headline, nameof(headline));
            return this;
        }

        public Magazine Build()
        {
            // Validate all required fields
            var editionId = Validator.RequireNotNull(_editionId, nameof(_editionId));
            var title = Validator.RequireNotNull(_title, nameof(_title));
            var releaseDate = Validator.RequireNotNull(_releaseDate, nameof(_releaseDate));
            var publisher = Validator.RequireNotNull(_publisher, nameof(_publisher));
            var genre = Validator.RequireNotNull(_genre, nameof(_genre));
            var headline = Validator.RequireNotNull(_headline, nameof(_headline));

            return new Magazine(
                editionId,
                title,
                releaseDate,
                publisher,
                _authors.ToArray(),
                genre,
                headline
            );
        }
    }
}