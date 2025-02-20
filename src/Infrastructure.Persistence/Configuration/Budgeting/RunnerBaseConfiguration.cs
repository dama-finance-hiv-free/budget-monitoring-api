using Dama.Fin.Domain.Entity.Budgeting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dama.Fin.Infrastructure.Persistence.Configuration.Budgeting;

public class RunnerBaseConfiguration<T> : IEntityTypeConfiguration<T> where T : RunnerBase
{
    public virtual void Configure(EntityTypeBuilder<T> entity)
    {
        entity.HasKey(e => new {e.Tenant,e.CopYear, e.Code, e.Region, e.Project });

        entity.Property(e => e.Tenant).HasMaxLength(10).IsRequired().IsUnicode(false);
        entity.Property(e => e.CopYear).HasMaxLength(10).IsRequired().IsUnicode(false);
        entity.Property(e => e.Code).HasMaxLength(10).IsRequired().IsUnicode(false);
        entity.Property(x => x.Project).HasMaxLength(3).IsRequired().IsUnicode(false);
        entity.Property(e => e.Region).HasMaxLength(10).IsRequired().IsUnicode(false);
        entity.Property(e => e.Project).HasMaxLength(3).IsRequired().IsUnicode(false);
        entity.Property(e => e.Description).HasMaxLength(150).IsRequired().IsUnicode(false);
        entity.Property(e => e.StartDate).IsRequired();
        entity.Property(e => e.EndDate).IsRequired();
        entity.Property(x => x.Component).HasMaxLength(4).IsRequired().IsUnicode(false);
        entity.Property(x => x.Month).HasMaxLength(2).IsRequired().IsUnicode(false);
        entity.Property(x => x.Week).HasMaxLength(2).IsRequired().IsUnicode(false);
        entity.Property(x => x.ComponentWeek).HasMaxLength(2).IsRequired().IsUnicode(false);
        entity.Property(x => x.YearWeek).HasMaxLength(2).IsRequired().IsUnicode(false);
        entity.Property(e => e.Status).HasMaxLength(2).IsRequired().IsUnicode(false);
        entity.Property(e => e.MilestoneProjection).HasMaxLength(10).IsRequired().IsUnicode(false);
    }
}