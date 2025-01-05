namespace ConsoleApp1;

public class PointCounter
{
    private int points;
    private FoodAnalyst foodAnalyst;
    
    public PointCounter(FoodAnalyst foodAnalyst)
    {
        this.foodAnalyst = foodAnalyst;
        foodAnalyst.OnFoodAnalyzed += CountPoints;
    }

    private void CountPoints(List<Ingredient> ingredients, int ingredientCount)
    {
        int newPoints = 0;
        float multiplier = 0;
        
        foreach (var ingredient in ingredients)
        {
            newPoints += ingredient.Value;
        }

        multiplier = ingredientCount switch
        {
            1 => 2,
            2 => 2,
            3 => 1.5f,
            4 => 1.25f,
            5 => 1,
            _ => multiplier
        };
        
        newPoints = (int)Math.Round(newPoints * multiplier);
        Console.WriteLine($"Круто получилось! Ты заработал {newPoints} очков!");
        AddPoints(newPoints);
    }

    public void AddPoints(int points)   
    {
        this.points += points;
        Console.WriteLine($"Текущие очки: {this.points}");
    }

    public void PrintPoints()
    {
        Console.WriteLine(points);
    }
}