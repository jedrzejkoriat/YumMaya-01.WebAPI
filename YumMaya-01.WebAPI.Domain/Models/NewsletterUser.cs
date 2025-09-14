namespace YumMaya_01.WebAPI.Domain.Models;

public sealed class NewsletterUser
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
}