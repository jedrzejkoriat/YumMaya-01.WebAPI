using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using YumMaya_01.WebAPI.Application.Contracts.Persistence;
using YumMaya_01.WebAPI.Application.Contracts.Persistence.Repositories;
using YumMaya_01.WebAPI.Infrastructure.Persistence;
using YumMaya_01.WebAPI.Infrastructure.Persistence.Repositories;

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
        services.AddScoped<IRecipeTagRepository, RecipeTagRepository>();

        return services;
    }

    public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, EfUnitOfWork>();

        return services;
    }
}