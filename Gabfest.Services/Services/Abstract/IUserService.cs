using Gabfest.Data;

namespace Gabfest.Services;

public interface IUserService : IGenericService<User>
{
    public Task<User> GetUserByUsernameAndPasswordAsync(string username, string password);
}
