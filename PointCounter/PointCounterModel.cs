namespace ConsoleApp1;

public class PointCounterModel
{
	public event Action<int, int, string> OnPointsCounted;
	public event Action<string, List<Ingredient>, int> OnBestDishSelected;

	public event Action OnFinished;
	
	private int Score;
	
	private List<Ingredient> newDish;
	private string newDishName;

	private string bestDishName;
	private List<Ingredient> bestDish;
	private int bestDishScore = 0;
	
	private int matchedIngredientsCount;

	public PointCounterModel(DishAnalyst dishAnalysis)
	{
		dishAnalysis.OnAnalysisDone += SetAnalysisResult;
	}

	public void SetAnalysisResult(List<Ingredient> ingredients, int MatchedIngredientsCount, string name)
	{
		this.newDish = ingredients;
		this.matchedIngredientsCount = MatchedIngredientsCount;
		newDishName = name;
		CountPoints();
	}

	private void CountPoints()
	{
		int newPoints = 0;
		float multiplier = 0;
        
		foreach (var ingredient in newDish)
		{
			newPoints += ingredient.PointCost;
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
        
		newPoints = (int)Math.Round(newPoints * multiplier);

		if (newPoints > bestDishScore)
		{
			bestDish = new();
			foreach (var dish in newDish)
			{
				bestDish.Add(dish);
			}
			bestDishScore = newPoints;
			bestDishName = newDishName;
		}
		AddPoints(newPoints);
	}
	
	private void AddPoints(int points)
	{
		this.Score += points;
		OnPointsCounted?.Invoke(points, this.Score, newDishName);
		OnBestDishSelected?.Invoke(bestDishName, bestDish, bestDishScore);
		OnFinished?.Invoke();
	}
}