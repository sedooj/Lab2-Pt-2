using System.Collections.Immutable;

namespace Lab2_Pt2.model;

public sealed class Author : Person
{
    private Author(string name, int age) : base(name, age)
    {
    }

    public override string ToString()
    {
        return $"[Type: {GetType().Name}, Name: {Name}, Age: {Age}]";
    }

    public new class Builder()
    {
        public Builder(Author author) : this()
        {
            _name = author.Name;
            _age = author.Age;
        }

        private string? _name;
        private int _age;

        public Builder WithName(string name)
        {
            _name = Validator.RequireNotBlank(name, nameof(name));
            return this;
        }

        public Builder WithAge(int age)
        {
            _age = Validator.RequireGreaterThan(age, 0, nameof(age));
            return this;
        }

        public Author Build()
        {
            var age = Validator.RequireNotNull(_age, nameof(_age));
            var name = Validator.RequireNotNull(_name, nameof(_name));

            return new Author(name, age);
        }
    }
}