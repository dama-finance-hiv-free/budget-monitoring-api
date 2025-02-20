using Dama.Fin.Domain.Entity.Budgeting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dama.Fin.Infrastructure.Persistence.Configuration.Budgeting;

public class SiteTypeConfiguration : IEntityTypeConfiguration<SiteType>
{
    public void Configure(EntityTypeBuilder<SiteType> entity)
    {
        entity.HasKey(e => e.Code);

        entity.Property(e => e.Code).HasMaxLength(10).IsUnicode(false);
        entity.Property(e => e.Description).IsRequired().HasMaxLength(25).IsUnicode(false);

        entity.ToTable("site_type", "budgeting");
    }
}