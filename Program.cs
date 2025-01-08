using Newtonsoft.Json;

namespace ConsoleApp1;

class Program
{
	static void Main()
	{
		IngredientConfig config = new IngredientConfig();
		FactoryPresenter factoryPresenter = new();
		PotPresenter potPresenter = new();
		DishAnalystPresenter dishAnalystPresenter = new();
		PointCounterPresenter pointCounterPresenter = new();

		factoryPresenter.Init(config);
		potPresenter.Init(factoryPresenter, dishAnalystPresenter, config);
		dishAnalystPresenter.Init(pointCounterPresenter);
		pointCounterPresenter.Init(potPresenter);

		while (true)
		{
			potPresenter.Start();
			potPresenter.ShowInfo();
			dishAnalystPresenter.ShowInfo();
			pointCounterPresenter.ShowInfo();
		}
	}
}