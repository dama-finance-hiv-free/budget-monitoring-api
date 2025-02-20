using Dama.Fin.Domain.Entity.Budgeting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dama.Fin.Infrastructure.Persistence.Configuration.Budgeting;

public class ActivityBaseConfiguration<T> : IEntityTypeConfiguration<T> where T : ActivityBase
{
    public virtual void Configure(EntityTypeBuilder<T> entity)
    {
        entity.HasKey(e => new { e.Tenant, e.Batch, e.BatchLine, e.Project });
        entity.HasIndex(e => e.TransDate);

        entity.Property(e => e.Tenant).HasMaxLength(10).IsRequired().IsUnicode(false);
        entity.Property(e => e.Batch).HasMaxLength(40).IsRequired().IsUnicode(false);
        entity.Property(e => e.BatchLine).HasMaxLength(10).IsRequired().IsUnicode(false);
        entity.Property(e => e.Runner).HasMaxLength(10).IsRequired().IsUnicode(false);
        entity.Property(e => e.Component).HasMaxLength(5).IsRequired().IsUnicode(false);
        entity.Property(e => e.Project).HasMaxLength(10).IsRequired().IsUnicode(false);
        entity.Property(e => e.Branch).HasMaxLength(10).IsRequired().IsUnicode(false);
        entity.Property(e => e.UserCode).HasMaxLength(5).IsRequired().IsUnicode(false);
        entity.Property(e => e.TransDate).IsRequired();
        entity.Property(e => e.Description).HasMaxLength(350).IsRequired().IsUnicode(false);
        entity.Property(e => e.Activity).HasMaxLength(10).IsRequired().IsUnicode(false);
        entity.Property(e => e.Site).HasMaxLength(5).IsRequired().IsUnicode(false);
        entity.Property(e => e.CostCategory).HasMaxLength(5).IsRequired().IsUnicode(false);
        entity.Property(e => e.Intervention).HasMaxLength(5).IsRequired().IsUnicode(false);
        entity.Property(e => e.BudgetCode).HasMaxLength(5).IsRequired().IsUnicode(false);
        entity.Property(e => e.Strategy).HasMaxLength(5).IsRequired().IsUnicode(false);
        entity.Property(e => e.Amount).IsRequired();
        entity.Property(e => e.ActivityType).HasMaxLength(2).IsRequired().IsUnicode(false);
        entity.Property(e => e.TranCode).HasMaxLength(2).IsRequired().IsUnicode(false);
        entity.Property(e => e.CopYear).HasMaxLength(8).IsRequired().IsUnicode(false);
        entity.Property(e => e.Region).HasMaxLength(4).IsRequired().IsUnicode(false);
    }
}