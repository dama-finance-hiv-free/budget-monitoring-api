using Dama.Fin.Domain.Entity.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dama.Fin.Infrastructure.Persistence.Configuration.Common;

public class TenantConfiguration : IEntityTypeConfiguration<Tenant>
{
    public void Configure(EntityTypeBuilder<Tenant> entity)
    {
        entity.HasKey(e => e.Code);

        entity.Property(e => e.Code).HasMaxLength(6).IsUnicode(false);
        entity.Property(e => e.Address).IsRequired().HasMaxLength(50).IsUnicode(false);
        entity.Property(e => e.City).IsRequired().HasMaxLength(25).IsUnicode(false);
        entity.Property(e => e.Description).IsRequired().HasMaxLength(75).IsUnicode(false);
        entity.Property(e => e.EMail).IsRequired().HasMaxLength(50).IsUnicode(false);
        entity.Property(e => e.Fax).IsRequired().HasMaxLength(25).IsUnicode(false);
        entity.Property(e => e.PostBox).IsRequired().HasMaxLength(30).IsUnicode(false);
        entity.Property(e => e.Telephone).IsRequired().HasMaxLength(25).IsUnicode(false);
        entity.Property(e => e.Website).IsRequired().HasMaxLength(30).IsUnicode(false);

        entity.ToTable("tenant", "common");
    }
}