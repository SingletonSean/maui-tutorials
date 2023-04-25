using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Navigation.Pages.Profile
{
    [QueryProperty(nameof(IsNew), "new")]
    [QueryProperty(nameof(Profile), "profile")]
    public partial class IndexViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool _isNew;

        [ObservableProperty]
        private Entities.Profile _profile;

        public string Greeting => IsNew
            ? $"Welcome, {Profile?.Name}!" 
            : $"Hello, {Profile?.Name}!";

        [RelayCommand]
        private async Task ViewAddress()
        {
            await Shell.Current.GoToAsync($"address?address={Profile.Address}");
        }

        partial void OnIsNewChanged(bool value)
        {
            OnPropertyChanged(nameof(Greeting));
        }

        partial void OnProfileChanged(Entities.Profile value)
        {
            OnPropertyChanged(nameof(Greeting));
        }
    }
}
