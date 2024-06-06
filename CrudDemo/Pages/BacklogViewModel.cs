using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CrudDemo.Entities;
using CrudDemo.Shared;
using SQLite;
using System.Collections.ObjectModel;

namespace CrudDemo.Pages
{
    public partial class BacklogViewModel : ObservableObject
    {
        private readonly SqliteConnectionFactory _dbConnectionFactory;

        private readonly ObservableCollection<TicketViewModel> _tickets;
        public IEnumerable<TicketViewModel> Tickets => _tickets;

        [ObservableProperty]
        private string _title = string.Empty;

        [ObservableProperty]
        private int _points = 0;

        public BacklogViewModel(SqliteConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;

            _tickets = new ObservableCollection<TicketViewModel>();

            LoadTicketsCommand.Execute(null);
        }

        [RelayCommand]
        private async Task LoadTickets()
        {
            ISQLiteAsyncConnection database = _dbConnectionFactory.Create();

            List<TicketDto> ticketDtos = await database.Table<TicketDto>().ToListAsync();

            foreach (TicketDto ticketDto in ticketDtos)
            {
                _tickets.Add(CreateTicketViewModel(ticketDto));
            }
        }

        [RelayCommand]
        private async Task CreateTicket()
        {
            ISQLiteAsyncConnection database = _dbConnectionFactory.Create();

            TicketDto newTicketDto = new TicketDto()
            {
                Title = Title,
                Points = Points,
            };

            await database.InsertAsync(newTicketDto);

            _tickets.Add(CreateTicketViewModel(newTicketDto));

            Title = string.Empty;
            Points = 0;
        }

        private async Task HandleTicketSave(TicketViewModel ticket)
        {
            ISQLiteAsyncConnection database = _dbConnectionFactory.Create();

            await database.UpdateAsync(new TicketDto()
            {
                Id = ticket.Id,
                Title = ticket.Title,
                Points = ticket.Points,
            });
        }

        private async Task HandleTicketDelete(TicketViewModel ticket)
        {
            ISQLiteAsyncConnection database = _dbConnectionFactory.Create();

            await database.Table<TicketDto>().DeleteAsync(t => t.Id == ticket.Id);

            _tickets.Remove(ticket);
        }

        private TicketViewModel CreateTicketViewModel(TicketDto dto)
        {
            Ticket ticket = new Ticket(dto.Id, dto.Title!, dto.Points);

            return new TicketViewModel(ticket, HandleTicketSave, HandleTicketDelete);
        }
    }
}
