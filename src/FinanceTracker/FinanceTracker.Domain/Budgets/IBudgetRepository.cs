namespace FinanceTracker.Domain.Budgets;

public interface IBudgetRepository
{
    Task<Budget?> GetById(Guid id);
    
    Task AddAsync(Budget budget);
}
