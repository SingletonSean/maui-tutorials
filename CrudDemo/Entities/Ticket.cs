namespace CrudDemo.Entities
{
    public class Ticket
    {
        public string Id { get; }
        public string Title { get; }
        public int Points { get; }

        public Ticket(string id, string title, int points)
        {
            Id = id;
            Title = title;
            Points = points;
        }
    }
}
