using Dama.Fin.Domain.Entity.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dama.Fin.Infrastructure.Persistence.Configuration.Common;

public class BranchStationConfiguration : IEntityTypeConfiguration<BranchStation>
{
    public void Configure(EntityTypeBuilder<BranchStation> entity)
    {
        entity.HasKey(e => new {e.Tenant, e.Branch, e.Station});

        entity.Property(e => e.Tenant).HasMaxLength(10).IsUnicode(false);
        entity.Property(e => e.Branch).HasMaxLength(5).IsUnicode(false);
        entity.Property(e => e.Station).HasMaxLength(5).IsUnicode(false);
        entity.Property(e => e.Status).IsRequired().HasMaxLength(2).IsUnicode(false);

        entity.ToTable("branch_station", "common");
    }
}