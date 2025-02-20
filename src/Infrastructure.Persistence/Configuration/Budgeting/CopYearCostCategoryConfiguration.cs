using Dama.Fin.Domain.Entity.Budgeting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dama.Fin.Infrastructure.Persistence.Configuration.Budgeting;

public class CopYearCostCategoryConfiguration : IEntityTypeConfiguration<CopYearCostCategory>
{
    public void Configure(EntityTypeBuilder<CopYearCostCategory> entity)
    {
        entity.HasKey(e => new { e.Tenant, e.CopYear, e.Project, e.CostCategory });

        entity.Property(x => x.Tenant).HasMaxLength(10).IsRequired().IsUnicode(false);
        entity.Property(x => x.CopYear).HasMaxLength(8).IsRequired().IsUnicode(false);
        entity.Property(x => x.Project).HasMaxLength(2).IsRequired().IsUnicode(false);
        entity.Property(x => x.CostCategory).HasMaxLength(5).IsRequired().IsUnicode(false);

        entity.ToTable("cop_year_cost_category", "budgeting");
    }
}