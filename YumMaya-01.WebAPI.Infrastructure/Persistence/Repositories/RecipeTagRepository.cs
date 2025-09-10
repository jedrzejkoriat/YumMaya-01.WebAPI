using Microsoft.EntityFrameworkCore;
using YumMaya_01.WebAPI.Application.Contracts.Persistence.Repositories;
using YumMaya_01.WebAPI.Domain.Models;

namespace YumMaya_01.WebAPI.Infrastructure.Persistence.Repositories;

public sealed class RecipeTagRepository : IRecipeTagRepository
{
    private readonly AppDbContext _context;

    public RecipeTagRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<RecipeTag>> GetByRecipeIdAsync(Guid recipeId)
    {
        return await _context.Set<RecipeTag>()
            .Where(rt => rt.RecipeId == recipeId)
            .ToListAsync();
    }

    public async Task<bool> DeleteAsync(Guid tagId, Guid recipeId)
    {
        return await _context.Set<RecipeTag>()
            .Where(rt => rt.TagId == tagId && rt.RecipeId == recipeId)
            .ExecuteDeleteAsync() > 0;
    }

    public async Task<bool> AddAsync(RecipeTag recipeTag)
    {
        await _context.AddAsync(recipeTag);
        return await _context.SaveChangesAsync() > 0;
    }
}