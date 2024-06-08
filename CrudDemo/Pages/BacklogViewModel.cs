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
        private readonly SqliteConnectionFactory _connectionFactory;

        private readonly ObservableCollection<TicketViewModel> _tickets;
        public IEnumerable<TicketViewModel> Tickets => _tickets;

        [ObservableProperty]
        private string _title = string.Empty;

        [ObservableProperty]
        private int _points = 0;

        public BacklogViewModel(SqliteConnectionFactory connectionFactory)
        {
            _tickets = new ObservableCollection<TicketViewModel>();

            _connectionFactory = connectionFactory;

            LoadTicketsCommand.Execute(null);
        }

        [RelayCommand]
        private async Task LoadTickets()
        {
            ISQLiteAsyncConnection database = _connectionFactory.CreateConnection();

            List<TicketDto> ticketDtos = await database.Table<TicketDto>().ToListAsync();

            foreach (TicketDto dto in ticketDtos)
            {
                _tickets.Add(
                    new TicketViewModel(new Ticket(dto.Id, dto.Title ?? string.Empty, dto.Points),
                    HandleTicketSave, 
                    HandleTicketDelete));
            }
        }

        [RelayCommand]
        private async Task CreateTicket()
        {
            ISQLiteAsyncConnection database = _connectionFactory.CreateConnection();

            TicketDto ticketDto = new TicketDto()
            {
                Title = Title,
                Points = Points
            };

            await database.InsertAsync(ticketDto);

            _tickets.Add(
                new TicketViewModel(
                    new Ticket(ticketDto.Id, ticketDto.Title, ticketDto.Points),
                    HandleTicketSave,
                    HandleTicketDelete));

            Title = string.Empty;
            Points = 0;
        }

        private async Task HandleTicketSave(TicketViewModel ticket)
        {
            ISQLiteAsyncConnection database = _connectionFactory.CreateConnection();

            TicketDto ticketDto = new TicketDto()
            {
                Id = ticket.Id,
                Title = ticket.Title,
                Points = ticket.Points
            };

            await database.UpdateAsync(ticketDto);
        }

        private async Task HandleTicketDelete(TicketViewModel ticket)
        {
            ISQLiteAsyncConnection database = _connectionFactory.CreateConnection();

            TicketDto ticketDto = new TicketDto()
            {
                Id = ticket.Id,
                Title = ticket.Title,
                Points = ticket.Points
            };

            await database.DeleteAsync(ticketDto);

            _tickets.Remove(ticket);
        }
    }
}
