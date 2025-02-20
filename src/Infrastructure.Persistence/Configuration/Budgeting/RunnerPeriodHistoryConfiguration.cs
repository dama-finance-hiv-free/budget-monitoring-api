using Dama.Fin.Domain.Entity.Budgeting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dama.Fin.Infrastructure.Persistence.Configuration.Budgeting;

public class RunnerPeriodHistoryConfiguration : RunnerPeriodBaseConfiguration<RunnerPeriodHistory>
{
    public override void Configure(EntityTypeBuilder<RunnerPeriodHistory> entity)
    {
        base.Configure(entity);

        entity.ToTable("runner_period_history", "budgeting");
    }
}