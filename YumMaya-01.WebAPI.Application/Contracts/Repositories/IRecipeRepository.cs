using YumMaya_01.WebAPI.Domain.Models;

namespace YumMaya_01.WebAPI.Application.Contracts.Repositories;

public interface IRecipeRepository
{
    Task<Recipe> GetByIdAsync(Guid id);
    Task<IEnumerable<Recipe>> GetAllAsync();
    Task<Guid> AddAsync(Recipe recipe);
    Task<bool> UpdateAsync(Recipe recipe);
    Task<bool> DeleteAsync(Recipe recipe);
}