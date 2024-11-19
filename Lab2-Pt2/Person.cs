namespace Lab2_Pt2;

public class Person
{
    public string Name { get; set; }
    
    public int Age { get; set; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public override string ToString()
    {
        return $"[Type: {GetType()}, Name: {Name}, Age: {Age}]";
    }
}