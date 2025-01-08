namespace ConsoleApp1;

public class PointCounterView
{
	public void OnAddedPoints(int newPoints)
	{
		Console.WriteLine($"Круто получилось! Ты заработал {newPoints} очков!");
	}

	public void ShowInfo(int allPoints)
	{
		Console.WriteLine($"Текущие очки: {allPoints}");
	}
}