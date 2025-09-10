using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YumMaya_01.WebAPI.Application.Contracts.Services;
using YumMaya_01.WebAPI.Application.DTOs.Recipes;

namespace YumMaya_01.WebAPI.API.Controllers;

/// <summary>
/// Controller for managing recipes.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class RecipesController : ControllerBase
{
    private readonly IRecipeService _recipeService;

    public RecipesController(IRecipeService recipeService)
    {
        _recipeService = recipeService;
    }

    // GET: api/recipes
    /// <summary>
    /// Get all Recipes
    /// </summary>
    /// <returns>List of Recipes</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<RecipeDto>>> Get()
    {
        return Ok(await _recipeService.GetAllRecipesAsync());
    }

    // GET api/recipes/{id}
    /// <summary>
    /// Get Recipe by Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Recipe entity</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<RecipeDto>> Get(Guid id)
    {
        return Ok(await _recipeService.GetRecipeByIdAsync(id));
    }

    // POST api/recipes
    /// <summary>
    /// Create Recipe
    /// </summary>
    /// <param name="recipe"></param>
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] RecipeCreateDto recipe)
    {
        var id = await _recipeService.CreateRecipeAsync(recipe);
        return CreatedAtAction(nameof(Get), new { id }, null);
    }

    // PUT api/recipes
    /// <summary>
    /// Update Recipe
    /// </summary>
    /// <param name="recipe"></param>
    [HttpPut]
    public async Task<ActionResult> Put([FromBody] RecipeUpdateDto recipe)
    {
        await _recipeService.UpdateRecipeAsync(recipe);
        return NoContent();
    }

    // DELETE api/recipes/{id}
    /// <summary>
    /// Delete Recipe
    /// </summary>
    /// <param name="id"></param>
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await _recipeService.DeleteRecipeAsync(id);
        return NoContent();
    }
}
