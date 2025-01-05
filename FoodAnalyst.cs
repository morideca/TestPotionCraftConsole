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

public class FoodAnalyst : IDisposable
{
    public event Action<List<Ingredient>, int> OnFoodAnalyzed;
    
    private Pot pot;
    private DishType dishName;
    
    public FoodAnalyst(Pot pot)
    {
        this.pot = pot;
        pot.OnDishPrepared += AnalyzeDish;
    }
    
    public void Dispose()
    {
        pot.OnDishPrepared -= AnalyzeDish;
    }

    private void AnalyzeDish(List<Ingredient> ingredients)
    {
        List<string> ingredientNames = new List<string>();
        foreach (var ingredient in ingredients)
        {
            ingredientNames.Add(ingredient.Name);
        }

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
        
        Console.WriteLine($"Получилось! Мы приготовили {dishName}!");
        OnFoodAnalyzed?.Invoke(ingredients, ingredientCount);
    }
}