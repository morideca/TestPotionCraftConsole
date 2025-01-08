namespace ConsoleApp1;

public class PointCounterModel
{
	public int Points { get; private set; }
	private PointCounterView pointCounterView;

	public List<Ingredient> Ingredients { get; private set; }
	public int MachedIngredientsCount{ get; private set; }

	public PointCounterModel(PointCounterView pointCounterView)
	{
		this.pointCounterView = pointCounterView;
	}

	public void SetAnalysisResult(List<Ingredient> ingredients, int MatchedIngredientsCount)
	{
		Ingredients = new();
		Ingredients = ingredients;
		this.MachedIngredientsCount = MatchedIngredientsCount;
	}
	
	public void AddPoints(int points)
	{
		this.Points += points;
		pointCounterView.OnAddedPoints(points);
	}
}