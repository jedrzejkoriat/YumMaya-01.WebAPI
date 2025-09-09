using YumMaya_01.WebAPI.Application.DTOs.Recipes;

namespace YumMaya_01.WebAPI.Application.Contracts.Services;

public interface IRecipeService
{
    public Task<IEnumerable<RecipeDto>> GetAllRecipesAsync();
    public Task<RecipeDto> GetRecipeByIdAsync(Guid Id);
    public Task<Guid> CreateRecipeAsync(RecipeCreateDto recipeCreateDto);
    public Task UpdateRecipeAsync(RecipeUpdateDto recipeUpdateDto);
    public Task DeleteRecipeAsync(Guid Id);
}