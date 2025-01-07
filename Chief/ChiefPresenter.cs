namespace ConsoleApp1;

public class ChiefPresenter
{
	private ChiefModel model;
	private ChiefView view;
	private FactoryPresenter factoryPresenter;
	private PotPresenter potPresenter;

	public void Init(PotPresenter potPresenter, FactoryPresenter factoryPresenter, IngredientConfig config)
	{
		this.view = new();
		this.model = new(config);
		this.factoryPresenter = factoryPresenter;
		this.potPresenter = potPresenter;
		view.Init(this);
		view.AskForIngredient(model.config.ingredientsConfig);
	}

	public void OnChoiceIngredient(string answer)
	{
		if (int.TryParse(answer, out int index) && index is >= 1 and <= 5)
		{
			var ingredient = factoryPresenter.GetIngredient(index);
			potPresenter.AddIngredient(ingredient);
		}
		else
		{
			view.OnWrongIngredient();
			view.AskForIngredient(model.config.ingredientsConfig);
		}
	}

	public void AskForIngredient()
	{ 
		view.AskForIngredient(model.config.ingredientsConfig);
	}
}