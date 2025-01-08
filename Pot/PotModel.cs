namespace ConsoleApp1;

public class PotModel
{
	public event Action<Ingredient, List<Ingredient>> OnIngredientAdded;
	public List<Ingredient> Ingredients { get; private set; }= new();
	
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