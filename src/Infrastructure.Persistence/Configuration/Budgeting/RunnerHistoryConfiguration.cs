using Dama.Fin.Domain.Entity.Budgeting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dama.Fin.Infrastructure.Persistence.Configuration.Budgeting;

public class RunnerHistoryConfiguration : RunnerBaseConfiguration<RunnerHistory>
{
    public override void Configure(EntityTypeBuilder<RunnerHistory> entity)
    {
        base.Configure(entity);

        entity.ToTable("runner_history", "budgeting");
    }
}