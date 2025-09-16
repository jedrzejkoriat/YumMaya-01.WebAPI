namespace YumMaya_01.WebAPI.Domain.Models;

public sealed class NewsletterSubscriber
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
}