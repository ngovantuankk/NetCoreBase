namespace NetCoreBase.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using NetCoreBase.Application.Common;
using NetCoreBase.Infrastructure.Authentication;

public static class DependencyInjecttion
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services)
    {
        services.AddSingleton<IJwtGenerator, JwtGenerator>();
        return services;
    }
}