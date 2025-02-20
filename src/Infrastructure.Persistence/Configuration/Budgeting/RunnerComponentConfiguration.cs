using Dama.Fin.Domain.Entity.Budgeting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dama.Fin.Infrastructure.Persistence.Configuration.Budgeting;

public class RunnerComponentConfiguration : RunnerComponentBaseConfiguration<RunnerComponent>
{
    public override void Configure(EntityTypeBuilder<RunnerComponent> entity)
    {
        base.Configure(entity);

        entity.ToTable("runner_component", "budgeting");
    }
}