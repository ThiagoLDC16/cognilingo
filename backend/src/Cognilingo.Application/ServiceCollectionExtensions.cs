using System.Reflection;
using Cognilingo.Application.Identity.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace Cognilingo.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        services.AddScoped<AuthService>();

        return services;
    }
}
