namespace NetCoreBase.Infrastructure;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCoreBase.Application.Common;
using NetCoreBase.Infrastructure.Authentication;

public static class DependencyInjecttion
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        // đăng ký JwtConfig
        services.Configure<JwtConfig>(configuration.GetSection("Jwt"));
        services.AddSingleton<IJwtGenerator, JwtGenerator>();
        return services;
    }
}