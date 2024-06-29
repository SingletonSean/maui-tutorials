using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;

namespace StateBinding.Pages
{
    public partial class MainViewModel : INotifyPropertyChanged
    {
		public record MainViewModelState(
			string FirstName = "", 
			string LastName = "", 
			string Occupation = "", 
			string FavoriteColor = "", 
			string FavoriteFood = "",
			string Output = "");

		private MainViewModelState _state = new MainViewModelState();
		public MainViewModelState State
        {
			get
			{
				return _state;
			}
			set
			{
                _state = value;
				OnPropertyChanged(nameof(State));
			}
		}

        [RelayCommand]
		private void Submit()
		{
			State = State with
			{
				Output = $"{State.FirstName} {State.LastName} is a {State.Occupation} who likes {State.FavoriteFood} and the color {State.FavoriteColor}"
			};
		}

		public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
