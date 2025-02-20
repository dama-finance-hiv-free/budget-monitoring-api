using Dama.Fin.Domain.Entity.Budgeting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dama.Fin.Infrastructure.Persistence.Configuration.Budgeting;

public class RunnerPeriodConfiguration : RunnerPeriodBaseConfiguration<RunnerPeriod>
{
    public override void Configure(EntityTypeBuilder<RunnerPeriod> entity)
    {
        base.Configure(entity);

        entity.ToTable("runner_period", "budgeting");
    }
}