namespace Lab2_Pt2;

public class Author : Person
{
    public List<PrintEdition> Works { get; } = new List<PrintEdition>();
    
    public Author(string name, int age) : base(name, age) { }

    public void AddWork(PrintEdition work)
    {
        Works.Add(work);
    }

    public override string ToString()
    {
        return $"[Type: {GetType()}, Name: {Name}, Age: {Age}]";
    }
}