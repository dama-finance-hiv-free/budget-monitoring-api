using Dama.Fin.Domain.Entity.Budgeting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dama.Fin.Infrastructure.Persistence.Configuration.Budgeting;

public class BudgetConfiguration : BudgetBaseConfiguration<Budget>
{
    public override void Configure(EntityTypeBuilder<Budget> entity)
    {
        base.Configure(entity);

        entity.ToTable("budget", "budgeting");
    }
}