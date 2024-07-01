using Gabfest.Data;

namespace Gabfest.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> AddAsync(User entity)
    {
        return await _userRepository.AddAsync(entity);
    }

    public async Task<int> CountAsync()
    {
        return await _userRepository.CountAsync();
    }

    public async Task<User> DeleteAsync(User entity)
    {
        return await _userRepository.DeleteAsync(entity);
    }

    public async Task<IEnumerable<User>> GetAllAsync(PaginationModel paginationModel)
    {
        return await _userRepository.GetAllAsync(paginationModel);
    }

    public async Task<User> GetByIdAsync(int id)
    {
        return await _userRepository.GetByIdAsync(id);
    }

    public async Task<User> UpdateAsync(User entity)
    {
        return await _userRepository.UpdateAsync(entity);
    }
}
