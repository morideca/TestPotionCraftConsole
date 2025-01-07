namespace ConsoleApp1.Dishes;

public abstract class Dish
{
	public abstract string Name { get; protected set; }
	public abstract List<Dictionary<string, int[]>> Recipes { get; protected set; }
}