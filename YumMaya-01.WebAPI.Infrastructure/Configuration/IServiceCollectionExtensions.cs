using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace YumMaya_01.WebAPI.Infrastructure.Configuration;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddSqliteConnection(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite(config.GetConnectionString("DefaultConnection")));

        return services;
    }
}