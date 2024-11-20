namespace Lab2_Pt2.model;

public class TextBook : Book
{
    protected TextBook(long editionId, string title, string releaseDate, Publisher publisher, Author[] authors,
        string genre, string subject) : base(editionId, title, releaseDate, publisher, authors, genre)
    {
        Subject = subject;
    }

    public string Subject { get; }

    public override string ToString()
    {
        return $"{base.ToString()}, Subject: {Subject}";
    }

    public new class Builder()
    {
        public Builder(TextBook textBook) : this()
        {
            _editionId = textBook.EditionId;
            _title = textBook.Title;
            _releaseDate = textBook.ReleaseDate;
            _publisher = textBook.Publisher;
            _authors = textBook.Authors.ToList();
            _genre = textBook.Genre;
            _subject = textBook.Subject;
        }

        private long? _editionId;
        private string? _title;
        private string? _releaseDate;
        private Publisher? _publisher;
        private readonly List<Author> _authors = [];
        private string? _genre;
        private string? _subject;

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

        public Builder WithSubject(string subject)
        {
            _subject = Validator.RequireNotBlank(subject, nameof(subject));
            return this;
        }

        public TextBook Build()
        {
            var editionId = Validator.RequireNotNull(_editionId, nameof(_editionId));
            var validatedTitle = Validator.RequireNotNull(_title, nameof(_title));
            var validatedReleaseDate = Validator.RequireNotNull(_releaseDate, nameof(_releaseDate));
            var validatedPublisher = Validator.RequireNotNull(_publisher, nameof(_publisher));
            var validatedGenre = Validator.RequireNotNull(_genre, nameof(_genre));
            var validatedSubject = Validator.RequireNotNull(_subject, nameof(_subject));

            return new TextBook(
                editionId,
                validatedTitle,
                validatedReleaseDate,
                validatedPublisher,
                _authors.ToArray(),
                validatedGenre,
                validatedSubject
            );
        }
    }
}