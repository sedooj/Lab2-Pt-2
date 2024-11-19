namespace Lab2_Pt2;

public class AuthorBuilder
{
    private string? _name;
    private int _age;

    public AuthorBuilder SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Author name cannot be empty. Try again.");
            return this;
        }

        _name = name;
        return this;
    }

    public AuthorBuilder SetAge(int age)
    {
        if (age <= 0)
        {
            Console.WriteLine("Age must be greater than 0. Try again.");
            return this;
        }

        _age = age;
        return this;
    }

    public Author Build()
    {
        if (string.IsNullOrWhiteSpace(_name) || _age <= 0)
        {
            Console.WriteLine("Invalid author data. Restarting process.");
            return Restart();
        }

        return new Author(_name, _age);
    }

    private Author Restart()
    {
        return new AuthorBuilder()
            .SetName(GetInput("Enter a valid author name:"))
            .SetAge(GetAge("Enter a valid author age:"))
            .Build();
    }

    private string GetInput(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine() ?? string.Empty;
    }

    private int GetAge(string prompt)
    {
        Console.Write(prompt);
        if (int.TryParse(Console.ReadLine(), out var result))
        {
            return result;
        }

        Console.WriteLine("Invalid number. Try again.");
        return GetAge(prompt);
    }
}