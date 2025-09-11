using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using YumMaya_01.WebAPI.Application.Contracts.Services;
using YumMaya_01.WebAPI.Application.DTOs.Tags;

namespace YumMaya_01.WebAPI.API.Controllers;
[Route("api/[controller]")]
[EnableRateLimiting("fixedlimit")]
[ApiController]
public class TagsController : ControllerBase
{
    private readonly ITagService _tagService;

    public TagsController(ITagService tagService)
    {
        _tagService = tagService;
    }

    /// <summary>
    /// Get Tags
    /// </summary>
    /// <returns>List of Tags</returns>
    // GET: api/tags
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TagDto>>> Get()
    {
        return Ok(await _tagService.GetAllTagsAsync());
    }
}
