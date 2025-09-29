using YumMaya_01.WebAPI.Application.Contracts.Persistence.Repositories;
using YumMaya_01.WebAPI.Domain.Models;

namespace YumMaya_01.WebAPI.Infrastructure.Persistence.Repositories;

internal sealed class CommentReplyRepository :  GenericRepository<CommentReply>, ICommentReplyRepository
{
    public CommentReplyRepository(AppDbContext context) : base(context)
    {
    }
}