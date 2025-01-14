﻿using ConsoleApp1.Dishes;
using Newtonsoft.Json;

namespace ConsoleApp1;

class Program
{
	private static PotModel potModel;
	static void Main()
	{
		IngredientConfig config = new IngredientConfig();
		RecipeData recipeData = new RecipeData();
		Factory factory = new(config);

		DishAnalyst dishAnalyst = new(recipeData);
		PointCounterModel pointCounterModel = new(dishAnalyst);
		potModel = new(factory, config, dishAnalyst, pointCounterModel);

		PotView potView = new();
		PointCounterView pointCounterView = new();

		PotPresenter potPresenter = new(potView, potModel);
		PointCounterPresenter pointCounterPresenter = new(pointCounterModel, pointCounterView);
		
		pointCounterModel.OnFinished += Start;

		Start();
	}

	private static void Start()
	{
		potModel.AskForIngredient();
	}
}