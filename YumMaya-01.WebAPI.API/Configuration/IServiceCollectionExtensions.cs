using Microsoft.AspNetCore.RateLimiting;

namespace YumMaya_01.WebAPI.API.Configuration;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddRequestLimiter(this IServiceCollection services)
    {
        services.AddRateLimiter(options =>
        {
            options.AddFixedWindowLimiter("fixedlimit", opt =>
            {
                opt.Window = TimeSpan.FromSeconds(10);
                opt.PermitLimit = 500;
            });
        });

        return services;
    }
}
