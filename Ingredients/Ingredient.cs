namespace ConsoleApp1;

public class Ingredient 
{
    public string Name { get; protected set; }
    public int PointCost { get; protected set; }

    public Ingredient(string name, int pointCost)
    {
        Name = name;
        PointCost = pointCost;
    }
}