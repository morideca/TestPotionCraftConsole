namespace ConsoleApp1.Dishes;

public class Stew : Dish
{
	public override string Name { get; protected set; }
	public override List<Dictionary<string, int[]>> Recipes { get; protected set; } = new();

	public Stew()
	{
		Name = "Рагу";
		var recipe = new Dictionary<string, int[]>
		{
			{ "мясо", [2] }
		};
		Recipes.Add(recipe);
		recipe = new Dictionary<string, int[]>
		{
			{ "мясо", [3] }
		};
		Recipes.Add(recipe);
	}
}