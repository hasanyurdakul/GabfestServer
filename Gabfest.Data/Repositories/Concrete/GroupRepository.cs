
namespace Gabfest.Data;

public class GroupRepository : IGroupRepository
{
    private readonly IGenericRepository<Group> _genericRepository;

    public GroupRepository(IGenericRepository<Group> genericRepository)
    {
        _genericRepository = genericRepository;
    }

    public async Task<Group> AddAsync(Group entity)
    {
        return await _genericRepository.AddAsync(entity);
    }

    public async Task<int> CountAsync()
    {
        return await _genericRepository.CountAsync();
    }

    public async Task<Group> DeleteAsync(Group entity)
    {
        return await _genericRepository.DeleteAsync(entity);
    }

    public async Task<IEnumerable<Group>> GetAllAsync(PaginationModel paginationModel)
    {
        return await _genericRepository.GetAllAsync(paginationModel);
    }

    public async Task<Group> GetByIdAsync(int id)
    {
        return await _genericRepository.GetByIdAsync(id);
    }

    public async Task<Group> UpdateAsync(Group entity)
    {
        return await _genericRepository.UpdateAsync(entity);
    }
}
