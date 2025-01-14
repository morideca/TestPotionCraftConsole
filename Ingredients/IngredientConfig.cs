using Newtonsoft.Json;

namespace ConsoleApp1;

public class IngredientConfig
{
	private List<Ingredient> ingredientsConfig;

	public IngredientConfig()
	{
		Init();
	}

	public Ingredient GetIngredient(int id)
	{
		var ingredient = ingredientsConfig.FirstOrDefault(item => item.Id == id);
		return ingredient;
	}
	
	private void Init()
	{
		string configJsonPath = 
			"Ingredients/ingredientsConfig.json";
		ingredientsConfig = JsonConvert.DeserializeObject<List<Ingredient>>(File.ReadAllText(configJsonPath));
	}
	
}