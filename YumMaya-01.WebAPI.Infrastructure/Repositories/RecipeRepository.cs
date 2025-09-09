using Microsoft.EntityFrameworkCore;
using YumMaya_01.WebAPI.Application.Contracts.Repositories;
using YumMaya_01.WebAPI.Domain.Models;

namespace YumMaya_01.WebAPI.Infrastructure.Repositories;

public sealed class RecipeRepository : IRecipeRepository
{
    private readonly AppDbContext _context;

    public RecipeRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> AddAsync(Recipe recipe)
    {
        await _context.AddAsync(recipe);
        await _context.SaveChangesAsync();
        return recipe.Id;
    }

    public async Task<IEnumerable<Recipe>> GetAllAsync()
    {
        return await _context.Set<Recipe>()
            .Include(r => r.RecipeTags)
            .ThenInclude(rt => rt.Tag)
            .ToListAsync();
    }

    public async Task<Recipe> GetByIdAsync(Guid id)
    {
        return await _context.Set<Recipe>()
            .Include(r => r.RecipeTags)
            .ThenInclude(rt => rt.Tag)
            .FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<bool> UpdateAsync(Recipe recipe)
    {
        _context.Update(recipe);
        return await _context.SaveChangesAsync() > 0;
    }

    public Task<bool> DeleteAsync(Recipe recipe)
    {
        _context.Remove(recipe);
        return Task.FromResult(_context.SaveChanges() > 0);
    }
}