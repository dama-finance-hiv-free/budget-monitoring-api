using Dama.Fin.Domain.Entity.Budgeting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dama.Fin.Infrastructure.Persistence.Configuration.Budgeting;

public class ZoneConfiguration : IEntityTypeConfiguration<Zone>
{
    public void Configure(EntityTypeBuilder<Zone> entity)
    {
        entity.HasKey(e => e.Code);

        entity.Property(e => e.Code).HasMaxLength(2).IsUnicode(false);
        entity.Property(e => e.Description).IsRequired().HasMaxLength(25).IsUnicode(false);

        entity.ToTable("zone", "budgeting");
    }
}