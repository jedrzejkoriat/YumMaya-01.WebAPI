using YumMaya_01.WebAPI.Domain.Models;

namespace YumMaya_01.WebAPI.Application.Contracts.Persistence.Repositories;

public interface IRecipeCategoryRepository : IReadRepository<RecipeCategory>, IWriteRepository<RecipeCategory>
{
    Task<IEnumerable<RecipeCategory>> GetByRecipeIdAsync(Guid recipeId);
    Task<bool> DeleteAsync(Guid categoryId, Guid recipeId);
}
