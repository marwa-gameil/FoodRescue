using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
// using Microsoft.AspNetCore.Authentication.JwtBearer;
// using Microsoft.IdentityModel.Tokens;
using FoodRescue.Domain.Models;
using FoodRescue.Application.Utilities;
using FoodRescue.Infrastructure.Utilities;
using FoodRescue.Infrastructure.Data;
using FoodRescue.Infrastructure;

namespace FoodRescue.Presentation.Utilities;

public static class ServiceExtensions
{
    public static IServiceCollection Configure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddDbConte0tPoolConfiguration(configuration);


        services.AddIdentityConfiguration(configuration);
        services.AddAuthentication();
        services.AddAuthorization();
        // uncomment if want to use jwt
        // DO NOT FORGET TO ADD JWT SETTINGS TO USER SECRETS
        // services.AddJWTAuthentication(configuration);
        services.AddCorsConfiguration();
        services.AddIISIntegrationConfiguration();
        services.AddControllers();
        services.AddServices();
        services.AddRepositories();
        return services;
    }

    public static IServiceCollection AddDbConte0tPoolConfiguration(this IServiceCollection services, IConfiguration configuration) =>
        services.AddDbContext<ApplicationDbContext>(
            options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
        );

    public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        /* ------- Register Identity ------- */
        services.AddIdentity<User, IdentityRole<Guid>>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
        /* ------- Get Default User Data from appsettings.json ------- */
        var defaultUserModel = configuration.GetSection("DefaultUserModel");
        if (defaultUserModel.Exists())
            services.Configure<User>(defaultUserModel);
        return services;
    }

    // public static IServiceCollection AddJWTAuthentication(this IServiceCollection services, IConfiguration configuration)
    // {
    //     var jwtSettings = configuration.GetSection("JwtSettings");
    //     services.AddAuthentication(options =>
    //     {
    //         options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    //         options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    //     })
    //     .AddJwtBearer(options =>
    //     {
    //         options.TokenValidationParameters = new TokenValidationParameters
    //         {
    //             ValidateIssuer = true,
    //             ValidateAudience = true,
    //             ValidateLifetime = true,
    //             ValidateIssuerSigningKey = true,
    //             ValidIssuer = jwtSettings["Issuer"],
    //             ValidAudience = jwtSettings["Audience"],
    //             IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]!))
    //         };
    //     });
    //     return services;
    // }

    public static IServiceCollection AddCorsConfiguration(this IServiceCollection services) =>
        services.AddCors(options =>
            {
                options.AddPolicy(
                    "CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                                      .AllowAnyMethod()
                                      .AllowAnyHeader()
                );
            }
        );

    public static IServiceCollection AddIISIntegrationConfiguration(this IServiceCollection services) =>
        services.Configure<IISOptions>(options => {});
}
