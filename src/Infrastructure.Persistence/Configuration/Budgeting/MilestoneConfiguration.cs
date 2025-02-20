using Dama.Fin.Domain.Entity.Budgeting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dama.Fin.Infrastructure.Persistence.Configuration.Budgeting;

public class MilestoneConfiguration : IEntityTypeConfiguration<Milestone>
{
    public void Configure(EntityTypeBuilder<Milestone> entity)
    {
        entity.HasKey(e => new { e.Tenant, e.Project, e.Runner, e.Activity, e.Site });

        entity.Property(x => x.Tenant).HasMaxLength(10).IsRequired().IsUnicode(false);
        entity.Property(x => x.Runner).HasMaxLength(15).IsRequired().IsUnicode(false);
        entity.Property(x => x.Region).HasMaxLength(5).IsRequired().IsUnicode(false);
        entity.Property(x => x.Project).HasMaxLength(4).IsRequired().IsUnicode(false);
        entity.Property(x => x.Activity).HasMaxLength(15).IsRequired().IsUnicode(false);
        entity.Property(x => x.Site).HasMaxLength(15).IsRequired().IsUnicode(false);
        entity.Property(x => x.BudgetNote).HasMaxLength(500).IsRequired().IsUnicode(false);

        entity.ToTable("milestone", "budgeting");
    }
}