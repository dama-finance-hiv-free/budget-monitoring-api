using Dama.Fin.Domain.Entity.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dama.Fin.Infrastructure.Persistence.Configuration.Common;

public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> entity)
    {
        entity.HasKey(e => new { e.Tenant, e.Code });

        entity.Property(e => e.Tenant).HasMaxLength(10).IsUnicode(false);
        entity.Property(e => e.Code).HasMaxLength(10).IsUnicode(false);
        entity.Property(e => e.Description).IsRequired().HasMaxLength(255).IsUnicode(false);
        entity.Property(e => e.UserCode).IsRequired().HasMaxLength(10).IsUnicode(false);
        entity.Property(e => e.UserEmail).IsRequired().HasMaxLength(50).IsUnicode(false);
        entity.Property(e => e.UserPhoneNumber).IsRequired().HasMaxLength(10).IsUnicode(false);
        entity.Property(e => e.Region).IsRequired().HasMaxLength(10).IsUnicode(false);
        entity.Property(e => e.Comment).IsRequired().HasMaxLength(255).IsUnicode(false);
        entity.Property(e => e.Status).IsRequired().HasMaxLength(2).IsUnicode(false);

        entity.ToTable("ticket", "common");
    }
}


