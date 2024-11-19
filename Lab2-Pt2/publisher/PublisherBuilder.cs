namespace Lab2_Pt2.publisher;

public class PublisherBuilder
{
    private string? _name;

    public PublisherBuilder SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Name cannot be empty. Try again.");
            return this; // Return the same builder instance for retry.
        }

        _name = name;
        return this;
    }

    public Publisher Build()
    {
        if (string.IsNullOrWhiteSpace(_name))
        {
            Console.WriteLine("Publisher name is not set. Restarting process.");
            return Restart(); // Restart builder on incomplete data.
        }

        return new Publisher(_name);
    }

    private Publisher Restart()
    {
        return new PublisherBuilder()
            .SetName(GetInput("Enter a valid publisher name:"))
            .Build();
    }

    private string GetInput(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine() ?? string.Empty;
    }
}