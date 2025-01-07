namespace ConsoleApp1.Dishes;

public class MeatWithGarnish : Dish
{
	public override string Name { get; protected set; }
	public override List<Dictionary<string, int[]>> Recipes { get; protected set; } = new();

	public MeatWithGarnish()
	{
		Name = "Мясо с гарниром";
		var recipe = new Dictionary<string, int[]>
		{
			{ "мясо", [4] }
		};
		Recipes.Add(recipe);
	}
}