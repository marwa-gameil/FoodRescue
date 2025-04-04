using FoodRescue.Application.Interfaces;
using FoodRescue.Application.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace FoodRescue.Application.Utilities;

public static class DependencyInjection
{
    /// <summary>
    ///     Inject all the services
    /// </summary>
    /// <param name="services">IServiceCollection</param>
    /// <returns>A reference to this instance after injecting services</returns>
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<ICharityService, CharityService>();
        services.AddScoped<ICookieAuthService,CookieAuthService>();
        services.AddScoped<IUserService,UserService>();

        return services;
    }
}
