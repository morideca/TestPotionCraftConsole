using System.Reflection.Metadata;
using ConsoleApp1.Dishes;

namespace ConsoleApp1;

public class DishAnalyst
{
	public event Action<List<Ingredient>, int, string> OnAnalysisDone;
	
	private RecipeData recipeData;
	
	public DishAnalyst(RecipeData recipeData, PotModel potModel)
	{
		this.recipeData = recipeData;
		
		potModel.OnDishPrepared += AnalyzeDish;
	}

    private void AnalyzeDish(List<Ingredient> ingredients)
    {
	    string dishName = "";
        List<string> ingredientNames = ingredients.Select(ingredient => ingredient.Name).ToList();

        int meatCount = ingredientNames.Count(item => item == "мясо");

        var recipe = new Dictionary<string, int[]>
        {
            { "мясо", [meatCount] }
        };

        dishName = GetDishName(recipe);
        
        var matchedIngredientCount = meatCount;
        if (matchedIngredientCount < 3)
        {
            string ingredientName = "";
            var ingredientCounts = ingredientNames
                .GroupBy(x => x)
                .ToDictionary(group => group.Key, group => group.Count());
            
            var duplicates = ingredientCounts
                .Where(kvp => kvp.Value > 1);

            if (duplicates.Any())
            {
                var ingredientMost = ingredientCounts
                    .OrderByDescending(kvp => kvp.Value)
                    .First();
                matchedIngredientCount = ingredientMost.Value;
                ingredientName = ingredientMost.Key;
            }
            else
            {
                matchedIngredientCount = 1;
            }
            
            recipe = new Dictionary<string, int[]>
            {
                { ingredientName, [matchedIngredientCount] }
            };
            dishName = GetDishName(recipe);
        }
        OnAnalysisDone?.Invoke(ingredients, matchedIngredientCount, dishName);
    }
    
    private string GetDishName(Dictionary<string, int[]> ingredients)
    {
	    var dishes = recipeData.Recipes;

	    var _dishes = dishes.SelectMany(dish => dish.Recipes,
		    (dish, recipe) => new { Name = dish.Name, Recipe = recipe });

	    foreach (var dish in _dishes)
	    {
		    bool areEqual = dish.Recipe.All(kvp => 
			    ingredients.TryGetValue(kvp.Key, out var value) && value.SequenceEqual(kvp.Value));

		    if (areEqual)
		    {
			    return dish.Name;
		    }
	    }
	    return "суп";
    }
}