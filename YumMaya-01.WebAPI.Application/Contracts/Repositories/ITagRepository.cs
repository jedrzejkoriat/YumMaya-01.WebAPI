using YumMaya_01.WebAPI.Domain.Models;

namespace YumMaya_01.WebAPI.Application.Contracts.Repositories;

public interface ITagRepository
{
    Task<IEnumerable<Tag>> GetAllAsync();
}