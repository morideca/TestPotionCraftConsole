namespace ConsoleApp1.Dishes;

public class OnionSoup : Recipe
{
	public override string Name { get; protected set; }
	public override List<Dictionary<string, int[]>> Recipes { get; protected set; } = new();

	public OnionSoup()
	{
		Name = "Луковый суп";
		var recipe = new Dictionary<string, int[]>
		{
			{ "лук", [4] }
		};
		Recipes.Add(recipe);
		
		recipe = new Dictionary<string, int[]>
		{
			{ "лук", [5] }
		};
		Recipes.Add(recipe);
	}
}