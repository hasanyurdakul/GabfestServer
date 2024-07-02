namespace Gabfest.Data;

public interface IUserRepository : IGenericRepository<User>
{
    public Task<User> GetUserByUsernameAndPasswordAsync(string username, string password);
}
