namespace ConsoleApp1;

public class PointCounterView
{
	public void OnAddedPoints(int newPoints, int allPoints)
	{
		Console.WriteLine($"Круто получилось! Ты заработал {newPoints} очков!");
		Console.WriteLine($"Текущие очки: {allPoints}");
		Console.WriteLine("Так держать! Давайте приготовим еще одно блюдо!");
	}
}