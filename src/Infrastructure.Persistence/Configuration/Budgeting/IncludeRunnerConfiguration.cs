using Dama.Fin.Domain.Entity.Budgeting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dama.Fin.Infrastructure.Persistence.Configuration.Budgeting;

public class IncludeRunnerConfiguration : IEntityTypeConfiguration<IncludeRunner>
{
    public void Configure(EntityTypeBuilder<IncludeRunner> entity)
    {
        entity.HasKey(e => new { e.User, e.Runner});

        entity.Property(e => e.User).HasMaxLength(5).IsUnicode(false);
        entity.Property(e => e.Runner).IsRequired().HasMaxLength(25).IsUnicode(false);

        entity.ToTable("include_runner", "budgeting");
    }
}