using Dama.Fin.Domain.Entity.Budgeting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dama.Fin.Infrastructure.Persistence.Configuration.Budgeting;

public class TargetHistoryConfiguration : TargetBaseConfiguration<TargetHistory>
{
    public override void Configure(EntityTypeBuilder<TargetHistory> entity)
    {
        base.Configure(entity);

        entity.ToTable("target_history", "budgeting");
    }
}