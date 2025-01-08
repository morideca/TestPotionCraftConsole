using ConsoleApp1.Dishes;
using Newtonsoft.Json;

namespace ConsoleApp1;

public class DishAnalystModel
{
	public string DishName;
	public DishesData DishesData { get; set; }
	public List<Ingredient> Ingredients { get; private set; } = new();
	
	public DishAnalystModel(DishesData dishesData)
	{
		DishesData = dishesData;
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