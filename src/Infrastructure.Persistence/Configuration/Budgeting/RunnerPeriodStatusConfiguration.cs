using Dama.Fin.Domain.Entity.Budgeting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dama.Fin.Infrastructure.Persistence.Configuration.Budgeting;

public class RunnerPeriodStatusConfiguration : IEntityTypeConfiguration<RunnerPeriodStatus>
{
    public void Configure(EntityTypeBuilder<RunnerPeriodStatus> entity)
    {
        entity.HasKey(e => e.Code);

        entity.Property(e => e.Code).HasMaxLength(5).IsUnicode(false);
        entity.Property(e => e.Description).IsRequired().HasMaxLength(25).IsUnicode(false);
        entity.Property(e => e.CreatedOn);

        entity.ToTable("runner_period_status", "budgeting");
    }
}