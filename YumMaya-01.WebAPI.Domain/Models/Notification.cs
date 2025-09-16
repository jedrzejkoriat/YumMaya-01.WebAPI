namespace YumMaya_01.WebAPI.Domain.Models;

public sealed class Notification
{
    public Guid Id { get; set; }
    public Guid RecipeId { get; set; }
    public string Message { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public bool IsRead { get; set; }
    public Recipe Recipe { get; set; }
}