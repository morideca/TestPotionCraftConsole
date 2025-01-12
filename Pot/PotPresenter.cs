namespace ConsoleApp1;

public class PotPresenter
{
    private PotModel model;
    private PotView view;

    public PotPresenter(PotView view, PotModel model)
    {
        this.view = view;
        this.model = model;
        model.OnIngredientAdded += OnIngredientAdded;
    }
    
    private void OnIngredientAdded(List<string> ingredients)
    {
        view.OnIngredientAdded(ingredients);
    }
}
