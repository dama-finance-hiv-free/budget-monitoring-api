using Dama.Fin.Domain.Entity.Budgeting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dama.Fin.Infrastructure.Persistence.Configuration.Budgeting;

public class QuarterConfiguration : IEntityTypeConfiguration<Quarter>
{
    public void Configure(EntityTypeBuilder<Quarter> entity)
    {
        entity.HasKey(e => new { e.Tenant, e.Code });

        entity.Property(x => x.Tenant).HasMaxLength(10).IsRequired().IsUnicode(false);
        entity.Property(x => x.Code).HasMaxLength(5).IsRequired().IsUnicode(false);
        entity.Property(x => x.Description).HasMaxLength(25).IsRequired().IsUnicode(false);
        entity.Property(x => x.Status).HasMaxLength(2).IsRequired().IsUnicode(false);

        entity.ToTable("quarter", "budgeting");
    }
}