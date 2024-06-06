using SQLite;

namespace CrudDemo.Entities
{
    public class TicketDto
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }
        public string? Title { get; set; }
        public int Points { get; set; }
    }
}
