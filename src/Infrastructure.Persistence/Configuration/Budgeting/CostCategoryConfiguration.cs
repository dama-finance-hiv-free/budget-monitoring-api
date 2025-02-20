using Dama.Fin.Domain.Entity.Budgeting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dama.Fin.Infrastructure.Persistence.Configuration.Budgeting;

public class CostCategoryConfiguration : IEntityTypeConfiguration<CostCategory>
{
    public void Configure(EntityTypeBuilder<CostCategory> entity)
    {
        entity.HasKey(e => new { e.Tenant, e.Code, e.CopYear, e.Project });

        entity.Property(x => x.Tenant).HasMaxLength(10).IsRequired().IsUnicode(false);
        entity.Property(x => x.Code).HasMaxLength(5).IsRequired().IsUnicode(false);
        entity.Property(x => x.CopYear).HasMaxLength(10).IsRequired().IsUnicode(false);
        entity.Property(x => x.Description).HasMaxLength(150).IsRequired().IsUnicode(false);
        entity.Property(x => x.Project).HasMaxLength(2).IsRequired().IsUnicode(false);

        entity.ToTable("cost_category", "budgeting");
    }
}