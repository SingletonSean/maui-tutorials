using CrudDemo.Entities;
using CrudDemo.Shared;
using SQLite;

namespace CrudDemo.Features.DeleteTicket
{
    public class DeleteTicketMutation
    {
        private readonly SqliteConnectionFactory _connectionFactory;

        public DeleteTicketMutation(SqliteConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task Execute(Ticket ticket)
        {
            ISQLiteAsyncConnection database = _connectionFactory.CreateConnection();

            TicketDto ticketDto = new TicketDto()
            {
                Id = ticket.Id,
                Title = ticket.Title,
                Points = ticket.Points
            };

            await database.DeleteAsync(ticketDto);
        }
    }
}
