using Dama.Fin.Domain.Entity.Budgeting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dama.Fin.Infrastructure.Persistence.Configuration.Budgeting;

public class ProjectSiteConfiguration : IEntityTypeConfiguration<ProjectSite>
{
    public void Configure(EntityTypeBuilder<ProjectSite> entity)
    {
        entity.HasKey(e => new { e.Tenant, e.copYear, e.Project, e.Site });

        entity.Property(x => x.Tenant).HasMaxLength(10).IsRequired().IsUnicode(false);
        entity.Property(x => x.copYear).HasMaxLength(8).IsRequired().IsUnicode(false);
        entity.Property(x => x.Project).HasMaxLength(2).IsRequired().IsUnicode(false);
        entity.Property(x => x.Site).HasMaxLength(5).IsRequired().IsUnicode(false);

        entity.ToTable("project_site", "budgeting");
    }
}