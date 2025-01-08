namespace ConsoleApp1;

public class DishAnalystView
{
	public void OnDishPrepared(string name)
	{
		Console.WriteLine($"Получилось! Мы приготовили {name}!");
	}

	public void Show(string name)
	{
		Console.WriteLine($"Последнее блюдо: {name}");
	}
}