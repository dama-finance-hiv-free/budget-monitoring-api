using Dama.Fin.Domain.Entity.Budgeting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dama.Fin.Infrastructure.Persistence.Configuration.Budgeting;

public class UserCoordinationConfiguration : IEntityTypeConfiguration<UserCoordination>
{
    public void Configure(EntityTypeBuilder<UserCoordination> entity)
    {
        entity.HasKey(e => new { e.User, e.Coordination });

        entity.Property(e => e.User).HasMaxLength(10).IsUnicode(false);
        entity.Property(e => e.Coordination).HasMaxLength(10).IsUnicode(false);

        entity.ToTable("user_coordination", "budgeting");
    }
}