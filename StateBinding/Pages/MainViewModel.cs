using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;

namespace StateBinding.Pages
{
    public partial class MainViewModel : INotifyPropertyChanged
    {
		private string _firstName = string.Empty;
		public string FirstName
		{
			get
			{
				return _firstName;
			}
			set
			{
				_firstName = value;
				OnPropertyChanged(nameof(FirstName));
			}
		}

        private string _lastName = string.Empty;
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

		private string _occupation = string.Empty;
		public string Occupation
		{
			get
			{
				return _occupation;
			}
			set
			{
				_occupation = value;
				OnPropertyChanged(nameof(Occupation));
			}
		}

		private string _favoriteColor = string.Empty;
		public string FavoriteColor
		{
			get
			{
				return _favoriteColor;
			}
			set
			{
				_favoriteColor = value;
				OnPropertyChanged(nameof(FavoriteColor));
			}
		}

		private string _favoriteFood = string.Empty;
		public string FavoriteFood
		{
			get
			{
				return _favoriteFood;
			}
			set
			{
				_favoriteFood = value;
				OnPropertyChanged(nameof(FavoriteFood));
			}
		}

        private string _output = string.Empty;
        public string Output
        {
            get
            {
                return _output;
            }
            set
            {
                _output = value;
                OnPropertyChanged(nameof(Output));
            }
        }

        [RelayCommand]
		private void Submit()
		{
			Output = $"{FirstName} {LastName} is a {Occupation} who likes {FavoriteFood} and the color {FavoriteColor}";
		}

		public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
