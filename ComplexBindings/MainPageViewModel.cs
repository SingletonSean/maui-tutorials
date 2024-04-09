using CommunityToolkit.Mvvm.ComponentModel;

namespace ComplexBindings
{
    public partial class MainPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private double _yourScore = 100;
    }
}
