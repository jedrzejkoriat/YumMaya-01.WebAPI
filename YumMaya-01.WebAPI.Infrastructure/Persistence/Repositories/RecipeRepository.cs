using Microsoft.EntityFrameworkCore;
using YumMaya_01.WebAPI.Application.Contracts.Persistence.Repositories;
using YumMaya_01.WebAPI.Domain.Models;
using YumMaya_01.WebAPI.Infrastructure.Persistence;

namespace YumMaya_01.WebAPI.Infrastructure.Persistence.Repositories;

public sealed class RecipeRepository : IRecipeRepository
{
    private readonly AppDbContext _context;

    public RecipeRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> AddAsync(Recipe recipe)
    {
        await _context.AddAsync(recipe);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<IEnumerable<Recipe>> GetAllAsync()
    {
        return await _context.Set<Recipe>()
            .Include(r => r.RecipeTags)
            .ThenInclude(rt => rt.Tag)
            .ToListAsync();
    }

    public async Task<Recipe> GetAsync(Guid id)
    {
        return await _context.Set<Recipe>()
            .Include(r => r.RecipeTags)
            .ThenInclude(rt => rt.Tag)
            .FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task UpdateAsync(Recipe recipe)
    {
        _context.Update(recipe);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var recipe = await _context.Set<Recipe>().FirstOrDefaultAsync(r => r.Id == id);
        _context.Set<Recipe>().Remove(recipe);
        return await _context.SaveChangesAsync() > 0;
    }
}