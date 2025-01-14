namespace ConsoleApp1;

public class UserInput
{
	private PotModel potModel;
	private IngredientConfig ingredientConfig;
	
	public UserInput(PotModel potModel, IngredientConfig ingredientConfig, PointCounterModel pointCounterModel)
	{
		this.potModel = potModel;
		this.ingredientConfig = ingredientConfig;
		potModel.OnAskedForIngredientAgain += AskForIngredient;
		pointCounterModel.OnFinished += AskForIngredient;
	}

	public void AskForIngredient()
	{
		string answer = Console.ReadLine();
		OnChoiceIngredient(answer);
	}
	
	private void OnChoiceIngredient(string answer)
	{
		if (int.TryParse(answer, out int index) && index is >= 1 and <= 5)
		{
			var ingredient = ingredientConfig.GetIngredient(index);
			potModel.AddIngredient(ingredient);
		}
		else AskForIngredient();
	}
}