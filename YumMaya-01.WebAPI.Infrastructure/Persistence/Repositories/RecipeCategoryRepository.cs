using Microsoft.EntityFrameworkCore;
using YumMaya_01.WebAPI.Application.Contracts.Persistence.Repositories;
using YumMaya_01.WebAPI.Domain.Models;

namespace YumMaya_01.WebAPI.Infrastructure.Persistence.Repositories;

internal sealed class RecipeCategoryRepository : GenericRepository<RecipeCategory>, IRecipeCategoryRepository
{
    private readonly AppDbContext _context;

    public RecipeCategoryRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<RecipeCategory>> GetByRecipeIdAsync(Guid recipeId)
    {
        return await _context.Set<RecipeCategory>()
            .Where(rt => rt.RecipeId == recipeId)
            .ToListAsync();
    }

    public async Task<bool> DeleteAsync(Guid categoryId, Guid recipeId)
    {
        return await _context.Set<RecipeCategory>()
            .Where(rt => rt.CategoryId == categoryId && rt.RecipeId == recipeId)
            .ExecuteDeleteAsync() > 0;
    }
}