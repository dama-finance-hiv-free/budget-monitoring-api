using Autofac;
using Dama.Fin.Application.Common.Branch;
using Dama.Fin.Infrastructure.Persistence;
using Dama.Fin.Infrastructure.Persistence.Repository.Common;
using Dama.Fin.Infrastructure.Reporting.Activity.ActivityPlan;

namespace Dama.Fin.API.Core;

public static class AutofacExtensions
{
    public static void RegisterApplicationDependencies(this ContainerBuilder builder)
    {
        builder.RegisterType<DatabaseFactory>().As<IDatabaseFactory>().InstancePerLifetimeScope();

        builder.RegisterAssemblyTypes(typeof(BranchPersistence).Assembly)
            .Where(t => t.Name.EndsWith("Persistence"))
            .AsImplementedInterfaces().InstancePerLifetimeScope();

        builder.RegisterAssemblyTypes(typeof(BranchService).Assembly)
            .Where(t => t.Name.EndsWith("Service"))
            .AsImplementedInterfaces().InstancePerLifetimeScope();

        builder.RegisterAssemblyTypes(typeof(ActivityPlanReport).Assembly)
            .Where(t => t.Name.EndsWith("Report"))
            .AsImplementedInterfaces().InstancePerLifetimeScope();
    }
}