using YumMaya_01.WebAPI.Application.DTOs.Auth;

namespace YumMaya_01.WebAPI.Application.Contracts.Auth;

public interface IAuthService
{
    Task<string> LoginAsync(LoginDto loginDto);
}