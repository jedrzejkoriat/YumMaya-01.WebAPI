using YumMaya_01.WebAPI.Domain.Models;

namespace YumMaya_01.WebAPI.Application.Contracts.Persistence.Repositories;

public interface ICommentRepository : IReadRepository<Comment>, IWriteRepository<Comment>
{
}