namespace ConsoleApp1;

public class PointCounterPresenter
{
    private PointCounterView view;
    private PointCounterModel model;

    public PointCounterPresenter(PointCounterModel model, PointCounterView view)
    {
        this.model = model;
        this.view = view;
        model.OnPointsCounted += OnPointsCounted;
        model.OnBestDishSelected += OnBestDishSelected;
    }

    public void OnPointsCounted(int points, int allPoints, string name)
    {
        view.OnAddedPoints(points, allPoints, name);
    }

    private void OnBestDishSelected(string name, List<Ingredient> dish, int score)
    {
        view.OnBestDishSelected(name, dish, score);
    }
}