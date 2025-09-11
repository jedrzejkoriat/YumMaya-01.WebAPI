using FluentValidation;

namespace YumMaya_01.WebAPI.Application.DTOs.Auth;

public sealed record LoginDto (string Username, string Email, string Password);

public sealed class LoginDtoValidator : AbstractValidator<LoginDto>
{
    public LoginDtoValidator()
    {
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.");

        RuleFor(x => x)
            .Custom((dto, context) =>
            {
                if (string.IsNullOrWhiteSpace(dto.Username) && string.IsNullOrWhiteSpace(dto.Email))
                {
                    context.AddFailure("Either UserName or Email must be provided.");
                }
            });
    }
}