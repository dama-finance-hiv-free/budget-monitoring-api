using Dama.Fin.Domain.Entity.Budgeting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dama.Fin.Infrastructure.Persistence.Configuration.Budgeting;

public class RunnerComponentBaseConfiguration<T> : IEntityTypeConfiguration<T> where T : RunnerComponentBase
{
    public virtual void Configure(EntityTypeBuilder<T> entity)
    {
        entity.HasKey(e => new {e.Tenant, e.Runner, e.Project, e.Component});

        entity.Property(e => e.Tenant).HasMaxLength(10).IsRequired().IsUnicode(false);
        entity.Property(e => e.Runner).HasMaxLength(10).IsRequired().IsUnicode(false);
        entity.Property(e => e.Project).HasMaxLength(10).IsRequired().IsUnicode(false);
        entity.Property(e => e.Component).HasMaxLength(10).IsRequired().IsUnicode(false);
    }
}