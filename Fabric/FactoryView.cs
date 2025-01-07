namespace ConsoleApp1;

public class FactoryView
{
	public void OnGotIngredient(Ingredient ingredient)
	{
		Console.WriteLine($"Вы взяли {ingredient.Name}");
	}
}