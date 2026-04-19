using Cognilingo.Infrastructure.Identity.Authentication;
using Cognilingo.Infrastructure.Identity.Authentication.Hashers;
using Cognilingo.Infrastructure.Identity.Persistence;
using Cognilingo.Infrastructure.Common.Persistence.Interceptors;
using Cognilingo.Infrastructure.Identity.Context;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        AddPersistence(services, configuration);
        AddIdentityInfrastructure(services);

        return services;
    }

    private static void AddPersistence(
        IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddSingleton<UpdateAuditFieldsInterceptor>();

        services.AddDbContext<ApplicationDbContext>((sp, options) =>
        {
            var auditInterceptor = sp.GetRequiredService<UpdateAuditFieldsInterceptor>();

            options
                .UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
                .AddInterceptors(auditInterceptor);
        });

        services.AddScoped<IAppDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
    }
    
    private static void AddIdentityInfrastructure(
        IServiceCollection services
    )
    {
        services.AddHttpContextAccessor();
        services.AddScoped<IRequestContext, RequestContext>();
        
        services.AddScoped<ITokenService, JwtTokenService>();
        services.AddScoped<IPasswordHasher, MD5PasswordHasher>();
    }
}