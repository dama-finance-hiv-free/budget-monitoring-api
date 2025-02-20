using Dama.Fin.Domain.Entity.Budgeting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dama.Fin.Infrastructure.Persistence.Configuration.Budgeting;

public class ActivityHistoryConfiguration : ActivityBaseConfiguration<ActivityHistory>
{
    public override void Configure(EntityTypeBuilder<ActivityHistory> entity)
    {
        base.Configure(entity);

        entity.ToTable("activity_history", "budgeting");
    }
}