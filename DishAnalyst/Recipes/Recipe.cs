namespace ConsoleApp1.Dishes;

public abstract class Recipe
{
	public abstract string Name { get; protected set; }
	public abstract List<Dictionary<string, int[]>> Recipes { get; protected set; }
}