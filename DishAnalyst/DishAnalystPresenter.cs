namespace ConsoleApp1;

public class DishAnalystPresenter
{
    DishAnalystModel model;
    DishAnalystView view;
    
    private PointCounterPresenter pointCounterPresenter;

    public void Init(DishAnalystModel model, DishAnalystView view, PointCounterPresenter pointCounterPresenter)
    {
        this.pointCounterPresenter = pointCounterPresenter;
        this.view = view;
        this.model = model;
    }

    public void SetIngredients(List<Ingredient> ingredients)
    {
        model.SetIngredients(ingredients);
    }

    private string GetDishName(Dictionary<string, int[]> ingredients)
    {
        var dishes = model.DishesData.Dishes;

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

        model.DishName = dishName;
        view.OnDishPrepared(model.DishName);
        pointCounterPresenter.SetAnalysisResult(model.Ingredients, matchedIngredientCount);
        pointCounterPresenter.CountPoints();
    }

    public void ShowInfo()
    {
        view.Show(model.DishName);
    }
}