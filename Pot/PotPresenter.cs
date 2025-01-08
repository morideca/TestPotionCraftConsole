namespace ConsoleApp1;

public class PotPresenter
{
    private DishAnalystPresenter dishAnalystPresenter;
    private PotModel model;
    private PotView view;
    private FactoryPresenter factoryPresenter;

    public void Init(FactoryPresenter factoryPresenter, DishAnalystPresenter dishAnalystPresenter, IngredientConfig config)
    {
        this.factoryPresenter = factoryPresenter;
        this.factoryPresenter = factoryPresenter;
        this.dishAnalystPresenter = dishAnalystPresenter;
        view = new(this);
        model = new(view, config);
    }

    public void Start()
    {
        AskForIngredient();
    }

    private void AskForIngredient()
    {
        view.AskForIngredient(model.config.ingredientsConfig);
    }
    
    public void OnChoiceIngredient(string answer)
    {
        if (int.TryParse(answer, out int index) && index is >= 1 and <= 5)
        {
            var ingredient = factoryPresenter.GetIngredient(index);
            AddIngredient(ingredient);
        }
        else
        {
            view.OnWrongIngredient();
        }
    }
    
    public void OnDishPrepared()
    {
        model.ClearIngredients();
    }

    public void ShowInfo()
    {
        view.Show(model.IngredientNames);
    }
    
    private void AddIngredient(Ingredient ingredient)
    {
        model.AddIngredient((ingredient));
        var ingredients = model.Ingredients;
        
        if (ingredients.Count < 5)
        {
            return;
        }
        else
        {
            view.OnGotEnoughIngredients();
            dishAnalystPresenter.SetIngredients(ingredients);
            dishAnalystPresenter.AnalyzeDish();
            model.ClearIngredients();
        }
    }
}
