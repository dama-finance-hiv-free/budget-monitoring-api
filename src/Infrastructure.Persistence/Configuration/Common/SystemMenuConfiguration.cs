using Dama.Fin.Domain.Entity.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dama.Fin.Infrastructure.Persistence.Configuration.Common;

public class SystemMenuConfiguration : IEntityTypeConfiguration<SystemMenu>
{
    public void Configure(EntityTypeBuilder<SystemMenu> entity)
    {
        entity.HasKey(e => new {e.Code, e.Lid});

        entity.Property(e => e.Code).HasMaxLength(25).IsUnicode(false);
        entity.Property(e => e.Lid).HasMaxLength(2).IsUnicode(false);
        entity.Property(e => e.App).IsRequired().HasMaxLength(2).IsUnicode(false);
        entity.Property(e => e.Description).IsRequired().HasMaxLength(75).IsUnicode(false);
        entity.Property(e => e.Parent).IsRequired().HasMaxLength(10).IsUnicode(false);
        entity.Property(e => e.Status).IsRequired().HasMaxLength(2).IsUnicode(false);

        entity.Ignore(e => e.Tenant);

        entity.ToTable("system_menu", "common");
    }
}