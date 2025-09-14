namespace YumMaya_01.WebAPI.Domain.Models;

public sealed class RecipeLike
{
    public Guid Id { get; set; }
    public Guid RecipeId { get; set; }
    public string IpAddress { get; set; }
}