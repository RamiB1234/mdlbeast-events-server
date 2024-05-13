using mdlbeast_events_server.Models.Entities;

namespace mdlbeast_events_server.Models.Repository
{
    public class EFEventRepository : IEventRepository
    {
        private readonly AppDbContext context;

        public EFEventRepository(AppDbContext dbContext)
        {
            this.context = dbContext;
        }

        public List<Event> GetEventList()
        {
            return context.Events.ToList();
        }
    }
}
