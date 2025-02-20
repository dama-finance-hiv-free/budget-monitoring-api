using Dama.Fin.Domain.Entity.Budgeting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dama.Fin.Infrastructure.Persistence.Configuration.Budgeting;

public class RegionConfiguration : IEntityTypeConfiguration<Region>
{
    public void Configure(EntityTypeBuilder<Region> entity)
    {
        entity.HasKey(e => e.Code);

        entity.Property(e => e.Code).HasMaxLength(10).IsUnicode(false);
        entity.Property(e => e.Zone).HasMaxLength(5).IsUnicode(false);
        entity.Property(e => e.Initial).HasMaxLength(3).IsUnicode(false);
        entity.Property(e => e.Description).IsRequired().HasMaxLength(75).IsUnicode(false);

        entity.ToTable("region", "budgeting");
    }
}