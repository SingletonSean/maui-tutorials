using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CrudDemo.Entities
{
    public partial class TicketViewModel : ObservableObject
    {
        public int Id { get; }

        public string DisplayId => $"CRUD-{Id}";

        [ObservableProperty]
        private string _title;

        [ObservableProperty]
        private int _points;

        public TicketViewModel(Ticket ticket)
        {
            Id = ticket.Id;
            Title = ticket.Title;
            Points = ticket.Points;
        }

        [RelayCommand]
        private async Task DeleteTicket()
        {

        }
    }
}
