namespace ConsoleApp1;

public class PotModel
{
	public event Action<Ingredient, List<Ingredient>> OnIngredientAdded;
	public IngredientConfig Config { get; private set; }
	public List<Ingredient> Ingredients { get; private set; }= new();

	public PotModel(IngredientConfig config)
	{
		this.Config = config;
	}
	
	public void AddIngredient(Ingredient ingredient)
	{
		Ingredients.Add(ingredient);
		OnIngredientAdded?.Invoke(ingredient, Ingredients);
	}

	public void ClearIngredients()
	{
		Ingredients.Clear();
	}
}