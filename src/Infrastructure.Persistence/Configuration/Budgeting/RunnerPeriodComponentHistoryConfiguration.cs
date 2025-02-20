using Dama.Fin.Domain.Entity.Budgeting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dama.Fin.Infrastructure.Persistence.Configuration.Budgeting;

public class RunnerPeriodComponentHistoryConfiguration : RunnerPeriodComponentBaseConfiguration<RunnerPeriodComponentHistory>
{
    public override void Configure(EntityTypeBuilder<RunnerPeriodComponentHistory> entity)
    {
        base.Configure(entity);

        entity.ToTable("runner_period_component_history", "budgeting");
    }
}