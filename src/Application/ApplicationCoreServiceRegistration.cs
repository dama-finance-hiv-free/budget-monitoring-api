using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Dama.Fin.Application;

public static class ApplicationCoreServiceRegistration
{
    public static IServiceCollection AddApplicationCoreServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());

        return services;
    }
}