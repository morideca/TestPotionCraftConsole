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
        model.onWrongIngredientAdded += OnWrongIngredient;
    }

    private void OnWrongIngredient()
    {
        view.OnWrongIngredient();
    }
    
    private void OnIngredientAdded(List<string> ingredients)
    {
        view.OnIngredientAdded(ingredients);
    }
}
