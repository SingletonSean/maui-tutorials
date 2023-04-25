using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Navigation.Pages.Profile
{
    [QueryProperty(nameof(Address), "address")]
    public partial class AddressViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _address;

        [RelayCommand]
        private async Task Back()
        {
            await Shell.Current.Navigation.PopAsync();
        }
    }
}
