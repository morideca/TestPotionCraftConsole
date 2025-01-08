using Newtonsoft.Json;

namespace ConsoleApp1;

class Program
{
	private static IngredientConfig config;
	private static FactoryPresenter factoryPresenter;
	private static PotPresenter potPresenter;
	private static DishAnalystPresenter dishAnalystPresenter;
	private static PointCounterPresenter pointCounterPresenter;
	static void Main()
	{
		 config = new IngredientConfig();
		 factoryPresenter = new();
		 potPresenter = new();
		 dishAnalystPresenter = new();
		 pointCounterPresenter = new();

		factoryPresenter.Init(config);
		potPresenter.Init(factoryPresenter, dishAnalystPresenter, config);
		dishAnalystPresenter.Init(pointCounterPresenter);
		pointCounterPresenter.Init(potPresenter);

		potPresenter.onWrongIngredientAdded += Start;
		potPresenter.OnLeftFreeSpace += Start;
		pointCounterPresenter.OnPointsCounted += Start;

		Start();
	}
	
	private static void Start()
	{		
		potPresenter.ShowInfo();
		dishAnalystPresenter.ShowInfo();
		pointCounterPresenter.ShowInfo();
		potPresenter.Start();
	}
}