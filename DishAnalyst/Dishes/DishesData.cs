namespace ConsoleApp1.Dishes;

public class DishesData
{
	public List<Dish> Dishes { get; private set; } = new();

	public DishesData()
	{
		Dishes.Add(new MeatWithGarnish());
		Dishes.Add(new MeatWithMeat());
		Dishes.Add(new OnionSoup());
		Dishes.Add(new SmashedPotato());
		Dishes.Add(new Stew());
		Dishes.Add(new VegetableStew());
	}
}