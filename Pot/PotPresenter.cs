namespace ConsoleApp1;

public class PotPresenter
{
    public event Action onWrongIngredientAdded;
    public event Action OnLeftFreeSpace;

    private IngredientConfig config;
    private DishAnalystPresenter dishAnalystPresenter;
    private PotModel model;
    private PotView view;
    private FactoryPresenter factoryPresenter;

    public void Init(PotView view, PotModel model, IngredientConfig config, FactoryPresenter factoryPresenter, DishAnalystPresenter dishAnalystPresenter)
    {
        this.factoryPresenter = factoryPresenter;
        this.factoryPresenter = factoryPresenter;
        this.dishAnalystPresenter = dishAnalystPresenter;
        this.view = view;
        this.model = model;
        this.config = config;
        model.OnIngredientAdded += OnIngredientAdded;
    }

    public void Start()
    {
        AskForIngredient();
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
            onWrongIngredientAdded?.Invoke();
        }
    }
    
    private void OnIngredientAdded(Ingredient ingredient, List<Ingredient> ingredients)
    {
        var ingredientNames = ingredients.Select(x => x.Name).ToList();
        view.OnIngredientAdded(ingredient.Name, ingredientNames);
    }
    
    private void AskForIngredient()
    {
        view.AskForIngredient(config.ingredientsConfig);
    }
    
    private void AddIngredient(Ingredient ingredient)
    {
        model.AddIngredient((ingredient));
        var ingredients = model.Ingredients;
        
        if (ingredients.Count < 5)
        {
            OnLeftFreeSpace?.Invoke();
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
