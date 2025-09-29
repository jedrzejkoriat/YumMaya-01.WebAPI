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
    public Status Status { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public string? ImagePath { get; set; }
    public string? ReelUrl { get; set; }
    public bool IsArchived { get; set; }
    public IEnumerable<Comment> Comments { get; set; } = new List<Comment>();
    [NotMapped]
    public IEnumerable<Tag> Tags => RecipeTags.Select(rt => rt.Tag);
    public ICollection<RecipeTag> RecipeTags { get; set; } = new List<RecipeTag>();
    [NotMapped]
    public IEnumerable<Category> Types => RecipeCategories.Select(rt => rt.Category);
    public ICollection<RecipeCategory> RecipeCategories { get; set; } = new List<RecipeCategory>();
}