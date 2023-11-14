using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ContentViewComponents
{
    public partial class MainPageViewModel : ObservableObject
    {
        [RelayCommand]
        private async Task AddToCart()
        {
            await Shell.Current.DisplayAlert("Success", "Added item to cart!", "Ok");
        }
    }
}
