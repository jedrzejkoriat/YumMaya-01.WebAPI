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

    public async Task<bool> UpdateAsync(Recipe recipe)
    {
        _context.Update(recipe);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var recipe = await _context.Set<Recipe>().FirstOrDefaultAsync(r => r.Id == id);
        _context.Set<Recipe>().Remove(recipe);
        return await _context.SaveChangesAsync() > 0;
    }
}