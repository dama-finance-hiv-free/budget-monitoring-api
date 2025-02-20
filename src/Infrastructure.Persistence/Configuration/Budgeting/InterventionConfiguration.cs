using Dama.Fin.Domain.Entity.Budgeting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dama.Fin.Infrastructure.Persistence.Configuration.Budgeting;

public class InterventionConfiguration : IEntityTypeConfiguration<Intervention>
{
    public void Configure(EntityTypeBuilder<Intervention> entity)
    {
        entity.HasKey(e => new { e.Tenant, e.Code, e.CopYear });

        entity.Property(e => e.Tenant).HasMaxLength(10).IsUnicode(false);
        entity.Property(e => e.Code).HasMaxLength(5).IsUnicode(false);
        entity.Property(e => e.CopYear).HasMaxLength(5).IsUnicode(false);
        entity.Property(e => e.Description).IsRequired().HasMaxLength(150).IsUnicode(false);
        entity.Property(e => e.BudgetCode).IsRequired().HasMaxLength(5).IsUnicode(false);

        entity.ToTable("intervention", "budgeting");
    }
}