using YumMaya_01.WebAPI.Application.Contracts.Persistence.Repositories;
using YumMaya_01.WebAPI.Domain.Models;

namespace YumMaya_01.WebAPI.Infrastructure.Persistence.Repositories;

internal sealed class RecipeCategoryRepository : GenericRepository<RecipeCategory>, IRecipeCategoryRepository
{
    public RecipeCategoryRepository(AppDbContext context) : base(context)
    {
    }
}