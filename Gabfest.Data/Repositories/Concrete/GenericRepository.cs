using Microsoft.EntityFrameworkCore;

namespace Gabfest.Data;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly GabfestDbContext _context;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(GabfestDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<IEnumerable<T>> GetAllAsync(PaginationModel paginationModel)
    {
        if (paginationModel != null)
        {
            return await _dbSet
                .Skip((paginationModel.PageNumber - 1) * paginationModel.PageSize)
                .Take(paginationModel.PageSize)
                .ToListAsync();
        }
        else
        {
            return await _dbSet.Take(10).ToListAsync();
        }
    }

    public async Task<T> AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<T> UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<T> DeleteAsync(T entity)
    {
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<int> CountAsync()
    {
        return await _dbSet.CountAsync();
    }
}
