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

        public bool ScanTicket(string ticketNumber)
        {
            var ticket = context.Tickets.FirstOrDefault(x => x.TicketNumber == ticketNumber);

            // If ticket is not found or already scanned, return false:

            if(ticket == null || ticket.Attended) 
            {
                return false;
            }

            ticket.Attended = true;
            context.SaveChanges();
            return true;
        }
    }
}
