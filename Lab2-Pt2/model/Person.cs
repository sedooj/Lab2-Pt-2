namespace Lab2_Pt2.model;

public class Person
{
    public string Name { get; }
    
    public int Age { get; }

    protected Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public override string ToString()
    {
        return $"[Type: Person, Name: {Name}, Age: {Age}]";
    }
    public class Builder
    {
        private string? _name;
        private int _age;

        public Builder WithName(string name)
        {
            _name = Validator.RequireNotBlank(name, nameof(name));
            return this;
        }

        public Builder WithAge(int age)
        {
            _age = Validator.RequireGreaterOrEqualsThan(age, 0, nameof(age));
            return this;
        }

        public Person Build()
        {
            var name = Validator.RequireNotNull(_name, nameof(_name));
            var age = Validator.RequireNotNull(_age, nameof(_age));
            return new Person(name, age);
        }
    }
}