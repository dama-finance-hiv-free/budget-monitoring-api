using Dama.Fin.Domain.Entity.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dama.Fin.Infrastructure.Persistence.Configuration.Common;

public class EmployerConfiguration : IEntityTypeConfiguration<Employer>
{
    public void Configure(EntityTypeBuilder<Employer> entity)
    {
        entity.HasKey(e => new { e.Tenant, e.Code });

        entity.Property(e => e.Tenant).HasMaxLength(10).IsUnicode(false);
        entity.Property(e => e.Code).HasMaxLength(5).IsUnicode(false);
        entity.Property(e => e.Description).IsRequired().HasMaxLength(75).IsUnicode(false);
        entity.Property(e => e.Address).IsRequired().HasMaxLength(50).IsUnicode(false);
        entity.Property(e => e.Town).IsRequired().HasMaxLength(35).IsUnicode(false);
        entity.Property(e => e.Telephone).IsRequired().HasMaxLength(35).IsUnicode(false);
        entity.Property(e => e.Region).IsRequired().HasMaxLength(2).IsUnicode(false);
        entity.Property(e => e.Status).IsRequired().HasMaxLength(2).IsUnicode(false);
            
        entity.ToTable("employer", "common");
    }
}