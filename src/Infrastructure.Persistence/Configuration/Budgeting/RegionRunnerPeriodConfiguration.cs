using Dama.Fin.Domain.Entity.Budgeting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dama.Fin.Infrastructure.Persistence.Configuration.Budgeting;

public class RegionRunnerPeriodConfiguration : IEntityTypeConfiguration<RegionRunnerPeriod>
{
    public void Configure(EntityTypeBuilder<RegionRunnerPeriod> entity)
    {
        entity.HasKey(e => new { e.Tenant, e.Runner, e.Region });

        entity.Property(e => e.Tenant).HasMaxLength(10).IsRequired().IsUnicode(false);
        entity.Property(e => e.Runner).HasMaxLength(10).IsRequired().IsUnicode(false);
        entity.Property(e => e.Region).HasMaxLength(10).IsRequired().IsUnicode(false);

        entity.ToTable("region_runner_period", "budgeting");
    }
}