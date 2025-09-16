using Microsoft.EntityFrameworkCore;
using YumMaya_01.WebAPI.Application.Contracts.Persistence.Repositories;
using YumMaya_01.WebAPI.Domain.Models;

namespace YumMaya_01.WebAPI.Infrastructure.Persistence.Repositories;

public sealed class RecipeRepository : GenericRepository<Recipe>, IRecipeRepository
{
    private readonly AppDbContext _context;

    public RecipeRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Recipe>> GetAllAsync()
    {
        return await _context.Set<Recipe>()
            .Include(r => r.RecipeTags)
            .ThenInclude(rt => rt.Tag)
            .ToListAsync();
    }

    public override async Task<Recipe> GetAsync(Guid id)
    {
        return await _context.Set<Recipe>()
            .Include(r => r.RecipeTags)
            .ThenInclude(rt => rt.Tag)
            .FirstOrDefaultAsync(r => r.Id == id);
    }
}