namespace ConsoleApp1;

public class PotView
{
	public void OnIngredientAdded(string name, List<string> ingredients)
	{
		Console.WriteLine($"Вы положили {name} в кастрюлю.");
		Console.WriteLine($"Текущие ингредиенты в кастрюле:");
		foreach (var ingredient in ingredients)
		{
			Console.WriteLine($" {ingredient},");
		}
	}
	
	public void OnGotEnoughIngredients()
	{
		Console.WriteLine("Что ж, этого хватит. Готовлю блюдо...");
	}
}