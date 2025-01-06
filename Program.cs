namespace ConsoleApp1;

class Program
{
	private static Model model;
	private static View view;
	private static Presenter presenter;
	
	 static void Main()
	 {
		 view = new();
		 model = new(view);
		 presenter = new(model, view);
		 view.Init(presenter);
	 }
}