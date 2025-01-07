namespace ConsoleApp1.Dishes;

public class SmashedPotato : Dish
{
	public override string Name { get; protected set; }
	public override List<Dictionary<string, int[]>> Recipes { get; protected set; } = new();

	public SmashedPotato()
	{
		Name = "Картофельное пюре";
		var recipe = new Dictionary<string, int[]>
		{
			{ "картофель", [4] }
		};
		Recipes.Add(recipe);
		recipe = new Dictionary<string, int[]>
		{
			{ "картофель", [5] }
		};
		Recipes.Add(recipe);
	}
}