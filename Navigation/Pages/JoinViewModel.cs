using CommunityToolkit.Mvvm.ComponentModel;

namespace Navigation.Pages
{
    public partial class JoinViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _name;

        [ObservableProperty]
        private string _address;

        [ObservableProperty]
        private string _occupation;
    }
}
