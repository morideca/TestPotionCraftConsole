namespace ConsoleApp1;

public class Pot
{
    private Model model;
    private View view;
    private DishAnalyst dishAnalyst;

    public Pot(Model model, View view, DishAnalyst dishAnalyst)
    {
        this.model = model;
        this.view = view;
        this.dishAnalyst = dishAnalyst;
    }
    
    public void AddIngredient(Ingredient ingredient)
    {
        model.AddIngredient((ingredient));
        var ingredients = model.Ingredients;
        
        if (ingredients.Count < 5)
        {
            view.AskForIngredient();
        }
        else
        {
            view.OnGoEnoughIngredients();
            dishAnalyst.AnalyzeDish(ingredients);
        }
    }
}