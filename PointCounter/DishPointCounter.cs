namespace ConsoleApp1;

public class DishPointCounter
{
	public int CountPoints(List<Ingredient> dish, int matchedIngredientsCount)
	{
		float multiplier = 0;
		int dishScore = 0;
        
		foreach (var ingredient in dish)
		{
			dishScore += ingredient.PointCost;
		}

		multiplier = matchedIngredientsCount switch
		{
			1 => 2,
			2 => 2,
			3 => 1.5f,
			4 => 1.25f,
			5 => 1,
			_ => multiplier
		};
        
		dishScore = (int)Math.Round(dishScore * multiplier);
		return dishScore;
	}
}