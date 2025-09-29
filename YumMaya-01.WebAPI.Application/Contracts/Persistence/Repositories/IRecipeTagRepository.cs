using YumMaya_01.WebAPI.Domain.Models;

namespace YumMaya_01.WebAPI.Application.Contracts.Persistence.Repositories;

public interface IRecipeTagRepository : IReadRepository<RecipeTag>, IWriteRepository<RecipeTag>
{
    Task<IEnumerable<RecipeTag>> GetByRecipeIdAsync(Guid recipeId);
    Task<bool> DeleteAsync(Guid tagId, Guid recipeId);
}