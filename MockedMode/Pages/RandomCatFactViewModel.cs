using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MockedMode.Features.ViewRandomCatFact;

namespace MockedMode.Pages
{
    public partial class RandomCatFactViewModel : ObservableObject
    {
        private readonly IRandomCatFactQuery _randomCatFactQuery;

        [ObservableProperty]
        private string _catFact;

        public RandomCatFactViewModel(IRandomCatFactQuery randomCatFactQuery)
        {
            _randomCatFactQuery = randomCatFactQuery;

            LoadRandomCatFactCommand.Execute(null);
        }

        [RelayCommand]
        private async Task LoadRandomCatFact()
        {
            CatFact catFact = await _randomCatFactQuery.Execute();

            CatFact = catFact.Content;
        }
    }
}
