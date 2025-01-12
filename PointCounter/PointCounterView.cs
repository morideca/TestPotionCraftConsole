namespace ConsoleApp1;

public class PointCounterView
{
	public void OnAddedPoints(int newPoints, int allPoints, string dishName)
	{
		Console.WriteLine($"{dishName} готов. Заработано {newPoints} очков.");
		Console.WriteLine($"Текущие очки: {allPoints}");
	}

	public void OnBestDishSelected(string name, List<Ingredient> dish, int score)
	{
		var DishIngredientNames = dish.Select(x => x.Name).ToList();
		string ingredientNames = "";
		foreach (var ingredient in DishIngredientNames)
		{
			ingredientNames = ingredientNames + ingredient + ", ";
		}
		ingredientNames = ingredientNames.Remove(ingredientNames.Length - 2);
		Console.WriteLine($"Лучшее блюдо: {name} ({ingredientNames}) - {score} очков.");
	}
}