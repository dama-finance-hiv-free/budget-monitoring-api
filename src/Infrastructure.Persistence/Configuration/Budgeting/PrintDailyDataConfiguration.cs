using Dama.Fin.Domain.Entity.Budgeting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dama.Fin.Infrastructure.Persistence.Configuration.Budgeting;

public partial class ActivityConfiguration
{
    public class PrintDailyDataConfiguration : IEntityTypeConfiguration<PrintDailyData>
    {
        public void Configure(EntityTypeBuilder<PrintDailyData> entity)
        {
            entity.HasKey(e => new { e.User, e.Site, e.UserCode })
                .HasName("pk_print_daily_data");

            entity.Property(x => x.User).HasMaxLength(10).IsRequired().IsUnicode(false);
            entity.Property(x => x.Site).HasMaxLength(10).IsRequired().IsUnicode(false);
            entity.Property(x => x.SiteName).HasMaxLength(150).IsRequired().IsUnicode(false);
            entity.Property(x => x.UserName).HasMaxLength(200).IsRequired().IsUnicode(false);
            entity.Property(x => x.UserCode).HasMaxLength(10).IsRequired().IsUnicode(false);


            entity.ToTable("print_daily_data", "budgeting");
        }
    }
}