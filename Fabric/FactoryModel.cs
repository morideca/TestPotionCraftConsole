namespace ConsoleApp1;

public class FactoryModel
{
	private IngredientConfig config;

	public List<Ingredient> IngredientConfig => config.ingredientsConfig;
    
	public FactoryModel(IngredientConfig config)
	{
		this.config = config;
	}
}