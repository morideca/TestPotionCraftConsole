using ConsoleApp1.Dishes;
using Newtonsoft.Json;

namespace ConsoleApp1;

class Program
{
	private static PotModel potModel;
	static void Main()
	{
		IngredientConfig ingredientConfig = new IngredientConfig();
		RecipeData recipeData = new RecipeData();
		
		DishPointCounter dishPointCounter = new DishPointCounter();

		potModel = new();
		DishAnalyst dishAnalyst = new(recipeData, potModel);
		PointCounterModel pointCounterModel = new(potModel, dishAnalyst, dishPointCounter);
		
		PotView potView = new();
		PointCounterView pointCounterView = new();

		PotPresenter potPresenter = new(potView, potModel);
		PointCounterPresenter pointCounterPresenter = new(pointCounterModel, pointCounterView);

		UserInput userInput = new UserInput(potModel, ingredientConfig, pointCounterModel);
		
		userInput.AskForIngredient();
	}
}