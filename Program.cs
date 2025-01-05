namespace ConsoleApp1;

class Program 
{
	 static IngredientConfig ingredientConfig = new();
	 static IngredientFabric fabric = new(ingredientConfig);
	 static Pot pot = new();
	 static FoodAnalyst foodAnalyst = new(pot);
	 static PointCounter pointCounter = new(foodAnalyst);
	
	 static void Main()
	{
		IngredientType ingredientType = IngredientType.none;
	
		Console.WriteLine("Что хотите добавить?" +
		                  "\n1 - картофель\n2 - морковь\n3 - перец\n4 - лук\n5 - мясо"); 
		string answer = Console.ReadLine();
		if (int.TryParse(answer, out int index) && index is >= 1 and <= 5)
		{
			switch (index)
			{
				case 1:
					ingredientType = IngredientType.potato;
					break;
				case 2:
					ingredientType = IngredientType.carrot;
					break;
				case 3:
					ingredientType = IngredientType.Pepper;
					break;
				case 4:
					ingredientType = IngredientType.onion;
					break;
				case 5:
					ingredientType = IngredientType.meat;
					break;
			}
			var ingredient = fabric.GetIngredient(ingredientType);
			pot.AddIngredient(ingredient);
			Main();
		}
		else
		{
			Console.Write("К сожалению, такого ингредиента нет :( Давайте попробуем снова!\n");
			Main();
		}
	}
}