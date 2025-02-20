using Dama.Fin.Domain.Entity.Budgeting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dama.Fin.Infrastructure.Persistence.Configuration.Budgeting;

public class TransactionCodeConfiguration : IEntityTypeConfiguration<TransactionCode>
{
    public void Configure(EntityTypeBuilder<TransactionCode> entity)
    {
        entity.HasKey(e => e.Code);

        entity.Property(e => e.Code).HasMaxLength(10).IsUnicode(false);
        entity.Property(e => e.Description).IsRequired().HasMaxLength(25).IsUnicode(false);

        entity.ToTable("transaction_code", "budgeting");
    }
}