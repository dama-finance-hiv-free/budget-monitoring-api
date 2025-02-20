using Dama.Fin.Domain.Entity.Budgeting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dama.Fin.Infrastructure.Persistence.Configuration.Budgeting;

public class RunnerStatusConfiguration : IEntityTypeConfiguration<RunnerStatus>
{
    public void Configure(EntityTypeBuilder<RunnerStatus> entity)
    {
        entity.HasKey(e => e.Code);

        entity.Property(e => e.Code).HasMaxLength(5).IsUnicode(false);
        entity.Property(e => e.Description).IsRequired().HasMaxLength(25).IsUnicode(false);
        entity.Property(e => e.CreatedOn);

        entity.ToTable("runner_status", "budgeting");
    }
}