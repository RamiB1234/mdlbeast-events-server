namespace mdlbeast_events_server.Models.Repository
{
    public class EFUserRepository : IUserRepository
    {
        private readonly AppDbContext context;

        public EFUserRepository(AppDbContext dbContext)
        {
            this.context = dbContext;
        }

        public bool ValidateCredentials(string username, string password)
        {
            var user = context.Users.FirstOrDefault(x=> x.Username == username && x.Password == password);
            if (user != null)
                return true;
            
            return false;
        }
    }
}
