namespace ConsoleApp1;

public enum DishType
{
    vegetableStew,
    stew,
    meatWithGarnish,
    soup,
    onionSoup,
    mashedPotatoes,
    meat
}

public class DishAnalyst
{
    private DishType dishName;
    private View view;
    private Model model;
    private PointCounter pointCounter;

    public DishAnalyst(View view, Model model, PointCounter pointCounter)
    {
        this.view = view;
        this.model = model;
        this.pointCounter = pointCounter;
    }

    public void AnalyzeDish(List<Ingredient> ingredients)
    {
        List<string> ingredientNames = model.IngredientNames;
        
        int meatCount = ingredientNames.Count(item => item == "мясо");

        dishName = meatCount switch
        {
            0 => DishType.vegetableStew,
            2 or 3 => DishType.stew,
            4 => DishType.meatWithGarnish,
            5 => DishType.meat,
            _ => dishName
        };
        
        var ingredientCount = meatCount;

        if (ingredientCount < 3)
        {
            var ingredientGroup = ingredientNames.GroupBy(x => x);
            ingredientCount = ingredientGroup.Count();
            string ingredientName = ingredientGroup.First().Key;
            bool HaveFourOrFiveIngredients = ingredientGroup
                .Any(x => x.Count() >= 4);

            if (HaveFourOrFiveIngredients)
            {
                dishName = ingredientName switch
                {
                    ("лук") => DishType.onionSoup,
                    ("картофель") => DishType.mashedPotatoes,
                    _ => dishName = DishType.soup
                };
            }
        }
        view.OnDishPrepared(dishName.ToString());
        pointCounter.CountPoints(ingredients, ingredientCount);
    }
}