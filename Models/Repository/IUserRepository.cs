namespace mdlbeast_events_server.Models.Repository
{
    public interface IUserRepository
    {
        bool ValidateCredentials(string username, string password);
    }
}
