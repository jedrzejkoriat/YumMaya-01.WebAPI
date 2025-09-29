namespace YumMaya_01.WebAPI.Application.Contracts.Persistence;

public interface IReadRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetAsync(Guid id);
}
