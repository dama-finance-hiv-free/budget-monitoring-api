using Dama.Fin.Domain.Entity.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dama.Fin.Infrastructure.Persistence.Configuration.Common;

public class ServerStatusBaseConfiguration<T> : IEntityTypeConfiguration<T> where T : ServerStatusBase
{
    public virtual void Configure(EntityTypeBuilder<T> entity)
    {
        entity.HasKey(e => new { e.Tenant, e.Region, e.Runner, e.CopYear });

        entity.Property(e => e.Tenant).HasMaxLength(10).IsRequired().IsUnicode(false);
        entity.Property(e => e.Region).HasMaxLength(10).IsRequired().IsUnicode(false);
        entity.Property(e => e.Runner).HasMaxLength(10).IsRequired().IsUnicode(false);
        entity.Property(e => e.CopYear).HasMaxLength(10).IsRequired().IsUnicode(false);
        entity.Property(e => e.DayStatus).HasMaxLength(5).IsRequired().IsUnicode(false);
        entity.Property(e => e.Batch).HasMaxLength(7).IsRequired().IsUnicode(false);
    }
}