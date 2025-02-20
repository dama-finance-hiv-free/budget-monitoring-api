using Dama.Core.Common.Cache;
using Dama.Fin.Infrastructure.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Dama.Fin.API.Core;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCaching(this IServiceCollection services)
    {
        services.AddDistributedMemoryCache();

        services.TryAddSingleton(typeof(IDistributedCache<>), typeof(DistributedCache<>)); // open generic registration

        services.TryAddSingleton<IDistributedCacheFactory, DistributedCacheFactory>();

        return services;
    }

    public static IServiceCollection AddDatabaseContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration["ConnectionStrings:MonitoringData"];
        services.AddDbContext<MonitoringContext>(o => o.UseNpgsql(connectionString).UseSnakeCaseNamingConvention());

        return services;
    }

    public static IServiceCollection AddAuthorizationServer(this IServiceCollection services, IConfiguration configuration)
    {
        var authorizationServer = configuration["AppSettings:AuthorizationServer"];

        services.AddAuthentication("Bearer")
            .AddIdentityServerAuthentication("Bearer", options =>
            {
                options.ApiName = "damaapi";
                options.Authority = authorizationServer;
            });

        return services;
    }
}