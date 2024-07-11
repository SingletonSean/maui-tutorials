using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CrudDemo.Entities;
using CrudDemo.Features.DeleteTicket;
using CrudDemo.Shared;
using SQLite;
using System.Collections.ObjectModel;

namespace CrudDemo.Pages
{
    public partial class BacklogViewModel : ObservableObject
    {
        private readonly SqliteConnectionFactory _connectionFactory;
        private readonly DeleteTicketMutation _deleteTicketMutation;

        private readonly ObservableCollection<TicketViewModel> _tickets;
        public IEnumerable<TicketViewModel> Tickets => _tickets;

        [ObservableProperty]
        private string _title = string.Empty;

        [ObservableProperty]
        private int _points = 0;

        public BacklogViewModel(SqliteConnectionFactory connectionFactory, DeleteTicketMutation deleteTicketMutation)
        {
            _tickets = new ObservableCollection<TicketViewModel>();

            _connectionFactory = connectionFactory;
            _deleteTicketMutation = deleteTicketMutation;

            LoadTicketsCommand.Execute(null);
        }

        [RelayCommand]
        private async Task LoadTickets()
        {
            ISQLiteAsyncConnection database = _connectionFactory.CreateConnection();

            List<TicketDto> ticketDtos = await database.Table<TicketDto>().ToListAsync();

            foreach (TicketDto dto in ticketDtos)
            {
                _tickets.Add(new TicketViewModel(new Ticket(dto.Id, dto.Title ?? string.Empty, dto.Points)));
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

            _tickets.Add(new TicketViewModel(new Ticket(ticketDto.Id, ticketDto.Title, ticketDto.Points)));

            Title = string.Empty;
            Points = 0;
        }
    }
}
