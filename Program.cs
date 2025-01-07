using Newtonsoft.Json;

namespace ConsoleApp1;

class Program
{
	static void Main()
	{
		IngredientConfig config = new IngredientConfig();
		ChiefPresenter chiefPresenter = new();
		FactoryPresenter factoryPresenter = new();
		PotPresenter potPresenter = new();
		DishAnalystPresenter dishAnalystPresenter = new();
		PointCounterPresenter pointCounterPresenter = new();

		factoryPresenter.Init(config);
		potPresenter.Init(chiefPresenter, dishAnalystPresenter);
		dishAnalystPresenter.Init(pointCounterPresenter);
		pointCounterPresenter.Init(chiefPresenter, potPresenter);
		chiefPresenter.Init(potPresenter, factoryPresenter, config);
	}
}