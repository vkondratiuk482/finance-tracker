using FinanceTracker.Domain.Budgets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceTracker.Persistence.EntityTypeConfigurations;

public class BudgetEntityTypeConfiguration : IEntityTypeConfiguration<Budget>
{
    public void Configure(EntityTypeBuilder<Budget> builder)
    {
        builder.Property(x => x.Payday).HasField("_payday");
    }
}
