
namespace Gabfest.Data;

public class MessageRepository : IMessageRepository
{
    private readonly IGenericRepository<Message> _genericRepository;

    public MessageRepository(IGenericRepository<Message> genericRepository)
    {
        _genericRepository = genericRepository;
    }

    public async Task<Message> AddAsync(Message entity)
    {
        return await _genericRepository.AddAsync(entity);
    }

    public async Task<int> CountAsync()
    {
        return await _genericRepository.CountAsync();
    }

    public async Task<Message> DeleteAsync(Message entity)
    {
        return await _genericRepository.DeleteAsync(entity);
    }

    public async Task<IEnumerable<Message>> GetAllAsync(PaginationModel paginationModel)
    {
        return await _genericRepository.GetAllAsync(paginationModel);
    }

    public async Task<Message> GetByIdAsync(int id)
    {
        return await _genericRepository.GetByIdAsync(id);
    }

    public async Task<Message> UpdateAsync(Message entity)
    {
        return await _genericRepository.UpdateAsync(entity);
    }
}
