namespace YumMaya_01.WebAPI.Domain.Models;

public sealed class Tag
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public ICollection<RecipeTag> RecipeTags { get; set; } = new List<RecipeTag>();
    public IEnumerable<Recipe> Recipes => RecipeTags.Select(rt => rt.Recipe);
}