using Dama.Fin.Domain.Entity.Budgeting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dama.Fin.Infrastructure.Persistence.Configuration.Budgeting;

public class ActivityPlanBaseConfiguration<T> : IEntityTypeConfiguration<T> where T : ActivityPlanBase
{
    public virtual void Configure(EntityTypeBuilder<T> entity)
    {
        entity.HasKey(e => new { e.Tenant, e.Code, e.Project, e.CopYear });

        entity.Property(x => x.Tenant).HasMaxLength(10).IsRequired().IsUnicode(false);
        entity.Property(x => x.Code).HasMaxLength(10).IsRequired().IsUnicode(false);
        entity.Property(x => x.Project).HasMaxLength(2).IsRequired().IsUnicode(false);
        entity.Property(x => x.CopYear).HasMaxLength(10).IsRequired().IsUnicode(false);
        entity.Property(x => x.Description).HasMaxLength(350).IsRequired().IsUnicode(false);
        entity.Property(x => x.Intervention).HasMaxLength(5).IsRequired().IsUnicode(false);
        entity.Property(x => x.CostCategory).HasMaxLength(5).IsRequired().IsUnicode(false);
        entity.Property(x => x.BudgetCode).HasMaxLength(5).IsRequired().IsUnicode(false);
        entity.Property(x => x.ActivityType).HasMaxLength(2).IsRequired().IsUnicode(false);
        entity.Property(x => x.Strategy).HasMaxLength(2).IsRequired().IsUnicode(false);
    }
}