namespace YumMaya_01.WebAPI.Domain.Models;

public sealed class RecipeCategory
{
    public Guid RecipeId { get; set; }
    public Guid TypeId { get; set; }
    public Recipe Recipe { get; set; }
    public Category Category { get; set; }
}