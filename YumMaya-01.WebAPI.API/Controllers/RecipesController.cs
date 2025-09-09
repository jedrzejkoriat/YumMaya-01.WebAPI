using Microsoft.AspNetCore.Mvc;

namespace YumMaya_01.WebAPI.API.Controllers;

/// <summary>
/// Controller for managing recipes.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class RecipesController : ControllerBase
{
    public RecipesController()
    {

    }

    // GET: api/recipes
    /// <summary>
    /// Get all Recipes
    /// </summary>
    /// <returns>List of Recipes</returns>
    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new string[] { "value1", "value2" };
    }

    // GET api/recipes/{id}
    /// <summary>
    /// Get Recipe by Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Recipe entity</returns>
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/recipes
    /// <summary>
    /// Create Recipe
    /// </summary>
    /// <param name="value"></param>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/recipes/{id}
    /// <summary>
    /// Update Recipe
    /// </summary>
    /// <param name="id"></param>
    /// <param name="value"></param>
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/recipes/{id}
    /// <summary>
    /// Delete Recipe
    /// </summary>
    /// <param name="id"></param>
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
