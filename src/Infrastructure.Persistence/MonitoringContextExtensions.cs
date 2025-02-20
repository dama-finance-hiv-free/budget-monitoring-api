using System.Reflection;
using Dama.Fin.Infrastructure.Persistence.Configuration.Budgeting;
using Dama.Fin.Infrastructure.Persistence.Configuration.Common;
using Microsoft.EntityFrameworkCore;

namespace Dama.Fin.Infrastructure.Persistence;

public static class MonitoringContextExtensions
{

    public static void AddCommonConfigurations(this ModelBuilder modelBuilder)
    {
        var configurationAssembly = typeof(BranchConfiguration).GetTypeInfo().Assembly;
        modelBuilder.ApplyConfigurationsFromAssembly(configurationAssembly);
    }

    public static void AddBudgetingConfigurations(this ModelBuilder modelBuilder)
    {
        var configurationAssembly = typeof(BudgetConfiguration).GetTypeInfo().Assembly;
        modelBuilder.ApplyConfigurationsFromAssembly(configurationAssembly);
    }
}