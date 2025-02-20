using Dama.Fin.Domain.Entity.Budgeting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dama.Fin.Infrastructure.Persistence.Configuration.Budgeting;

public class RunnerComponentHistoryConfiguration : RunnerComponentBaseConfiguration<RunnerComponentHistory>
{
    public override void Configure(EntityTypeBuilder<RunnerComponentHistory> entity)
    {
        base.Configure(entity);

        entity.ToTable("runner_component_history", "budgeting");
    }
}