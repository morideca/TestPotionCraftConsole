namespace ConsoleApp1;

public class DishAnalystPresenter
{
    DishAnalystModel model;
    DishAnalystView view;
    
    private PointCounterPresenter pointCounterPresenter;

    public void Init(PointCounterPresenter pointCounterPresenter)
    {
        this.pointCounterPresenter = pointCounterPresenter;
        view = new();
        model = new(view);
    }

    public void SetIngredients(List<Ingredient> ingredients)
    {
        model.SetIngredients(ingredients);
    }

    private string GetDishName(Dictionary<string, int[]> ingredients)
    {
        var dishes = model.DishesData.Dishes;

        foreach (var dish in dishes)
        {
            foreach (var recipe in dish.Recipes)
            {
                bool areEqual = recipe.All(kvp => 
                    ingredients.TryGetValue(kvp.Key, out var value) && value.SequenceEqual(kvp.Value));

                if (areEqual)
                {
                    return dish.Name;
                }
            }
        }
        return "суп";
    }

    public void AnalyzeDish()
    {
        List<string> ingredientNames = new();
        string dishName;
        foreach (var ingredient in model.Ingredients)
        {
            ingredientNames.Add(ingredient.Name);
        }
        
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
        view.OnDishPrepared(dishName.ToString());
        pointCounterPresenter.SetAnalysisResult(model.Ingredients, matchedIngredientCount);
        pointCounterPresenter.CountPoints();
    }
}