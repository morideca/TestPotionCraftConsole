namespace ConsoleApp1;

public class PotView
{
	public void OnIngredientAdded(List<string> ingredients)
	{
		Console.WriteLine($"Текущие ингредиенты в кастрюле:");
		foreach (var _ingredient in ingredients)
		{
			Console.WriteLine($" {_ingredient},");
		}
	}
	
	public void OnWrongIngredient()
	{
		Console.WriteLine("Такого ингредиента нет.");
	}
}