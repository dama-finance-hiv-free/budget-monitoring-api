using Dama.Fin.Domain.Entity.Budgeting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dama.Fin.Infrastructure.Persistence.Configuration.Budgeting;

public class BudgetHistoryConfiguration : BudgetBaseConfiguration<BudgetHistory>
{
    public override void Configure(EntityTypeBuilder<BudgetHistory> entity)
    {
        base.Configure(entity);

        entity.ToTable("budget_history", "budgeting");
    }
}