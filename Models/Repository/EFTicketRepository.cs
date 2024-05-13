using mdlbeast_events_server.Models.Entities;

namespace mdlbeast_events_server.Models.Repository
{
    public class EFTicketRepository : ITicketRepository
    {
        private readonly AppDbContext context;

        public EFTicketRepository(AppDbContext dbContext)
        {
            this.context = dbContext;
        }

        public void SaveTicket(Ticket ticket)
        {
            // To-do: Generate unique ticket no

            context.Tickets.Add(ticket);
            context.SaveChanges();
        }
    }
}
