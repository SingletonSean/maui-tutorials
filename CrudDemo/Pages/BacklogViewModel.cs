using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CrudDemo.Entities;
using System.Collections.ObjectModel;

namespace CrudDemo.Pages
{
    public partial class BacklogViewModel : ObservableObject
    {
        private readonly ObservableCollection<TicketViewModel> _tickets;
        public IEnumerable<TicketViewModel> Tickets => _tickets;

        [ObservableProperty]
        private string _title = string.Empty;

        [ObservableProperty]
        private int _points = 0;

        public BacklogViewModel()
        {
            _tickets = new ObservableCollection<TicketViewModel>()
            {
                new TicketViewModel(
                    new Ticket(1, "Setup database query", 1),
                    HandleTicketSave,
                    HandleTicketDelete)
            };
        }

        [RelayCommand]
        private void CreateTicket()
        {
            _tickets.Add(
                new TicketViewModel(
                    new Ticket(1, Title, Points),
                    HandleTicketSave,
                    HandleTicketDelete));

            Title = string.Empty;
            Points = 0;
        }

        private void HandleTicketSave(TicketViewModel ticket)
        {
            
        }

        private void HandleTicketDelete(TicketViewModel ticket)
        {
            _tickets.Remove(ticket);
        }
    }
}
