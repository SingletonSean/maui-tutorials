namespace CrudDemo.Pages;

public partial class BacklogView : ContentPage
{
	public BacklogView(BacklogViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}