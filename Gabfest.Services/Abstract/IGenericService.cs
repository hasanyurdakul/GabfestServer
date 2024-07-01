using Gabfest.Data;

namespace Gabfest.Services;

public interface IGenericService<T> where T : class
{
    Task<T> AddAsync(T entity);
    Task<int> CountAsync();
    Task<T> DeleteAsync(T entity);
    Task<IEnumerable<T>> GetAllAsync(PaginationModel paginationModel);
    Task<T> GetByIdAsync(int id);
    Task<T> UpdateAsync(T entity);
}
