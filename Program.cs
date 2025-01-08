using ConsoleApp1.Dishes;
using Newtonsoft.Json;

namespace ConsoleApp1;

class Program
{
	private static FactoryPresenter factoryPresenter;
	private static PotPresenter potPresenter;
	private static DishAnalystPresenter dishAnalystPresenter;
	private static PointCounterPresenter pointCounterPresenter;
	static void Main()
	{
		IngredientConfig config = new IngredientConfig();
		DishesData dishesData = new DishesData();
		
		factoryPresenter = new();
		potPresenter = new();
		dishAnalystPresenter = new();
		pointCounterPresenter = new();
		
		FactoryView factoryView = new();
		PotView potView = new(potPresenter);
		DishAnalystView dishAnalystView = new();
		PointCounterView pointCounterView = new();

		FactoryModel factoryModel = new(config);
		PotModel potModel = new();
		DishAnalystModel dishAnalystModel = new(dishesData);
		PointCounterModel pointCounterModel = new(pointCounterView);
		
		factoryPresenter.Init(factoryModel, factoryView);
		potPresenter.Init(potView, potModel, config, factoryPresenter, dishAnalystPresenter);
		dishAnalystPresenter.Init(dishAnalystModel, dishAnalystView, pointCounterPresenter);
		pointCounterPresenter.Init(pointCounterModel, pointCounterView, potPresenter);
		

		potPresenter.onWrongIngredientAdded += Start;
		potPresenter.OnLeftFreeSpace += Start;
		pointCounterPresenter.OnPointsCounted += Start;

		Start();
	}
	
	private static void Start()
	{		
		dishAnalystPresenter.ShowInfo();
		potPresenter.Start();
	}
}