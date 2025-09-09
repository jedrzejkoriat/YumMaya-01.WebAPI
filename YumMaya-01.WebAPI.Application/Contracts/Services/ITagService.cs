using YumMaya_01.WebAPI.Application.DTOs.Tags;

namespace YumMaya_01.WebAPI.Application.Contracts.Services;

public interface ITagService
{
    Task<IEnumerable<TagDto>> GetAllTagsAsync();
}