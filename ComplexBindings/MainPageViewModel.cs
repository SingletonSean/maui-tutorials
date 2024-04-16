using CommunityToolkit.Mvvm.ComponentModel;

namespace ComplexBindings
{
    public partial class MainPageViewModel : ObservableObject
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsGood))]
        [NotifyPropertyChangedFor(nameof(IsMedium))]
        [NotifyPropertyChangedFor(nameof(IsBad))]
        private double _yourScore = 100;

        public bool IsGood => YourScore > 75;
        public bool IsMedium => !IsGood && !IsBad;
        public bool IsBad => YourScore < 25;
    }
}
