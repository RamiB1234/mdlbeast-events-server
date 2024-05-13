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
            ticket.TicketNumber = GenerateTicketNumber();

            context.Tickets.Add(ticket);
            context.SaveChanges();
        }

        string GenerateTicketNumber()
        {
            Random generator = new Random();
            return generator.Next(0, 1000000).ToString("D6");
        }

        public List<Ticket> GetTicketList() 
        {
            return context.Tickets.ToList();
        }
    }
}
