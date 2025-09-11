using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using YumMaya_01.WebAPI.Application.Contracts.Auth;
using YumMaya_01.WebAPI.Application.Contracts.Persistence.Repositories;
using YumMaya_01.WebAPI.Application.DTOs.Auth;
using YumMaya_01.WebAPI.Application.Helpers;
using YumMaya_01.WebAPI.Domain.Models;

namespace YumMaya_01.WebAPI.Application.Auth;

public sealed class AuthService : IAuthService
{
    private readonly ILogger<AuthService> _logger;
    private readonly IHttpContextAccessor _context;
    private readonly IUserRepository _userRepository;
    private readonly ITokenGenerator _tokenGenerator;

    public AuthService(
        ILogger<AuthService> logger,
        IHttpContextAccessor context,
        IUserRepository userRepository,
        ITokenGenerator tokenGenerator)
    {
        _logger = logger;
        _context = context;
        _userRepository = userRepository;
        _tokenGenerator = tokenGenerator;
    }

    public async Task<string> LoginAsync(LoginDto loginDto)
    {
        var ip = _context.HttpContext?.Connection.RemoteIpAddress?.ToString();
        _logger.LogInformation("Login attempt started: {ip}", ip);

        User user = null;

        // Check if username is not empty
        if (!string.IsNullOrEmpty(loginDto.Username))
        {
            user = await _userRepository.GetByUsernameAsync(loginDto.Username);
        }

        // Check if email is not empty
        if (!string.IsNullOrEmpty(loginDto.Email))
        {
            user = await _userRepository.GetByEmailAsync(loginDto.Email);
        }

        if (user is null)
        {
            _logger.LogWarning("Login attempt failed: {ip}", ip);
            return null;
        }

        if (!PasswordHash.VerifyPassword(loginDto.Password, user.PasswordHash))
        {
            _logger.LogWarning("Login attempt failed: {ip}", ip);
            return null;
        }

        return _tokenGenerator.GenerateToken(user);
    }
}