namespace mdlbeast_events_server.Models.Entities
{
    public class Event
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Date { get; set; }
        public string? Location { get; set; }
        public string? Description { get; set; }
    }
}
