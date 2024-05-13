using mdlbeast_events_server.Models.Entities;

namespace mdlbeast_events_server.Models.Repository
{
    public interface ITicketRepository
    {
        void SaveTicket(Ticket ticket);
    }
}
