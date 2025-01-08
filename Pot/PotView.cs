namespace ConsoleApp1;

public class PotView
{
	private PotPresenter potPresenter;
	
	public PotView(PotPresenter potPresenter)
	{
		this.potPresenter = potPresenter;
	}
	
	public void AskForIngredient(List<Ingredient> config)
	{
		Console.WriteLine("Что хотите добавить?");
		int i = 0;
		foreach (var ingredient in config)
		{
			Console.WriteLine($"{config[i].Id} - {config[i].Name}");
			i++;
		}
		string answer = Console.ReadLine();
		potPresenter.OnChoiceIngredient(answer);
	}
	
	public void OnWrongIngredient()
	{
		Console.WriteLine("К сожалению, такого ингредиента нет :( Давайте попробуем снова!");
	}
	
	public void OnIngredientAdded(string name)
	{
		Console.WriteLine($"Вы положили {name} в кастрюлю.");
	}

	public void Show(List<string> ingredients)
	{
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