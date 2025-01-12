namespace ConsoleApp1.Dishes;

public class MeatWithMeat : Recipe
{
	public override string Name { get; protected set; }
	public override List<Dictionary<string, int[]>> Recipes { get; protected set; } = new();

	public MeatWithMeat()
	{
		Name = "Мясо в собственном соку";
		var recipe = new Dictionary<string, int[]>
		{
			{ "мясо", [5] }
		};
		Recipes.Add(recipe);
	}
}