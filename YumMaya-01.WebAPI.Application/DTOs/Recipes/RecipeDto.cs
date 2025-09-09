using YumMaya_01.WebAPI.Application.DTOs.Tags;

namespace YumMaya_01.WebAPI.Application.DTOs.Recipes;

public sealed record RecipeDto(
    Guid Id,
    string Name,
    string? Description,
    string? Instructions,
    string? Ingredients,
    int PreparationTime,
    int CookingTime,
    int Servings,
    string Difficulty,
    string? MainImagePath,
    string? PreviewImagePath,
    string? ReelUrl,
    DateTimeOffset CreatedAt,
    IEnumerable<TagDto> tags);