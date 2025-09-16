using System.ComponentModel.DataAnnotations.Schema;

namespace YumMaya_01.WebAPI.Domain.Models;

public sealed class Comment
{
    public Guid Id { get; set; }
    public Guid RecipeId { get; set; }
    public string CommenterName { get; set; }
    public string Content { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public string IpAddress { get; set; }
    public Recipe Recipe { get; set; }
    public ICollection<CommentReply> CommentReplies { get; set; } = new List<CommentReply>();
}