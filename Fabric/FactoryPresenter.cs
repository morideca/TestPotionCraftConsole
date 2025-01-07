namespace ConsoleApp1;

public enum IngredientType
{
    carrot,
    potato,
    onion,
    Pepper,
    meat
}

public class FactoryPresenter
{
    private FactoryModel model;
    private FactoryView view;

    public void Init(IngredientConfig ingredientsConfig)
    {
        view = new();
        model = new(ingredientsConfig);
    }
    
    public Ingredient GetIngredient(int id)
    {
        var ingredient = model.IngredientConfig.FirstOrDefault(item => item.Id == id);
        view.OnGotIngredient(ingredient);
        return ingredient;
    }
}