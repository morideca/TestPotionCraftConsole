namespace ConsoleApp1.Dishes;

public class VegetableStew : Dish
{
	public override string Name { get; protected set; }
	public override List<Dictionary<string, int[]>> Recipes { get; protected set; } = new();

	public VegetableStew()
	{
		Name = "Рагу с овощами";
		var recipe = new Dictionary<string, int[]>
		{
			{ "мясо", [0] }
		};
		Recipes.Add(recipe);
	}
}