using Dama.Fin.Domain.Entity.Budgeting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dama.Fin.Infrastructure.Persistence.Configuration.Budgeting;

public class BudgetBaseConfiguration<T> : IEntityTypeConfiguration<T> where T : BudgetBase
{
    public virtual void Configure(EntityTypeBuilder<T> entity)
    {
        entity.HasKey(e => new { e.Tenant, e.CopYear, e.Project, e.Activity, e.Component, e.Region });

        entity.Property(e => e.Tenant).HasMaxLength(10).IsRequired().IsUnicode(false);
        entity.Property(e => e.CopYear).HasMaxLength(8).IsRequired().IsUnicode(false);
        entity.Property(e => e.Project).HasMaxLength(6).IsRequired().IsUnicode(false);
        entity.Property(e => e.Activity).HasMaxLength(10).IsRequired().IsUnicode(false);
        entity.Property(e => e.Component).HasMaxLength(5).IsRequired().IsUnicode(false);
        entity.Property(e => e.Region).HasMaxLength(5).IsRequired().IsUnicode(false);
        entity.Property(e => e.Amount).IsRequired();
        entity.Property(e => e.CreatedOn).IsRequired();
    }
}