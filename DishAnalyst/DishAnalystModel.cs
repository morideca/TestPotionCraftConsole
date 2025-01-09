using ConsoleApp1.Dishes;
using Newtonsoft.Json;

namespace ConsoleApp1;

public class DishAnalystModel
{
	public event Action<string> OnLastDishChanged;
	
	public string DishName { get; private set; }
	public List<Ingredient> Ingredients { get; private set; } = new();

	public void SetIngredients(List<Ingredient> ingredients)
	{
		Ingredients = new();
		foreach (Ingredient ingredient in ingredients)
		{
			Ingredients.Add(ingredient);
		}
	}

	public void SetDishName(string name)
	{
		DishName = name;
		OnLastDishChanged?.Invoke(name);
	}
}