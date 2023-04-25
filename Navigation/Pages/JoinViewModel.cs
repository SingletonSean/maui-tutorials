using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Navigation.Pages
{
    public partial class JoinViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _name = "SingletonSean";

        [ObservableProperty]
        private string _address = "123 Main St";

        [RelayCommand]
        private async Task Submit()
        {

        }
    }
}
