namespace Lab2_Pt2.publisher;

public sealed class Publisher
{
    public string Name { get; set; }

    public Publisher(string name)
    {
        Name = name;
    }

    public override string ToString()
    {
        return $"[Type: {GetType()}, Name: {Name}";
    }
    
}