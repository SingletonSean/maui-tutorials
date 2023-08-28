namespace Navigation.Pages;

public partial class LandingView : ContentPage
{
	public LandingView()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		await Shell.Current.GoToAsync("//join");
    }
}