﻿
using Microsoft.EntityFrameworkCore;

namespace Gabfest.Data;

public class UserRepository : IUserRepository
{
    private readonly IGenericRepository<User> _genericRepository;
    private readonly GabfestDbContext _context;

    public UserRepository(IGenericRepository<User> genericRepository, GabfestDbContext context)
    {
        _genericRepository = genericRepository;
        _context = context;
    }

    public async Task<User> AddAsync(User entity)
    {
        return await _genericRepository.AddAsync(entity);
    }

    public async Task<int> CountAsync()
    {
        return await _genericRepository.CountAsync();
    }

    public async Task<User> DeleteAsync(User entity)
    {
        return await _genericRepository.DeleteAsync(entity);
    }

    public async Task<IEnumerable<User>> GetAllAsync(PaginationModel paginationModel)
    {
        return await _genericRepository.GetAllAsync(paginationModel);
    }

    public async Task<User> GetByIdAsync(int id)
    {
        return await _genericRepository.GetByIdAsync(id);
    }

    public async Task<User> UpdateAsync(User entity)
    {
        return await _genericRepository.UpdateAsync(entity);
    }

    public async Task<User> GetUserByUsernameAndPasswordAsync(string username, string password)
    {
        return await _context.Users.FirstOrDefaultAsync(x => x.Username == username && x.Password == password);
    }

}
