using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using YumMaya_01.WebAPI.Application.Contracts.Services;
using YumMaya_01.WebAPI.Application.Services;

namespace YumMaya_01.WebAPI.Application.Configuration;
public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(cfg => cfg.AddProfile<MapperConfig>());
        return services;
    }

    public static IServiceCollection AddDtoValidation(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation();
        services.AddFluentValidationClientsideAdapters();
        services.AddValidatorsFromAssembly(Assembly.Load("YumMaya-01.WebAPI.Application"));

        return services;
    }

    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IRecipeService, RecipeService>();
        services.AddScoped<ITagService, TagService>();
        services.AddScoped<IRecipeTagService, RecipeTagService>();

        return services;
    }
}