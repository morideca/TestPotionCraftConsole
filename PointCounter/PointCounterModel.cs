namespace ConsoleApp1;

public class PointCounterModel
{
	public event Action<int, int, string> OnPointsCounted;
	public event Action<string, List<Ingredient>, int> OnBestDishSelected;

	public event Action OnFinished;
	
	private int Score;

	private List<Ingredient> lastDish;
	private string lastDishName = "нет";
	private int lastDishScore = 0;

	private string bestDishName = "нет";
	private List<Ingredient> bestDish;
	private int bestDishScore = 0;
	
	private int matchedIngredientsCount;

	public PointCounterModel(DishAnalyst dishAnalysis)
	{
		dishAnalysis.OnAnalysisDone += SetAnalysisResult;
	}

	public void SetAnalysisResult(List<Ingredient> ingredients, int MatchedIngredientsCount, string name)
	{
		this.lastDish = ingredients;
		this.matchedIngredientsCount = MatchedIngredientsCount;
		lastDishName = name;
		CountPoints();
	}

	private void CountPoints()
	{
		float multiplier = 0;
		lastDishScore = 0;
        
		foreach (var ingredient in lastDish)
		{
			lastDishScore += ingredient.PointCost;
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
        
		lastDishScore = (int)Math.Round(lastDishScore * multiplier);

		if (lastDishScore > bestDishScore)
		{
			bestDish = new();
			foreach (var dish in lastDish)
			{
				bestDish.Add(dish);
			}
			bestDishScore = lastDishScore;
			bestDishName = lastDishName;
		}
		AddPoints(lastDishScore);
	}
	
	private void AddPoints(int points)
	{
		this.Score += points;
		ShowInfo();
	}

	public void ShowInfo()
	{
		OnPointsCounted?.Invoke(lastDishScore, this.Score, lastDishName);
		OnBestDishSelected?.Invoke(bestDishName, bestDish, bestDishScore);
		OnFinished?.Invoke();
	}
}