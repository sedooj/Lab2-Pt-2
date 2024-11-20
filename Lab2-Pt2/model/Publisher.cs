namespace Lab2_Pt2.model;

public sealed class Publisher
{
    public string Name { get; }

    private Publisher(string name)
    {
        Name = name;
    }

    public override string ToString()
    {
        return $"[Type: {GetType().Name}, Name: {Name}";
    }
    
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(this, obj)) return true;
        return obj is Publisher other && string.Equals(Name, other.Name);
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode(StringComparison.Ordinal);
    }

    public class Builder
    {
        private string? _name;

        public Builder WithName(string name)
        {
            _name = Validator.RequireNotBlank(name, nameof(name));
            return this;
        }

        public Publisher Build()
        {
            var validatedName = Validator.RequireNotNull(_name, nameof(_name));
            return new Publisher(validatedName);
        }
    }
}