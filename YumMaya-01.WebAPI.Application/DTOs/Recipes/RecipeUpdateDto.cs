using FluentValidation;
using YumMaya_01.WebAPI.Application.DTOs.Tags;
using YumMaya_01.WebAPI.Domain.Enums;

namespace YumMaya_01.WebAPI.Application.DTOs.Recipes;

public sealed record RecipeUpdateDto(
    Guid Id,
    string Name,
    string? Description,
    string? Instructions,
    string? Ingredients,
    int PreparationTime,
    int CookingTime,
    int Servings,
    string Difficulty,
    string? ReelUrl,
    IEnumerable<Guid> TagIds);

public class RecipeUpdateDtoValidator : AbstractValidator<RecipeUpdateDto>
{
    public RecipeUpdateDtoValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(150).WithMessage("Name cannot exceed 150 characters.");

        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.")
            .When(x => x.Description != null);

        RuleFor(x => x.Instructions)
            .MaximumLength(100_000).WithMessage("Instructions cannot exceed 100,000 characters.")
            .When(x => x.Instructions != null);

        RuleFor(x => x.Ingredients)
            .MaximumLength(10_000).WithMessage("Ingredients cannot exceed 10,000 characters.")
            .When(x => x.Ingredients != null);

        RuleFor(x => x.PreparationTime)
            .GreaterThanOrEqualTo(0).WithMessage("Preparation time must be non-negative.");

        RuleFor(x => x.CookingTime)
            .GreaterThanOrEqualTo(0).WithMessage("Cooking time must be non-negative.");

        RuleFor(x => x.Servings)
            .GreaterThan(0).WithMessage("Servings must be greater than zero.");

        RuleFor(x => x.Difficulty)
            .NotEmpty().WithMessage("Difficulty is required.")
            .Must(BeAValidDifficulty).WithMessage("Difficulty must be Easy, Medium, or Hard.");
    }

    private bool BeAValidDifficulty(string difficulty)
    {
        return Enum.TryParse<Difficulty>(difficulty, ignoreCase: true, out _);
    }
}