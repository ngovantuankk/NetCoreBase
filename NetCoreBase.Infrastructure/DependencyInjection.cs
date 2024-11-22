namespace NetCoreBase.Infrastructure;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCoreBase.Application.Common;
using NetCoreBase.Application.Common.Persistence;
using NetCoreBase.Infrastructure.Authentication;
using NetCoreBase.Infrastructure.Persistence;

public static class DependencyInjecttion
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        // đăng ký JwtConfig
        services.Configure<JwtConfig>(configuration.GetSection("Jwt"));
        services.AddSingleton<IJwtGenerator, JwtGenerator>();
        services.AddScoped<IUserRepository, UserRepository>(); // đăng ký DI Contaitner cho UserRepository
        return services;
    }
}