namespace ConsoleApp1;

public class PotPresenter
{
    private ChiefPresenter chiefPresenter;
    private DishAnalystPresenter dishAnalystPresenter;
    private PotModel model;
    private PotView view;

    public void Init(ChiefPresenter chiefPresenter, DishAnalystPresenter dishAnalystPresenter)
    {
        this.chiefPresenter = chiefPresenter;
        this.dishAnalystPresenter = dishAnalystPresenter;
        view = new();
        model = new(view);
    }
    
    public void AddIngredient(Ingredient ingredient)
    {
        model.AddIngredient((ingredient));
        var ingredients = model.Ingredients;
        
        if (ingredients.Count < 5)
        {
            chiefPresenter.AskForIngredient();
        }
        else
        {
            view.OnGotEnoughIngredients();
            dishAnalystPresenter.SetIngredients(ingredients);
            dishAnalystPresenter.AnalyzeDish();
        }
    }

    public void OnDishPrepared()
    {
        model.ClearIngredients();
    }
}