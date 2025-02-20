using Dama.Fin.Domain.Entity.Budgeting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dama.Fin.Infrastructure.Persistence.Configuration.Budgeting;

public class SurgeActivityConfiguration : IEntityTypeConfiguration<SurgeActivity>
{
    public void Configure(EntityTypeBuilder<SurgeActivity> entity)
    {
        entity.HasKey(e => new { e.Tenant, e.Code });

        entity.Property(x => x.Tenant).HasMaxLength(10).IsRequired().IsUnicode(false);
        entity.Property(x => x.Code).HasMaxLength(10).IsRequired().IsUnicode(false);

        entity.ToTable("surge_activity", "budgeting");
    }
}