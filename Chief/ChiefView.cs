namespace ConsoleApp1;

public class ChiefView
{
	private ChiefPresenter _chiefPresenter;

	public void Init(ChiefPresenter chiefPresenter)
	{
		this._chiefPresenter = chiefPresenter;
		Console.WriteLine("Добрый день! Давайте приступим к готовке!"); 
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
		_chiefPresenter.OnChoiceIngredient(answer);
	}
	
	public void OnWrongIngredient()
	{
		Console.WriteLine("К сожалению, такого ингредиента нет :( Давайте попробуем снова!");
	}
}