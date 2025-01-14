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
	
	private DishPointCounter dishPointCounter;

	public PointCounterModel(PotModel potModel, DishAnalyst dishAnalysis, DishPointCounter dishPointCounter)
	{
		this.dishPointCounter = dishPointCounter;
		dishAnalysis.OnAnalysisDone += SetAnalysisResult;
		potModel.OnAskedForIngredientAgain += ShowInfo;
	}

	public void SetAnalysisResult(List<Ingredient> ingredients, int MatchedIngredientsCount, string name)
	{
		this.lastDish = ingredients;
		lastDishName = name;
		CountPoints(lastDish, MatchedIngredientsCount);
	}

	private void CountPoints(List<Ingredient> lastDish, int matchedIngredientsCount)
	{
		lastDishScore = dishPointCounter.CountPoints(lastDish, matchedIngredientsCount);

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

	private void ShowInfo()
	{
		OnPointsCounted?.Invoke(lastDishScore, this.Score, lastDishName);
		OnBestDishSelected?.Invoke(bestDishName, bestDish, bestDishScore);
		OnFinished?.Invoke();
	}
}