using AutoMapper;
using Microsoft.Extensions.Logging;
using YumMaya_01.WebAPI.Application.Contracts.Persistence.Repositories;
using YumMaya_01.WebAPI.Application.Contracts.Services;
using YumMaya_01.WebAPI.Application.DTOs.Tags;

namespace YumMaya_01.WebAPI.Application.Services;

public sealed class TagService : ITagService
{
    private readonly ITagRepository _tagRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<TagService> _logger;

    public TagService(
        ITagRepository tagRepository,
        IMapper mapper,
        ILogger<TagService> logger)
    {
        _tagRepository = tagRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<IEnumerable<TagDto>> GetAllTagsAsync()
    {
        _logger.LogInformation("Get all Tags called.");
        return _mapper.Map<IEnumerable<TagDto>>(await _tagRepository.GetAllAsync());
    }
}