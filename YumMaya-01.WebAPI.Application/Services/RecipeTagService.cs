using Microsoft.Extensions.Logging;
using YumMaya_01.WebAPI.Application.Contracts.Persistence.Repositories;
using YumMaya_01.WebAPI.Application.Contracts.Services;
using YumMaya_01.WebAPI.Domain.Models;

namespace YumMaya_01.WebAPI.Application.Services;

public sealed class RecipeTagService : IRecipeTagService
{
    private readonly IRecipeTagRepository _recipeTagRepository;
    private readonly ILogger<RecipeTagService> _logger;

    public RecipeTagService(
        IRecipeTagRepository recipeTagRepository,
        ILogger<RecipeTagService> logger)
    {
        _recipeTagRepository = recipeTagRepository;
        _logger = logger;
    }

    public async Task SyncRecipeTagsAsync(Guid recipeId, IEnumerable<Guid> newTagIds)
    {
        _logger.LogInformation("Sync RecipeTags called: {RecipeId}", recipeId);

        var exsistingTagIds = (await _recipeTagRepository.GetByRecipeIdAsync(recipeId)).Select(rt => rt.TagId).ToList();

        var toAddIds = newTagIds.Except(exsistingTagIds);
        var toRemoveIds = exsistingTagIds.Except(newTagIds);

        foreach (var tagId in toAddIds)
        {
            var recipeTag = new RecipeTag { RecipeId = recipeId, TagId = tagId };
            if (!await _recipeTagRepository.AddAsync(recipeTag))
            {
                _logger.LogError("Create RecipeTag failed: {RecipeId}, {TagId}", recipeId, tagId);
                throw new Exception("Create RecipeTag failed.");
            }

            _logger.LogInformation("Create RecipeTag successful: {RecipeId}, {TagId}", recipeId, tagId);
        }

        foreach (var tagId in toRemoveIds)
        {
            if (!await _recipeTagRepository.DeleteAsync(tagId, recipeId))
            {
                _logger.LogError("Delete RecipeTag failed: {RecipeId}, {TagId}", recipeId, tagId);
                throw new Exception("Delete RecipeTag failed.");
            }

            _logger.LogInformation("Delete RecipeTag successful: {RecipeId}, {TagId}", recipeId, tagId);
        }

        _logger.LogInformation("Sync RecipeTags successful: {RecipeId}", recipeId);
    }
}