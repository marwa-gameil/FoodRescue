using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using FoodRescue.Domain.Interfaces;
using FoodRescue.Infrastructure.Repositories;
using FoodRescue.Domain.Models;

namespace FoodRescue.Infrastructure.Utilities;

public static class DependencyInjection
{
    /// <summary>
    ///     Inject all the repositories
    /// </summary>
    /// <param name="services">IServiceCollection</param>
    /// <returns>A reference to this instance after injecting repositories</returns>
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IRepositoryManager, RepositoryManager>();
        services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
        services.AddScoped<UserManager<User>, UserManager<User>>();
        services.AddScoped<PasswordHasher<User>, PasswordHasher<User>>();
        return services;
    }
}
