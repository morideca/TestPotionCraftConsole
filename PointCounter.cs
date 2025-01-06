namespace ConsoleApp1;

public class PointCounter
{
    private Model model;
    private View view;

    public PointCounter(Model model, View view)
    {
        this.model = model;
        this.view = view;
    }

    public void CountPoints(List<Ingredient> ingredients, int MatchedIngredientsCount)
    {
        int newPoints = 0;
        float multiplier = 0;
        
        foreach (var ingredient in ingredients)
        {
            newPoints += ingredient.PointCost;
        }

        multiplier = MatchedIngredientsCount switch
        {
            1 => 2,
            2 => 2,
            3 => 1.5f,
            4 => 1.25f,
            5 => 1,
            _ => multiplier
        };
        
        newPoints = (int)Math.Round(newPoints * multiplier);
        model.ClearDish();
        model.AddPoints(newPoints);
    }
}