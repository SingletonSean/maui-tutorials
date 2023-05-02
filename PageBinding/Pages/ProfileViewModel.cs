using CommunityToolkit.Mvvm.ComponentModel;
using PageBinding.Entities;

namespace PageBinding.Pages
{
    public partial class ProfileViewModel : ObservableObject
    {
        private readonly Profile _profile;

        public string Name => _profile.Name;

        public string Address => _profile.Address;

        public ProfileViewModel(Profile profile)
        {
            _profile = profile;
        }
    }
}
