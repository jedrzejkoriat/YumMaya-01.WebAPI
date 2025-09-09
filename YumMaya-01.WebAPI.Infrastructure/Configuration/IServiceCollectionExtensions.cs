using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using YumMaya_01.WebAPI.Application.Contracts.Repositories;
using YumMaya_01.WebAPI.Infrastructure.Repositories;

namespace YumMaya_01.WebAPI.Infrastructure.Configuration;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddSqliteConnection(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite(config.GetConnectionString("DefaultConnection")));

        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IRecipeRepository, RecipeRepository>();
        services.AddScoped<ITagRepository, TagRepository>();

        return services;
    }
}