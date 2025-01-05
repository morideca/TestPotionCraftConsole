namespace ConsoleApp1;

public class IngredientConfig
{
    public (string, int) GetName(IngredientType ingredientType)
    {
        switch(ingredientType)
        {
            case IngredientType.potato:
                return ("картофель", 10);
                break;
            case IngredientType.carrot:
                return ("морковь", 20);
                break;
            case IngredientType.Pepper:
                return ("перец", 30);
                break;
            case IngredientType.onion:
                return ("лук", 40);
                break;
            case IngredientType.meat:
                return ("мясо", 50);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(ingredientType), ingredientType, null);
        }
    }
}