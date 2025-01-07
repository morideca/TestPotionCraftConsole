namespace ConsoleApp1;

public class DishAnalystView
{
	public void OnDishPrepared(string name)
	{
		Console.WriteLine($"Получилось! Мы приготовили {name}!");
	}
}