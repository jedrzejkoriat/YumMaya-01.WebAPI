namespace YumMaya_01.WebAPI.Application.Contracts.Persistence;

public interface IGenericRepository<T> where T : class
{
    Task<bool> AddAsync(T entity);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetAsync(Guid id);
    Task<bool> DeleteAsync(Guid id);
    Task<bool> UpdateAsync(T entity);
}
