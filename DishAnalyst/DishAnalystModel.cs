using ConsoleApp1.Dishes;
using Newtonsoft.Json;

namespace ConsoleApp1;

public class DishAnalystModel
{
	private DishAnalystView dishAnalystView;

	public string LastDishName;
	public DishesData DishesData { get; set; } = new();
	public List<Ingredient> Ingredients { get; private set; } = new();
	
	public DishAnalystModel(DishAnalystView dishAnalystView)
	{
		this.dishAnalystView = dishAnalystView;
	}

	public void SetIngredients(List<Ingredient> ingredients)
	{
		Ingredients = new();
		foreach (Ingredient ingredient in ingredients)
		{
			Ingredients.Add(ingredient);
		}
	}
}