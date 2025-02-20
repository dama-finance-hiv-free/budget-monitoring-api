using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dama.Fin.Infrastructure.Reporting
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

            //services.AddTransient<ICsvExporter, CsvExporter>();
            //services.AddTransient<IActivityPlanReport, ActivityPlanReport>();
            //services.AddTransient<IActivityScheduleBudgetReport, ActivityScheduleBudgetReport>();
            //services.AddTransient<IEmailService, EmailService>();

            return services;
        }
    }
}
