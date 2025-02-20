using Dama.Fin.Domain.Entity.Budgeting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dama.Fin.Infrastructure.Persistence.Configuration.Budgeting;

public class ActivityPlanConfiguration : ActivityPlanBaseConfiguration<ActivityPlan>
{
    public override void Configure(EntityTypeBuilder<ActivityPlan> entity)
    {
        base.Configure(entity);

        entity.ToTable("activity_plan", "budgeting");
    }
}