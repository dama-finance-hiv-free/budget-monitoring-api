using Dama.Fin.Domain.Entity.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dama.Fin.Infrastructure.Persistence.Configuration.Common;

public class TicketStatusConfiguration : IEntityTypeConfiguration<TicketStatus>
{
    public void Configure(EntityTypeBuilder<TicketStatus> entity)
    {
        entity.HasKey(e => new { e.Tenant, e.Code });

        entity.Property(e => e.Tenant).HasMaxLength(10).IsUnicode(false);
        entity.Property(e => e.Code).HasMaxLength(10).IsUnicode(false);
        entity.Property(e => e.Description).IsRequired().HasMaxLength(75).IsUnicode(false);

        entity.ToTable("ticket_status", "common");
    }
}


