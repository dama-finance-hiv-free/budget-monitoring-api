using Dama.Fin.Domain.Entity.Budgeting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dama.Fin.Infrastructure.Persistence.Configuration.Budgeting;

public class DistrictConfiguration : IEntityTypeConfiguration<District>
{
    public void Configure(EntityTypeBuilder<District> entity)
    {
        entity.HasKey(e => new { e.Tenant, e.CopYear, e.Code, e.Project });

        entity.Property(e => e.Tenant).HasMaxLength(5).IsUnicode(false);
        entity.Property(e => e.Code).HasMaxLength(5).IsUnicode(false);
        entity.Property(e => e.CopYear).HasMaxLength(5).IsUnicode(false);
        entity.Property(e => e.Project).HasMaxLength(5).IsUnicode(false);
        entity.Property(e => e.Region).HasMaxLength(3).IsUnicode(false);
        entity.Property(e => e.Description).IsRequired().HasMaxLength(75).IsUnicode(false);

        entity.ToTable("district","budgeting");
    }
}