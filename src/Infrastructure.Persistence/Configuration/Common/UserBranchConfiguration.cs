using Dama.Fin.Domain.Entity.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dama.Fin.Infrastructure.Persistence.Configuration.Common;

public class UserBranchConfiguration : IEntityTypeConfiguration<UserBranch>
{
    public void Configure(EntityTypeBuilder<UserBranch> entity)
    {
        entity.HasKey(e => new {e.Tenant, e.UsrCode, e.BranchCode});

        entity.Property(e => e.Tenant).HasMaxLength(10).IsUnicode(false);
        entity.Property(e => e.UsrCode).HasMaxLength(5).IsUnicode(false);
        entity.Property(e => e.BranchCode).HasMaxLength(5).IsUnicode(false);
        entity.Property(e => e.IsDefault).HasMaxLength(2).IsUnicode(false);

        entity.ToTable("user_branch", "common");
    }
}