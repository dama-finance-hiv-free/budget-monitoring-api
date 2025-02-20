using Dama.Fin.Domain.Entity.Budgeting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dama.Fin.Infrastructure.Persistence.Configuration.Budgeting;

public class ComponentActivityConfiguration : IEntityTypeConfiguration<ComponentActivity>
{
    public void Configure(EntityTypeBuilder<ComponentActivity> entity)
    {
        entity.HasKey(e => new { e.Tenant, e.CopYear,e.Component,e.Activity });

        entity.Property(x => x.Tenant).HasMaxLength(5).IsRequired().IsUnicode(false);
        entity.Property(x => x.CopYear).HasMaxLength(5).IsRequired().IsUnicode(false);
        entity.Property(x => x.Component).HasMaxLength(5).IsRequired().IsUnicode(false);
        entity.Property(x => x.Activity).HasMaxLength(10).IsRequired().IsUnicode(false);

        entity.ToTable("component_activity", "budgeting");
    }
}