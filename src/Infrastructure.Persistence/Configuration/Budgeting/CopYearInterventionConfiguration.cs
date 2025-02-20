using Dama.Fin.Domain.Entity.Budgeting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dama.Fin.Infrastructure.Persistence.Configuration.Budgeting;

public class CopYearInterventionConfiguration : IEntityTypeConfiguration<CopYearIntervention>
{
    public void Configure(EntityTypeBuilder<CopYearIntervention> entity)
    {
        entity.HasKey(e => new { e.Tenant, e.CopYear, e.Project, e.Intervention });

        entity.Property(x => x.Tenant).HasMaxLength(10).IsRequired().IsUnicode(false);
        entity.Property(x => x.CopYear).HasMaxLength(8).IsRequired().IsUnicode(false);
        entity.Property(x => x.Project).HasMaxLength(2).IsRequired().IsUnicode(false);
        entity.Property(x => x.Intervention).HasMaxLength(5).IsRequired().IsUnicode(false);

        entity.ToTable("cop_year_intervention", "budgeting");
    }
}