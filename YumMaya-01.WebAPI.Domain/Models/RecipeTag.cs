namespace YumMaya_01.WebAPI.Domain.Models;

public sealed class RecipeTag
{
    public Guid RecipeId { get; set; }
    public Recipe Recipe { get; set; }

    public Guid TagId { get; set; }
    public Tag Tag { get; set; }
}