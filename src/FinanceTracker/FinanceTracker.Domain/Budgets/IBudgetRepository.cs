namespace FinanceTracker.Domain.Budgets;

public interface IBudgetRepository
{
    Task AddAsync(Budget budget);
}
