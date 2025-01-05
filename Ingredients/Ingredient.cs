namespace ConsoleApp1;

public class Ingredient 
{
    public string Name { get; protected set; }
    public int Value { get; protected set; }

    public Ingredient(string name, int value)
    {
        Name = name;
        Value = value;
    }
}