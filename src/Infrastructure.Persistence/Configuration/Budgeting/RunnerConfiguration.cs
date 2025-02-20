using Dama.Fin.Domain.Entity.Budgeting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dama.Fin.Infrastructure.Persistence.Configuration.Budgeting;

public class RunnerConfiguration : RunnerBaseConfiguration<Runner>
{
    public override void Configure(EntityTypeBuilder<Runner> entity)
    {
        base.Configure(entity);

        entity.ToTable("runner", "budgeting");
    }
}