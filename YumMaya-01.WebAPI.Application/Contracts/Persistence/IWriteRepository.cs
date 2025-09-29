namespace YumMaya_01.WebAPI.Application.Contracts.Persistence;

public interface IWriteRepository<T> where T : class
{
    Task<bool> AddAsync(T entity);
    Task<bool> DeleteAsync(Guid id);
    Task<bool> UpdateAsync(T entity);
}
