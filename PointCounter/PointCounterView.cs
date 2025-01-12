namespace ConsoleApp1;

public class PointCounterView
{
	public void OnScoreChanged(int newPoints, int allPoints, string dishName)
	{
		Console.WriteLine($"Последнее блюдо: {dishName} - {newPoints} очков.");
		Console.WriteLine($"Текущие очки: {allPoints}");
	}

	public void OnBestDishSelected(string name, List<Ingredient> dish, int score)
	{
		if (dish == null)
		{
			Console.WriteLine($"Лучшее блюдо: нет.");
		}
		else
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
}