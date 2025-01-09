namespace ConsoleApp1;

public class DishAnalystView
{
	public void OnLastDishChanged(string name)
	{
		Console.WriteLine($"Последнее блюдо: {name}");
	}
}