using ClassLibrary1.Interfeces.Services;
using ClassLibrary1.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ClassLibrary1;

public static class ServiceConfiguration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IService<>), typeof(Service<>));
        return services;
    }
}