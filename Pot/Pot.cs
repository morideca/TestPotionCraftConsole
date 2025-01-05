namespace ConsoleApp1;

public class Pot
{
    public event Action<List<Ingredient>> OnDishPrepared;
    public List<Ingredient> Ingredients { get; private set; }= [];
    
    public void AddIngredient(Ingredient ingredient)
    {
        Ingredients.Add(ingredient);
        
        List<string> ingredientNames = new();
        foreach (var _ingredient in Ingredients)
        {
            ingredientNames.Add(_ingredient.Name);
        }
        
        Console.WriteLine($"Вы добавили {ingredient.Name}!");

        if (Ingredients.Count < 5)
        {
            Console.WriteLine($"Текущие ингредиенты в кастрюле:");
            foreach (var _ingredient in ingredientNames)
            {
                Console.WriteLine($" {_ingredient},");
            }
        }
        else
        {
            Console.WriteLine("Что ж, этого хватит. Готовлю блюдо...");
            OnDishPrepared?.Invoke(Ingredients);
            Ingredients.Clear();
        }
    }
}