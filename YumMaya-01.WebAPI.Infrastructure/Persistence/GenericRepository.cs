using Microsoft.EntityFrameworkCore;
using YumMaya_01.WebAPI.Application.Contracts.Persistence;

namespace YumMaya_01.WebAPI.Infrastructure.Persistence;

public class GenericRepository<T> : IReadRepository<T>, IWriteRepository<T> where T : class
{
    private readonly AppDbContext _context;

    public GenericRepository(AppDbContext context)
    {
        _context = context;
    }

    public virtual async Task<bool> AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        return await _context.SaveChangesAsync() > 0;
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public virtual async Task<T> GetAsync(Guid id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public virtual async Task<bool> DeleteAsync(Guid id)
    {
        var entity = await _context.Set<T>().FindAsync(id);
        _context.Set<T>().Remove(entity);
        return await _context.SaveChangesAsync() > 0;
    }

    public virtual async Task<bool> UpdateAsync(T entity)
    {
        _context.Set<T>().Update(entity);
        return await _context.SaveChangesAsync() > 0;
    }
}