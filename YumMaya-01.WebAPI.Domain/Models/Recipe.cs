using System.ComponentModel.DataAnnotations.Schema;
using YumMaya_01.WebAPI.Domain.Enums;

namespace YumMaya_01.WebAPI.Domain.Models;

public sealed class Recipe
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public string? Instructions { get; set; }
    public string? Ingredients { get; set; }
    public int PreparationTime { get; set; }
    public int CookingTime { get; set; }
    public int Servings { get; set; }
    public Difficulty Difficulty { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public string? MainImagePath { get; set; }
    public string? PreviewImagePath { get; set; }
    public string? ReelPath { get; set; }
    public ICollection<RecipeTag> RecipeTags { get; set; } = new List<RecipeTag>();
    [NotMapped]
    public IEnumerable<Tag> Tags => RecipeTags.Select(rt => rt.Tag);
}