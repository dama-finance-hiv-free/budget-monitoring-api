using Dama.Fin.Domain.Entity.Budgeting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dama.Fin.Infrastructure.Persistence.Configuration.Budgeting;

public class ActivityPlanHistoryConfiguration : ActivityPlanBaseConfiguration<ActivityPlanHistory>
{
    public override void Configure(EntityTypeBuilder<ActivityPlanHistory> entity)
    {
        base.Configure(entity);

        entity.ToTable("activity_plan_history", "budgeting");
    }
}