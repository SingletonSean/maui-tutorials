using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CrudDemo.Entities
{
    public partial class TicketViewModel : ObservableObject
    {
        private readonly Func<TicketViewModel, Task> _onDelete;

        public int Id { get; }

        public string DisplayId => $"CRUD-{Id}";

        [ObservableProperty]
        private string _title;

        [ObservableProperty]
        private int _points;

        public TicketViewModel(Ticket ticket, Func<TicketViewModel, Task> onDelete)
        {
            Id = ticket.Id;
            Title = ticket.Title;
            Points = ticket.Points;
            
            _onDelete = onDelete;
        }

        [RelayCommand]
        private async Task DeleteTicket()
        {
            await _onDelete(this);
        }
    }
}
