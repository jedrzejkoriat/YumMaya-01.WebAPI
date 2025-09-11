using YumMaya_01.WebAPI.Domain.Models;

namespace YumMaya_01.WebAPI.Application.Contracts.Persistence.Repositories;

public interface IUserRepository
{
    Task<User> GetByUsernameAsync(string username);
    Task<User> GetByEmailAsync(string email);
}