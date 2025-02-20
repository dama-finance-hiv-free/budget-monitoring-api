using Dama.Fin.Domain.Entity.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dama.Fin.Infrastructure.Persistence.Configuration.Common;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> entity)
    {
        entity.HasKey(e => new {e.Tenant, e.Code});

        entity.Property(e => e.Tenant).HasMaxLength(10).IsUnicode(false);
        entity.Property(e => e.Code).HasMaxLength(5).IsUnicode(false);
        entity.Property(e => e.Computer).HasMaxLength(50).IsUnicode(false);
        entity.Property(e => e.Connected).IsRequired().HasMaxLength(2).IsUnicode(false);
        entity.Property(e => e.DeviceSerial).HasMaxLength(50).IsUnicode(false);
        entity.Property(e => e.LogTime).IsRequired().HasMaxLength(15).IsUnicode(false);
        entity.Property(e => e.PhotoUrl).HasMaxLength(50).IsUnicode(false);
        entity.Property(e => e.UsrHash).HasMaxLength(150).IsUnicode(false);
        entity.Property(e => e.UsrName).IsRequired().HasMaxLength(50).IsUnicode(false);

        entity.ToTable("user", "common");
    }
}