using ConsoleApp1.Dishes;

namespace ConsoleApp1;

public class DishAnalystPresenter
{
    private DishAnalystModel model;
    private DishAnalystView view;
    private DishesData dishesData;
    
    private PointCounterPresenter pointCounterPresenter;

    public void Init(DishAnalystModel model, DishAnalystView view, PointCounterPresenter pointCounterPresenter, DishesData dishesData)
    {
        this.pointCounterPresenter = pointCounterPresenter;
        this.view = view;
        this.model = model;
        this.dishesData = dishesData;
        
        model.OnLastDishChanged += OnLastDishChanged;
    }

    public void SetIngredients(List<Ingredient> ingredients)
    {
        model.SetIngredients(ingredients);
    }

    private string GetDishName(Dictionary<string, int[]> ingredients)
    {
        var dishes = dishesData.Dishes;

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

        model.SetDishName(dishName);
        pointCounterPresenter.SetAnalysisResult(model.Ingredients, matchedIngredientCount);
        pointCounterPresenter.CountPoints();
    }

    private void OnLastDishChanged(string name)
    {
        view.OnLastDishChanged(name);
    }
}