using System.ComponentModel.DataAnnotations.Schema;

namespace YumMaya_01.WebAPI.Domain.Models;

public sealed class Category
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public ICollection<RecipeCategory> RecipeCategories { get; set; } = new List<RecipeCategory>();
    [NotMapped]
    public IEnumerable<Recipe> Recipes => RecipeCategories.Select(rt => rt.Recipe);
}