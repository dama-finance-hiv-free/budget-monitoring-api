using Dama.Fin.Domain.Entity.Budgeting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dama.Fin.Infrastructure.Persistence.Configuration.Budgeting;

public class OutlayInterventionConfiguration : IEntityTypeConfiguration<OutlayIntervention>
{
    public void Configure(EntityTypeBuilder<OutlayIntervention> entity)
    {
        entity.HasKey(e => new { e.Tenant, e.CopYear, e.Project, e.Outlay, e.Intervention });

        entity.Property(x => x.Tenant).HasMaxLength(10).IsRequired().IsUnicode(false);
        entity.Property(x => x.CopYear).HasMaxLength(5).IsRequired().IsUnicode(false);
        entity.Property(x => x.Project).HasMaxLength(5).IsRequired().IsUnicode(false);
        entity.Property(x => x.Outlay).HasMaxLength(5).IsRequired().IsUnicode(false);
        entity.Property(x => x.Intervention).HasMaxLength(5).IsRequired().IsUnicode(false);

        entity.ToTable("outlay_intervention", "budgeting");
    }
}