namespace YumMaya_01.WebAPI.Domain.Models;

public sealed class RecipeType
{
    public Guid RecipeId { get; set; }
    public Guid TypeId { get; set; }
    public Recipe Recipe { get; set; }
    public Type Type { get; set; }
}