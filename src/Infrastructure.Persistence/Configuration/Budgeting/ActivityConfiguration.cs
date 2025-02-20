using Dama.Fin.Domain.Entity.Budgeting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dama.Fin.Infrastructure.Persistence.Configuration.Budgeting;

public partial class ActivityConfiguration : ActivityBaseConfiguration<Activity>
{
    public override void Configure(EntityTypeBuilder<Activity> entity)
    {
        base.Configure(entity);

        entity.ToTable("activity", "budgeting");
    }
}