using YumMaya_01.WebAPI.Domain.Models;

namespace YumMaya_01.WebAPI.Application.Contracts.Persistence.Repositories;

public interface IRecipeLikeRepository : IReadRepository<RecipeLike>, IWriteRepository<RecipeLike>
{
}
