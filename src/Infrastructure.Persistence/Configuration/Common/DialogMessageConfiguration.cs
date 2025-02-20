using Dama.Fin.Domain.Entity.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dama.Fin.Infrastructure.Persistence.Configuration.Common;

public class DialogMessageConfiguration : IEntityTypeConfiguration<DialogMessage>
{
    public void Configure(EntityTypeBuilder<DialogMessage> entity)
    {
        entity.HasKey(e => new {e.Code, e.Lid});

        entity.Property(e => e.Code).HasMaxLength(5).IsUnicode(false);
        entity.Property(e => e.Lid).HasMaxLength(2).IsUnicode(false);
        entity.Property(e => e.Description).IsRequired().HasMaxLength(125).IsUnicode(false);

        entity.Ignore(e => e.Tenant);

        entity.ToTable("dialog_message", "common");
    }
}