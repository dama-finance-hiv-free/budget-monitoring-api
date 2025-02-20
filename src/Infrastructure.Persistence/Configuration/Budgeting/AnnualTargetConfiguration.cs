using Dama.Fin.Domain.Entity.Budgeting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dama.Fin.Infrastructure.Persistence.Configuration.Budgeting;

public class AnnualTargetConfiguration : TargetBaseConfiguration<AnnualTarget>
{
    public override void Configure(EntityTypeBuilder<AnnualTarget> entity)
    {
        base.Configure(entity);

        entity.ToTable("annual_target", "budgeting");
    }
}