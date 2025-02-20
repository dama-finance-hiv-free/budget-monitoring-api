using Dama.Fin.Domain.Entity.Common.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dama.Fin.Infrastructure.Persistence.Configuration;

public abstract class AuditableEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : AuditableEntity
{
    public virtual void Configure(EntityTypeBuilder<T> entity)
    {
        entity.Property(e => e.CreatedBy).HasMaxLength(40).IsRequired().IsUnicode(false);
        entity.Property(e => e.LastModifiedBy).HasMaxLength(40).IsUnicode(false);
    }
}