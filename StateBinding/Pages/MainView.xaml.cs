namespace StateBinding.Pages;

public partial class MainView : ContentPage
{
	public MainView()
	{
		InitializeComponent();

		BindingContext = new MainViewModel();
	}
}