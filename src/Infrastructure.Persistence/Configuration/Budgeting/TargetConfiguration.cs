using Dama.Fin.Domain.Entity.Budgeting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dama.Fin.Infrastructure.Persistence.Configuration.Budgeting;

public class TargetConfiguration : TargetBaseConfiguration<Target>
{
    public override void Configure(EntityTypeBuilder<Target> entity)
    {
        base.Configure(entity);

        entity.ToTable("target", "budgeting");
    }
}