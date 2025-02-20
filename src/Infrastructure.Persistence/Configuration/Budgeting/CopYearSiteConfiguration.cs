using Dama.Fin.Domain.Entity.Budgeting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dama.Fin.Infrastructure.Persistence.Configuration.Budgeting;

public class CopYearSiteConfiguration : IEntityTypeConfiguration<CopYearSite>
{
    public void Configure(EntityTypeBuilder<CopYearSite> entity)
    {
        entity.HasKey(e => new { e.Tenant, e.CopYear, e.Site });

        entity.Property(x => x.Tenant).HasMaxLength(10).IsRequired().IsUnicode(false);
        entity.Property(x => x.CopYear).HasMaxLength(8).IsRequired().IsUnicode(false);
        entity.Property(x => x.Site).HasMaxLength(5).IsRequired().IsUnicode(false);

        entity.ToTable("cop_year_site", "budgeting");
    }
}