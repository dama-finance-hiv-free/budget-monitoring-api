using Dama.Fin.Domain.Entity.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dama.Fin.Infrastructure.Persistence.Configuration.Common;

public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> entity)
    {
        entity.HasKey(e => new {e.Tenant, e.RoleCode, e.UsrCode});

        entity.Property(e => e.Tenant).HasMaxLength(10).IsUnicode(false);
        entity.Property(e => e.RoleCode).HasMaxLength(5).IsUnicode(false);
        entity.Property(e => e.UsrCode).HasMaxLength(5).IsUnicode(false);
        entity.Property(e => e.Status).IsRequired().HasMaxLength(2).IsUnicode(false);

        entity.ToTable("user_role", "common");
    }
}