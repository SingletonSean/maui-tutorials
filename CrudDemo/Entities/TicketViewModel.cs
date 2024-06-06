using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CrudDemo.Entities
{
    public partial class TicketViewModel : ObservableObject
    {
        private readonly Action<TicketViewModel> _onSave;
        private readonly Action<TicketViewModel> _onDelete;

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
            Action<TicketViewModel> onSave, 
            Action<TicketViewModel> onDelete)
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
        private void SaveTicket()
        {
            IsEditing = false;
            _onSave(this);
        }

        [RelayCommand]
        private void DeleteTicket()
        {
            _onDelete(this);
        }
    }
}
