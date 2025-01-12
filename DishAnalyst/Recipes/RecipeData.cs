namespace ConsoleApp1.Dishes;

public class RecipeData
{
	public List<Recipe> Recipes { get; private set; } = new();

	public RecipeData()
	{
		Recipes.Add(new MeatWithGarnish());
		Recipes.Add(new MeatWithMeat());
		Recipes.Add(new OnionSoup());
		Recipes.Add(new SmashedPotato());
		Recipes.Add(new Stew());
		Recipes.Add(new VegetableStew());
	}
}