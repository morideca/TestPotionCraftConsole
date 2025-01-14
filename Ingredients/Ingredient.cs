namespace ConsoleApp1;

public class Ingredient
{
    public Ingredient(int id, int pointCost, string name)
    {
        Id = id;
        PointCost = pointCost;
        Name = name;
    }
    
    public int Id { get; private set; }
    public int PointCost{ get; private set; }
    public string Name{ get; private set; }
}