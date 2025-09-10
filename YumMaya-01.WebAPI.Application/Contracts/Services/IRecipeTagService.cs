namespace YumMaya_01.WebAPI.Application.Contracts.Services;

public interface IRecipeTagService
{
    Task SyncRecipeTagsAsync(Guid recipeId, IEnumerable<Guid> tagIds);
}