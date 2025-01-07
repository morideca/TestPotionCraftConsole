namespace ConsoleApp1;

public class PotModel
{
	public List<Ingredient> Ingredients => ingredients;
	public List<string> IngredientNames => ingredientNames;
	
	private PotView view;
	private List<Ingredient> ingredients = new();
	private List<string> ingredientNames = new();

	public PotModel(PotView view)
	{
		this.view = view;
	}
	
	public void AddIngredient(Ingredient ingredient)
	{
		ingredients.Add(ingredient);
		ingredientNames.Add(ingredient.Name);
		view.OnIngredientAdded(ingredient.Name, ingredientNames);
	}
	
	public void ClearIngredients()
	{
		ingredients.Clear();
		ingredientNames.Clear();
	}
}