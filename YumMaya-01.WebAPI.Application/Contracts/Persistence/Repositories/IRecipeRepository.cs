using YumMaya_01.WebAPI.Domain.Models;

namespace YumMaya_01.WebAPI.Application.Contracts.Persistence.Repositories;

public interface IRecipeRepository
{
    Task<Recipe> GetAsync(Guid id);
    Task<IEnumerable<Recipe>> GetAllAsync();
    Task<bool> AddAsync(Recipe recipe);
    Task UpdateAsync(Recipe recipe);
    Task<bool> DeleteAsync(Guid id);
}