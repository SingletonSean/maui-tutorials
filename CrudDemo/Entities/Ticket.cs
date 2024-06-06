namespace CrudDemo.Entities
{
    public class Ticket
    {
        public int Id { get; }
        public string Title { get; }
        public int Points { get; }

        public Ticket(int id, string title, int points)
        {
            Id = id;
            Title = title;
            Points = points;
        }
    }
}
