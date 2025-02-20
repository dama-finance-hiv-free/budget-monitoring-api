using Dama.Fin.Domain.Entity.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dama.Fin.Infrastructure.Persistence.Configuration.Common;

public class RoleMenuConfiguration : IEntityTypeConfiguration<RoleMenu>
{
    public void Configure(EntityTypeBuilder<RoleMenu> entity)
    {
        entity.HasKey(e => new {e.Tenant, e.MenuCode, e.RoleCode});

        entity.Property(e => e.Tenant).HasMaxLength(10).IsUnicode(false);
        entity.Property(e => e.MenuCode).HasMaxLength(25).IsUnicode(false);
        entity.Property(e => e.RoleCode).HasMaxLength(5).IsUnicode(false);
        entity.Property(e => e.App).IsRequired().HasMaxLength(2).IsUnicode(false);
        entity.Property(e => e.Status).IsRequired().HasMaxLength(2).IsUnicode(false);

        entity.ToTable("role_menu", "common");
    }
}