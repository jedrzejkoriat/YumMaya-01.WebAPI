using YumMaya_01.WebAPI.Domain.Models;
namespace YumMaya_01.WebAPI.Application.Contracts.Persistence.Repositories;

public interface ICommentReplyRepository : IReadRepository<CommentReply>, IWriteRepository<CommentReply>
{
}
