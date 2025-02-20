using Dama.Fin.Domain.Entity.Budgeting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dama.Fin.Infrastructure.Persistence.Configuration.Budgeting;

public class SiteConfiguration : IEntityTypeConfiguration<Site>
{
    public void Configure(EntityTypeBuilder<Site> entity)
    {
        entity.HasKey(e => new { e.Tenant, e.Code });

        entity.Property(e => e.Tenant).HasMaxLength(10).IsUnicode(false);
        entity.Property(e => e.Code).HasMaxLength(5).IsUnicode(false);
        entity.Property(e => e.Description).IsRequired().HasMaxLength(150).IsUnicode(false);
        entity.Property(e => e.District).HasMaxLength(5).IsUnicode(false);
        entity.Property(e => e.SiteType).HasMaxLength(5).IsUnicode(false);
        entity.Property(e => e.SiteTier).HasMaxLength(5).IsUnicode(false);

        entity.Ignore(e => e.Region);

        entity.ToTable("site", "budgeting");
    }
}