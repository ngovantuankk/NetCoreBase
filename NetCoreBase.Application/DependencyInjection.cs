using Microsoft.Extensions.DependencyInjection;
using NetCoreBase.Application.Common.Persistence;
using NetCoreBase.Application.Services;

namespace NetCoreBase.Application;

public static class DependencyInjecttion
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        return services;
    }
}