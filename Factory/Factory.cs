namespace ConsoleApp1;

public enum IngredientType
{
    carrot,
    potato,
    onion,
    Pepper,
    meat
}

public class Factory
{
    private IngredientConfig config;

    public Factory(IngredientConfig config)
    {
        this.config = config;
    }
    
    public Ingredient GetIngredient(int id)
    {
        var ingredient = config.ingredientsConfig.FirstOrDefault(item => item.Id == id);
        return ingredient;
    }
}