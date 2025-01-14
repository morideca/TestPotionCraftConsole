namespace ConsoleApp1;

public class PotModel
{
	public event Action<List<string>> OnIngredientAdded;
	public event Action<List<Ingredient>> OnDishPrepared;
	public event Action OnAskedForIngredientAgain;

	private PointCounterModel pointCounterModel;
	
	private List<Ingredient> ingredients = new();
	
	public void AddIngredient(Ingredient ingredient)
	{
		if (ingredients.Count == 5)
		{
			ingredients.Clear();
		}
		
		ingredients.Add(ingredient);
		var ingredientNames = ingredients.Select(ingredient => ingredient.Name).ToList();
		
		OnIngredientAdded?.Invoke(ingredientNames);
        
		if (ingredients.Count < 5)
		{
			OnAskedForIngredientAgain?.Invoke();
		}
		else
		{
			OnDishPrepared?.Invoke(ingredients);
		}
	}
}