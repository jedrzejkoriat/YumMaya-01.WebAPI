using YumMaya_01.WebAPI.Domain.Models;

namespace YumMaya_01.WebAPI.Application.Contracts.Auth;

public interface ITokenGenerator
{
    string GenerateToken(User user);
}
