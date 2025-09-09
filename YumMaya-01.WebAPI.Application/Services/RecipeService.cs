using AutoMapper;
using Microsoft.Extensions.Logging;
using YumMaya_01.WebAPI.Application.Base;
using YumMaya_01.WebAPI.Application.Contracts.Repositories;
using YumMaya_01.WebAPI.Application.Contracts.Services;
using YumMaya_01.WebAPI.Application.DTOs.Recipes;
using YumMaya_01.WebAPI.Domain.Models;

namespace YumMaya_01.WebAPI.Application.Services;

public sealed class RecipeService : IRecipeService
{
    private readonly IRecipeRepository _recipeRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<RecipeService> _logger;

    public RecipeService(
        IRecipeRepository recipeRepository,
        IMapper mapper, 
        ILogger<RecipeService> logger)
    {
        _recipeRepository = recipeRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<Guid> CreateRecipeAsync(RecipeCreateDto recipeCreateDto)
    {
        _logger.LogInformation("Create Recipe called: {Name}", recipeCreateDto.Name);

        var recipe = _mapper.Map<Recipe>(recipeCreateDto);
        recipe.Id = Guid.NewGuid();
        recipe.CreatedAt = DateTimeOffset.UtcNow;

        // Check if operation is successful
        if (!await _recipeRepository.AddAsync(recipe))
        {
            _logger.LogError("Create Recipe failed: {Name}", recipeCreateDto.Name);
            throw new OperationFailedException("Create Recipe failed");
        }

        _logger.LogInformation("Create Recipe successful: {Id}", recipe.Id);

        return recipe.Id;
    }

    public async Task DeleteRecipeAsync(Guid Id)
    {
        _logger.LogWarning("Delete Recipe called: {Id}", Id);

        // Check if operation is successful
        if (!await _recipeRepository.DeleteAsync(Id))
        {
            _logger.LogError("Delete Recipe failed: {Id}", Id);
            throw new OperationFailedException("Delete Recipe failed");
        }

        _logger.LogInformation("Delete Recipe successful: {Id}", Id);
    }

    public async Task<IEnumerable<RecipeDto>> GetAllRecipesAsync()
    {
        _logger.LogInformation("Get Recipes called.");

        return _mapper.Map<IEnumerable<RecipeDto>>(await _recipeRepository.GetAllAsync());
    }

    public async Task<RecipeDto> GetRecipeByIdAsync(Guid Id)
    {
        _logger.LogInformation("Get Recipe called: {Id}", Id);

        var recipe = _mapper.Map<RecipeDto>(await _recipeRepository.GetAsync(Id));

        // Check if entity is found
        if (recipe == null)
        {
            _logger.LogError("Get Recipe failed: {Id}", Id);
            throw new NotFoundException("Recipe not found");
        }

        _logger.LogInformation("Get Recipe successful: {Id}", Id);

        return recipe;
    }

    public async Task UpdateRecipeAsync(RecipeUpdateDto recipeUpdateDto)
    {
        _logger.LogInformation("Update Recipe called: {Id}", recipeUpdateDto.Id);

        // Check if operation is successful
        if (!await _recipeRepository.UpdateAsync(_mapper.Map<Recipe>(recipeUpdateDto)))
        {
            _logger.LogError("Update Recipe failed: {Id}", recipeUpdateDto.Id);
            throw new OperationFailedException("Update Recipe failed");
        }

        _logger.LogInformation("Update Recipe successful: {Id}", recipeUpdateDto.Id);
    }
}