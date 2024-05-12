namespace mdlbeast_events_server.Models.Entities
{
    public class Ticket
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public bool Attended { get; set; }
        public DateTime PurchaseDate { get; set; } = DateTime.Now;
    }
}
