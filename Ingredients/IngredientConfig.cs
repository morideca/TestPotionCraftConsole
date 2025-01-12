using Newtonsoft.Json;

namespace ConsoleApp1;

public class IngredientConfig
{
	public List<Ingredient> ingredientsConfig { get; private set; }

	public IngredientConfig()
	{
		string configJsonPath = 
			"C:\\Users\\User\\RiderProjects\\TestPotions\\ConsoleApp1\\ConsoleApp1\\ingredients\\ingredientsConfig.json";
		ingredientsConfig = JsonConvert.DeserializeObject<List<Ingredient>>(File.ReadAllText(configJsonPath));
	}
}