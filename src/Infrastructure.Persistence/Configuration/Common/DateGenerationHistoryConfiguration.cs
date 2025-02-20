using Dama.Fin.Domain.Entity.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dama.Fin.Infrastructure.Persistence.Configuration.Common;

public class DateGenerationHistoryConfiguration : IEntityTypeConfiguration<DateGenerationHistory>
{
    public void Configure(EntityTypeBuilder<DateGenerationHistory> entity)
    {
        entity.HasKey(e => new {e.Tenant, e.Branch, e.TransDate});

        entity.Property(e => e.Tenant).HasMaxLength(10).IsUnicode(false);
        entity.Property(e => e.Branch).HasMaxLength(5).IsUnicode(false);
        entity.Property(e => e.TransDay).IsRequired().HasMaxLength(3).IsUnicode(false);
        entity.Property(e => e.TransMonth).IsRequired().HasMaxLength(2).IsUnicode(false);
        entity.Property(e => e.TransYear).IsRequired().HasMaxLength(5).IsUnicode(false);

        entity.ToTable("date_generation_history", "common");
    }
}