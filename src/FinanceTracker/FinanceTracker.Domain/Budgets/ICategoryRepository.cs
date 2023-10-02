namespace FinanceTracker.Domain.Budgets;

public interface ICategoryRepository
{
    Task AddAsync(Category category);
}
