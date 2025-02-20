using Dama.Fin.Domain.Entity.Budgeting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dama.Fin.Infrastructure.Persistence.Configuration.Budgeting;

public class OutlayConfiguration : IEntityTypeConfiguration<Outlay>
{
    public void Configure(EntityTypeBuilder<Outlay> entity)
    {
        entity.HasKey(e => new { e.Tenant, e.Code });

        entity.Property(e => e.Tenant).HasMaxLength(10).IsUnicode(false);
        entity.Property(e => e.Code).HasMaxLength(5).IsUnicode(false);
        entity.Property(e => e.BudgetCode).HasMaxLength(25).IsUnicode(false);
        entity.Property(e => e.Type).HasMaxLength(2).IsUnicode(false);
        entity.Property(e => e.Indicator).IsRequired().HasMaxLength(25).IsUnicode(false);

        entity.ToTable("outlay", "budgeting");
    }
}