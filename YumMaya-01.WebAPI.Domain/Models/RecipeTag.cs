namespace YumMaya_01.WebAPI.Domain.Models;

public sealed class RecipeTag
{
    public Guid RecipeId { get; set; }
    public Guid TagId { get; set; }
}