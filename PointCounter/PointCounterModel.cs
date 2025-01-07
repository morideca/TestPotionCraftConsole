namespace ConsoleApp1;

public class PointCounterModel
{
	private int points;
	private PointCounterView pointCounterView;

	public List<Ingredient> Ingredients { get; private set; }
	public int MachedIngredientsCount{ get; private set; }

	public PointCounterModel(PointCounterView pointCounterView)
	{
		this.pointCounterView = pointCounterView;
	}

	public void SetAnalysisResult(List<Ingredient> ingredients, int MatchedIngredientsCount)
	{
		this.Ingredients = ingredients;
		this.MachedIngredientsCount = MatchedIngredientsCount;
	}
	
	public void AddPoints(int points)
	{
		this.points += points;
		pointCounterView.OnAddedPoints(points, this.points);
	}
}