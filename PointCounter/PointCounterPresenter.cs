namespace ConsoleApp1;

public class PointCounterPresenter
{
    private PointCounterView view;
    private PointCounterModel model;
    
    private PotPresenter potPresenter;


    public void Init(PotPresenter PotPresenter)
    {
        view = new();
        model = new(view);
        this.potPresenter = PotPresenter;
    }

    public void SetAnalysisResult(List<Ingredient> ingredients, int MatchedIngredientsCount)
    {
        model.SetAnalysisResult(ingredients, MatchedIngredientsCount);
    }

    public void CountPoints()
    {
        var ingredients = model.Ingredients;
        var matchedIngredientsCount = model.MachedIngredientsCount;
        
        int newPoints = 0;
        float multiplier = 0;
        
        foreach (var ingredient in ingredients)
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
        model.AddPoints(newPoints);
    }

    public void ShowInfo()
    {
        view.ShowInfo(model.Points);
    }
}