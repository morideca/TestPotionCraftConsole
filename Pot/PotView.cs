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
	
	public void OnIngredientAdded(string ingredient, List<string> ingredients)
	{
		Console.WriteLine($"Вы положили {ingredient} в кастрюлю.");
		Console.WriteLine($"Текущие ингредиенты в кастрюле:");
		foreach (var _ingredient in ingredients)
		{
			Console.WriteLine($" {_ingredient},");
		}
	}
	
	public void OnGotEnoughIngredients()
	{
		Console.WriteLine("Что ж, этого хватит. Готовлю блюдо...");
	}
	
	public void OnWrongIngredient()
	{
		Console.WriteLine("К сожалению, такого ингредиента нет :( Давайте попробуем снова!");
	}
}