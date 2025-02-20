using Dama.Fin.Domain.Entity.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dama.Fin.Infrastructure.Persistence.Configuration.Common;

public class WeekConfiguration : IEntityTypeConfiguration<Week>
{
    public void Configure(EntityTypeBuilder<Week> entity)
    {
        entity.HasKey(e => new { e.Tenant, e.CopYear,e.WeekSerial });

        entity.Property(e => e.Tenant).HasMaxLength(10).IsUnicode(false);
        entity.Property(e => e.CopYear).HasMaxLength(5).IsUnicode(false);

        entity.Ignore(e => e.WeekSerialAdjusted);

        entity.ToTable("week", "common");
    }
}