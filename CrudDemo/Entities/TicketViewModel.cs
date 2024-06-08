using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CrudDemo.Entities
{
    public partial class TicketViewModel : ObservableObject
    {
        private readonly Func<TicketViewModel, Task> _onSave;
        private readonly Func<TicketViewModel, Task> _onDelete;

        public int Id { get; }

        public string DisplayId => $"CRUD-{Id}";

        [ObservableProperty]
        private string _title;

        [ObservableProperty]
        private int _points;

        [ObservableProperty]
        private bool _isEditing;

        public TicketViewModel(
            Ticket ticket, 
            Func<TicketViewModel, Task> onSave,
            Func<TicketViewModel, Task> onDelete)
        {
            Id = ticket.Id;
            Title = ticket.Title;
            Points = ticket.Points;
            
            _onSave = onSave;
            _onDelete = onDelete;
        }

        [RelayCommand]
        private void EditTicket()
        {
            IsEditing = true;
        }

        [RelayCommand]
        private async Task SaveTicket()
        {
            IsEditing = false;

            await _onSave(this);
        }

        [RelayCommand]
        private async Task DeleteTicket()
        {
            await _onDelete(this);
        }
    }
}
