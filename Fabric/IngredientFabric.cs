namespace ConsoleApp1;

public enum IngredientType
{
    carrot,
    potato,
    onion,
    Pepper,
    meat,
    none
}

public class IngredientFabric
{
    private IngredientConfig ingredientConfig;

    public IngredientFabric(IngredientConfig ingredientConfig)
    {
        this.ingredientConfig = ingredientConfig;
    }
    
    public Ingredient GetIngredient(IngredientType ingredientType)
    {
        var config = ingredientConfig.GetConfig(ingredientType);
        string name = config.Item1;
        int amount = config.Item2;
        return new Ingredient(name, amount);
           
    }
}