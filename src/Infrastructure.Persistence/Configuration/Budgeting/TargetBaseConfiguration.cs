using Dama.Fin.Domain.Entity.Budgeting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dama.Fin.Infrastructure.Persistence.Configuration.Budgeting;

public class TargetBaseConfiguration<T> : IEntityTypeConfiguration<T> where T : TargetBase
{
    public virtual void Configure(EntityTypeBuilder<T> entity)
    {
        entity.HasKey(e => new { e.Tenant, e.Outlay, e.CopYear, e.Project, e.Component, e.Region });

        entity.Property(e => e.Tenant).HasMaxLength(10).IsRequired().IsUnicode(false);
        entity.Property(e => e.Outlay).HasMaxLength(10).IsRequired().IsUnicode(false);
        entity.Property(e => e.CopYear).HasMaxLength(8).IsRequired().IsUnicode(false);
        entity.Property(e => e.Project).HasMaxLength(6).IsRequired().IsUnicode(false);
        entity.Property(e => e.Component).HasMaxLength(5).IsRequired().IsUnicode(false);
        entity.Property(e => e.Region).HasMaxLength(5).IsRequired().IsUnicode(false);
        entity.Property(e => e.Target).IsRequired();
        entity.Property(e => e.CreatedOn).IsRequired();
    }
}