using Dama.Fin.Domain.Entity.Budgeting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dama.Fin.Infrastructure.Persistence.Configuration.Budgeting;

public class RunnerPeriodComponentConfiguration : RunnerPeriodComponentBaseConfiguration<RunnerPeriodComponent>
{
    public override void Configure(EntityTypeBuilder<RunnerPeriodComponent> entity)
    {
        base.Configure(entity);

        entity.ToTable("runner_period_component", "budgeting");
    }
}