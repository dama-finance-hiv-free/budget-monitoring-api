using Dama.Fin.Domain.Entity.Budgeting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dama.Fin.Infrastructure.Persistence.Configuration.Budgeting;

public class RunnerPeriodBaseConfiguration<T> : IEntityTypeConfiguration<T> where T : RunnerPeriodBase
{
    public virtual void Configure(EntityTypeBuilder<T> entity)
    {
        entity.HasKey(e => new {e.Tenant, e.Code});

        entity.Property(x => x.Tenant).HasMaxLength(10).IsRequired().IsUnicode(false);
        entity.Property(x => x.Code).HasMaxLength(6).IsRequired().IsUnicode(false);
        entity.Property(x => x.Project).HasMaxLength(3).IsRequired().IsUnicode(false);
        entity.Property(x => x.Description).HasMaxLength(75).IsRequired().IsUnicode(false);
        entity.Property(x => x.Status).HasMaxLength(2).IsRequired().IsUnicode(false);
        entity.Property(x => x.CopYear).HasMaxLength(2).IsRequired().IsUnicode(false);
        entity.Property(x => x.Component).HasMaxLength(4).IsRequired().IsUnicode(false);
        entity.Property(x => x.Month).HasMaxLength(2).IsRequired().IsUnicode(false);
        entity.Property(x => x.Week).HasMaxLength(2).IsRequired().IsUnicode(false);
        entity.Property(x => x.ComponentWeek).HasMaxLength(2).IsRequired().IsUnicode(false);
        entity.Property(x => x.YearWeek).HasMaxLength(2).IsRequired().IsUnicode(false);
        entity.Property(x => x.MilestoneProjection).HasMaxLength(6).IsRequired().IsUnicode(false);
    }
}