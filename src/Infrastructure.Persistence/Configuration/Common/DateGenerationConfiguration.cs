using Dama.Fin.Domain.Entity.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dama.Fin.Infrastructure.Persistence.Configuration.Common;

public class DateGenerationConfiguration : IEntityTypeConfiguration<DateGeneration>
{
    public void Configure(EntityTypeBuilder<DateGeneration> entity)
    {
        entity.HasKey(e => new {e.Tenant, e.Branch});

        entity.Property(e => e.Tenant).HasMaxLength(10).IsUnicode(false);
        entity.Property(e => e.Branch).HasMaxLength(5).IsUnicode(false);
        entity.Property(e => e.TransDay).IsRequired().HasMaxLength(3).IsUnicode(false);
        entity.Property(e => e.TransMonth).IsRequired().HasMaxLength(2).IsUnicode(false);
        entity.Property(e => e.TransYear).IsRequired().HasMaxLength(5).IsUnicode(false);

        entity.ToTable("date_generation", "common");
    }
}