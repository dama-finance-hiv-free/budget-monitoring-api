using Dama.Fin.Domain.Entity.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dama.Fin.Infrastructure.Persistence.Configuration.Common;

public class PrivilegeConfiguration : IEntityTypeConfiguration<Privilege>
{
    public void Configure(EntityTypeBuilder<Privilege> entity)
    {
        entity.HasKey(e => new {e.Tenant, e.MenCode});

        entity.Property(e => e.Tenant).HasMaxLength(10).IsUnicode(false);
        entity.Property(e => e.MenCode).HasMaxLength(10).IsUnicode(false);
        entity.Property(e => e.App).IsRequired().HasMaxLength(2).IsUnicode(false);
        entity.Property(e => e.Status).IsRequired().HasMaxLength(2).IsUnicode(false);
        entity.Property(e => e.UsrCode).IsRequired().HasMaxLength(5).IsUnicode(false);

        entity.ToTable("privilege", "common");
    }
}