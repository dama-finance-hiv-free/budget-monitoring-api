using Dama.Fin.Domain.Entity.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dama.Fin.Infrastructure.Persistence.Configuration.Common;

public class TownConfiguration : IEntityTypeConfiguration<Town>
{
    public void Configure(EntityTypeBuilder<Town> entity)
    {
        entity.HasKey(e => new {e.Tenant, e.Code});

        entity.Property(e => e.Tenant).HasMaxLength(10).IsUnicode(false);
        entity.Property(e => e.Code).HasMaxLength(10).IsUnicode(false);
        entity.Property(e => e.Description).IsRequired().HasMaxLength(75).IsUnicode(false);
        entity.Property(e => e.Region).IsRequired().HasMaxLength(2).IsUnicode(false);

        entity.ToTable("town", "common");
    }
}


