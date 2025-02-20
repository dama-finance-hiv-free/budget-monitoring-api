using Dama.Fin.Domain.Entity.Budgeting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dama.Fin.Infrastructure.Persistence.Configuration.Budgeting;

public class ComponentConfiguration : IEntityTypeConfiguration<Component>
{
    public void Configure(EntityTypeBuilder<Component> entity)
    {
        entity.HasKey(e => new { e.Tenant, e.Code, e.CopYear, e.Project });

        entity.Property(x => x.Tenant).HasMaxLength(10).IsRequired().IsUnicode(false);
        entity.Property(x => x.Code).HasMaxLength(5).IsRequired().IsUnicode(false);
        entity.Property(x => x.CopYear).HasMaxLength(8).IsRequired().IsUnicode(false);
        entity.Property(x => x.Project).HasMaxLength(2).IsRequired().IsUnicode(false);
        entity.Property(x => x.Description).HasMaxLength(50).IsRequired().IsUnicode(false);
        entity.Property(x => x.LongDescription).HasMaxLength(100).IsRequired().IsUnicode(false);
        entity.Property(x => x.StartDate).IsRequired();
        entity.Property(x => x.EndDate).IsRequired();

        entity.ToTable("component", "budgeting");
    }
}