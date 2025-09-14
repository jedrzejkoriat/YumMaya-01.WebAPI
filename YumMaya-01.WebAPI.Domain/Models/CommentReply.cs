namespace YumMaya_01.WebAPI.Domain.Models;

public sealed class CommentReply
{
    public Guid Id { get; set; }
    public Guid CommentId { get; set; }
    public string CommenterName { get; set; }
    public string Content { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public string IpAddress { get; set; }
    public Comment Comment { get; set; }
}