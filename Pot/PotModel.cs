namespace ConsoleApp1;

public class PotModel
{
	public event Action<List<string>> OnIngredientAdded;

	private PointCounterModel pointCounterModel;
	
	private List<Ingredient> ingredients = new();
	private DishAnalyst dishAnalyst;
	private Factory factory;
	private IngredientConfig config;
	
	public PotModel(Factory factory, IngredientConfig config, DishAnalyst dishAnalyst, PointCounterModel pointCounterModel)
	{
		this.factory = factory;
		this.config = config;
		this.dishAnalyst = dishAnalyst;
		this.pointCounterModel = pointCounterModel;
	}
	
	public void AskForIngredient()
	{
		string answer = Console.ReadLine();
		OnChoiceIngredient(answer);
	}
	
	private void OnChoiceIngredient(string answer)
	{
		if (int.TryParse(answer, out int index) && index is >= 1 and <= 5)
		{
			var ingredient = factory.GetIngredient(index);
			AddIngredient(ingredient);
		}
		else AskForIngredient();
	}
	
	private void AddIngredient(Ingredient ingredient)
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
			pointCounterModel.ShowInfo();
			AskForIngredient();
		}
		else
		{
			dishAnalyst.AnalyzeDish(ingredients);
		}
	}
}