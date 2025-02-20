using Dama.Fin.Domain.Entity.Budgeting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dama.Fin.Infrastructure.Persistence.Configuration.Budgeting;

public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> entity)
    {
        entity.HasKey(e => new { e.Tenant, e.Code });

        entity.Property(x => x.Tenant).HasMaxLength(10).IsRequired().IsUnicode(false);
        entity.Property(x => x.Code).HasMaxLength(6).IsRequired().IsUnicode(false);
        entity.Property(x => x.Description).HasMaxLength(75).IsRequired().IsUnicode(false);

        entity.ToTable("project", "budgeting");
    }
}