namespace ConsoleApp1;

public class PointCounterModel
{
	public event Action<int, int> OnPointChanged;
	
	public int Points { get; private set; }
	
	public List<Ingredient> Ingredients { get; private set; }
	public int MachedIngredientsCount{ get; private set; }

	public void SetAnalysisResult(List<Ingredient> ingredients, int MatchedIngredientsCount)
	{
		Ingredients = new();
		Ingredients = ingredients;
		this.MachedIngredientsCount = MatchedIngredientsCount;
	}
	
	public void AddPoints(int points)
	{
		this.Points += points;
		OnPointChanged?.Invoke(points, this.Points);
	}
}